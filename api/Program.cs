using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Modulog.Api.Data;
using Modulog.Api.Domain;
using Modulog.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("ConnectionStrings:Default is required.");
var jwt = builder.Configuration.GetSection(JwtOptions.Section).Get<JwtOptions>()
    ?? throw new InvalidOperationException("Jwt configuration is required.");
if (Encoding.UTF8.GetByteCount(jwt.SigningKey) < 32)
{
    throw new InvalidOperationException("Jwt:SigningKey must contain at least 32 UTF-8 bytes.");
}

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
builder.Services.AddIdentityCore<AppUser>(o =>
{
    o.User.RequireUniqueEmail = true;
    o.SignIn.RequireConfirmedEmail = false;
    o.Password.RequiredLength = 10;
    o.Password.RequireNonAlphanumeric = true;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.Section));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SigningKey)),
        ClockSkew = TimeSpan.FromSeconds(30)
    };
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<TokenService>();
builder.Services.AddSingleton<WeakTopicScorer>();
builder.Services.AddScoped<RecommendationService>();
builder.Services.AddHttpClient<SystemDesignService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo { Title = "Modulog API", Version = "v1" });
    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    o.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        [new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }] = []
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

var api = app.MapGroup("/api/v1");

api.MapPost("/auth/register", async (RegisterRequest request, UserManager<AppUser> users, AppDbContext db, CancellationToken ct) =>
{
    var email = request.Email.Trim().ToLowerInvariant();
    var user = new AppUser { Id = Guid.NewGuid(), UserName = email, Email = email, CreatedAt = DateTimeOffset.UtcNow };
    var result = await users.CreateAsync(user, request.Password);
    if (!result.Succeeded)
    {
        return Results.ValidationProblem(result.Errors.GroupBy(x => x.Code).ToDictionary(g => g.Key, g => g.Select(x => x.Description).ToArray()));
    }

    var module = await db.Modules.SingleAsync(x => x.Key == "leetcode", ct);
    db.UserModules.Add(new UserModule { UserId = user.Id, ModuleId = module.Id });
    await db.SaveChangesAsync(ct);
    return Results.Created($"/api/v1/users/{user.Id}", new { user.Id, user.Email, user.EmailConfirmed });
}).AllowAnonymous();

api.MapPost("/auth/login", async (LoginRequest request, UserManager<AppUser> users, TokenService tokens, CancellationToken ct) =>
{
    var user = await users.FindByEmailAsync(request.Email.Trim());
    if (user is null || !await users.CheckPasswordAsync(user, request.Password))
    {
        return Results.Problem("Invalid email or password.", statusCode: StatusCodes.Status401Unauthorized);
    }

    return Results.Ok(await tokens.IssueAsync(user, ct));
}).AllowAnonymous();

api.MapPost("/auth/refresh", async (RefreshRequest request, TokenService tokens, CancellationToken ct) =>
{
    var pair = await tokens.RotateAsync(request.RefreshToken, ct);
    return pair is null ? Results.Problem("Refresh token is invalid or expired.", statusCode: 401) : Results.Ok(pair);
}).AllowAnonymous();

api.MapPost("/auth/email-verification-token", async (ClaimsPrincipal principal, UserManager<AppUser> users) =>
{
    var user = await users.FindByIdAsync(principal.UserId().ToString());
    if (user is null)
    {
        return Results.Unauthorized();
    }

    var token = await users.GenerateEmailConfirmationTokenAsync(user);
    return Results.Ok(new { token, deliveryConfigured = false });
}).RequireAuthorization();

api.MapPost("/auth/verify-email", async (VerifyEmailRequest request, UserManager<AppUser> users) =>
{
    var user = await users.FindByIdAsync(request.UserId.ToString());
    if (user is null)
    {
        return Results.NotFound();
    }

    var result = await users.ConfirmEmailAsync(user, request.Token);
    return result.Succeeded ? Results.NoContent() : Results.ValidationProblem(new Dictionary<string, string[]> { ["token"] = result.Errors.Select(x => x.Description).ToArray() });
}).AllowAnonymous();

var problems = api.MapGroup("/problems");
problems.MapGet("/", async (string? topic, Difficulty? difficulty, AppDbContext db, CancellationToken ct) =>
{
    var query = db.ProblemBank.AsNoTracking();
    if (!string.IsNullOrWhiteSpace(topic))
    {
        query = query.Where(x => x.TopicTags.Contains(topic.ToLowerInvariant()));
    }

    if (difficulty is not null)
    {
        query = query.Where(x => x.Difficulty == difficulty);
    }

    return Results.Ok(await query.OrderBy(x => x.Title).ToListAsync(ct));
}).RequireAuthorization();
problems.MapGet("/{id:guid}", async (Guid id, AppDbContext db, CancellationToken ct) =>
    await db.ProblemBank.FindAsync([id], ct) is { } p ? Results.Ok(p) : Results.NotFound()).RequireAuthorization();
problems.MapPost("/", async (ProblemRequest request, AppDbContext db, CancellationToken ct) =>
{
    var problem = request.ToEntity();
    db.ProblemBank.Add(problem);
    await db.SaveChangesAsync(ct);
    return Results.Created($"/api/v1/problems/{problem.Id}", problem);
}).RequireAuthorization(p => p.RequireRole("admin"));
problems.MapPut("/{id:guid}", async (Guid id, ProblemRequest request, AppDbContext db, CancellationToken ct) =>
{
    var p = await db.ProblemBank.FindAsync([id], ct);
    if (p is null)
    {
        return Results.NotFound();
    }

    p.Title = request.Title.Trim(); p.ExternalUrl = request.ExternalUrl; p.TopicTags = request.TopicTags.Select(x => x.Trim().ToLowerInvariant()).Distinct().ToArray(); p.Difficulty = request.Difficulty;
    await db.SaveChangesAsync(ct); return Results.Ok(p);
}).RequireAuthorization(p => p.RequireRole("admin"));
problems.MapDelete("/{id:guid}", async (Guid id, AppDbContext db, CancellationToken ct) =>
{
    var p = await db.ProblemBank.FindAsync([id], ct);
    if (p is null)
    {
        return Results.NotFound();
    }

    db.Remove(p); await db.SaveChangesAsync(ct); return Results.NoContent();
}).RequireAuthorization(p => p.RequireRole("admin"));

api.MapPost("/entries", async (CreateEntryRequest request, ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
{
    var problem = await db.ProblemBank.FindAsync([request.ProblemBankId], ct);
    if (problem is null)
    {
        return Results.ValidationProblem(new Dictionary<string, string[]> { ["problemBankId"] = ["Problem does not exist."] });
    }

    if (request.TimeSpentMinutes <= 0 || request.HintsUsed < 0 || request.SelfRatedConfidence is < 1 or > 5)
    {
        return Results.ValidationProblem(new Dictionary<string, string[]> { ["entry"] = ["Time must be positive, hints non-negative, and confidence between 1 and 5."] });
    }

    var module = await db.Modules.SingleAsync(x => x.Key == "leetcode", ct);
    var payload = new LeetCodeEntryData(problem.Id, request.TimeSpentMinutes, request.HintsUsed, request.SelfRatedConfidence, problem.TopicTags);
    var entry = new Entry { UserId = principal.UserId(), ModuleId = module.Id, EntryType = "problem_attempt", Data = JsonSerializer.Serialize(payload), ReviewDueAt = request.ReviewDueAt, LoggedAt = request.LoggedAt ?? DateTimeOffset.UtcNow };
    db.Entries.Add(entry); await db.SaveChangesAsync(ct);
    return Results.Created($"/api/v1/entries/{entry.Id}", entry);
}).RequireAuthorization();

api.MapGet("/entries", async (DateTimeOffset? from, DateTimeOffset? to, string? topic, ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
{
    var query = db.Entries.AsNoTracking().Where(x => x.UserId == principal.UserId());
    if (from is not null)
    {
        query = query.Where(x => x.LoggedAt >= from);
    }

    if (to is not null)
    {
        query = query.Where(x => x.LoggedAt <= to);
    }

    if (!string.IsNullOrWhiteSpace(topic))
    {
        var topicFilter = JsonSerializer.Serialize(new { topic_tags = new[] { topic.ToLowerInvariant() } });
        query = query.Where(x => EF.Functions.JsonContains(x.Data, topicFilter));
    }
    return Results.Ok(await query.OrderByDescending(x => x.LoggedAt).ToListAsync(ct));
}).RequireAuthorization();

api.MapGet("/insights/weak-topics", async (ClaimsPrincipal principal, AppDbContext db, WeakTopicScorer scorer, CancellationToken ct) =>
{
    var entries = await db.Entries.AsNoTracking().Where(x => x.UserId == principal.UserId()).ToListAsync(ct);
    return Results.Ok(scorer.Score(entries, DateTimeOffset.UtcNow));
}).RequireAuthorization();

problems.MapGet("/recommend", async (int? excludeDays, ClaimsPrincipal principal, RecommendationService service, CancellationToken ct) =>
    await service.RecommendAsync(principal.UserId(), Math.Clamp(excludeDays ?? 7, 0, 90), ct) is { } p ? Results.Ok(p) : Results.NotFound()).RequireAuthorization();

api.MapPost("/system-design/generate", async (SystemDesignRequest request, ClaimsPrincipal principal, SystemDesignService service, CancellationToken ct) =>
{
    try { return Results.Ok(await service.GenerateAsync(principal.UserId(), request.WeakTopic, request.Level, ct)); }
    catch (InvalidOperationException e) { return Results.Problem(e.Message, statusCode: 503); }
}).RequireAuthorization();

app.Run();

public partial class Program;

sealed record RegisterRequest(string Email, string Password);
sealed record LoginRequest(string Email, string Password);
sealed record RefreshRequest(string RefreshToken);
sealed record VerifyEmailRequest(Guid UserId, string Token);
sealed record ProblemRequest(string Title, string ExternalUrl, string[] TopicTags, Difficulty Difficulty)
{
    public Problem ToEntity() => new() { Title = Title.Trim(), ExternalUrl = ExternalUrl, TopicTags = TopicTags.Select(x => x.Trim().ToLowerInvariant()).Distinct().ToArray(), Difficulty = Difficulty };
}
sealed record CreateEntryRequest(Guid ProblemBankId, int TimeSpentMinutes, int HintsUsed, int? SelfRatedConfidence, DateTimeOffset? ReviewDueAt, DateTimeOffset? LoggedAt);
sealed record SystemDesignRequest(string? WeakTopic, string? Level);

static class ClaimsExtensions
{
    public static Guid UserId(this ClaimsPrincipal principal) =>
        Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Missing user id claim."));
}
