using System.Security.Claims;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Modulog.Api.Data;
using Modulog.Api.Domain;
using Modulog.Api.Services;

namespace Modulog.Api.Modules.Interview;

public sealed record CreateEntryRequest(Guid ProblemBankId, int TimeSpentMinutes, int HintsUsed,
    int? SelfRatedConfidence, DateTimeOffset? ReviewDueAt, DateTimeOffset? LoggedAt, string? Notes,
    int SchemaVersion = 1);
public sealed record SystemDesignRequest(string? WeakTopic, string? Level);

public static class InterviewEndpoints
{
    public static void MapInterviewEndpoints(this RouteGroupBuilder api)
    {
        api.MapPost("/entries", async (Guid? projectId, CreateEntryRequest request, ClaimsPrincipal principal,
            AppDbContext db, ProjectAccess access, CancellationToken ct) =>
        {
            var project = await access.FindAsync(principal.UserId(), projectId, ModuleIds.Interview, ct);
            if (project is null)
            {
                return Results.NotFound();
            }

            if (project.IsArchived)
            {
                return Results.Conflict(new { detail = "Restore this project before logging work." });
            }

            if (request.SchemaVersion != 1 || request.TimeSpentMinutes <= 0 || request.HintsUsed < 0
                || request.SelfRatedConfidence is < 1 or > 5 || request.Notes?.Length > 20000)
            {
                return Results.ValidationProblem(new Dictionary<string, string[]>
                { ["entry"] = ["Use schema version 1, positive time, non-negative hints, confidence 1–5, and notes up to 20,000 characters."] });
            }

            var problem = await db.ProblemBank.FindAsync([request.ProblemBankId], ct);
            if (problem is null)
            {
                return Results.ValidationProblem(new Dictionary<string, string[]>
                { ["problemBankId"] = ["Problem does not exist."] });
            }

            var payload = new LeetCodeEntryData(problem.Id, request.TimeSpentMinutes, request.HintsUsed,
                request.SelfRatedConfidence, problem.TopicTags, request.Notes);
            var entry = new Entry
            {
                UserId = principal.UserId(), ProjectId = project.Id, ModuleId = ModuleIds.Interview,
                EntryType = "problem_attempt", Title = problem.Title[..Math.Min(200, problem.Title.Length)], Data = JsonSerializer.Serialize(payload),
                ReviewDueAt = request.ReviewDueAt?.ToUniversalTime(), LoggedAt = (request.LoggedAt ?? DateTimeOffset.UtcNow).ToUniversalTime()
            };
            db.Entries.Add(entry);
            await db.SaveChangesAsync(ct);
            return Results.Created($"/api/v1/entries/{entry.Id}", entry);
        }).RequireAuthorization();

        api.MapGet("/entries", async (Guid? projectId, DateTimeOffset? from, DateTimeOffset? to, string? topic,
            ClaimsPrincipal principal, AppDbContext db, ProjectAccess access, CancellationToken ct) =>
        {
            var project = await access.FindAsync(principal.UserId(), projectId, ModuleIds.Interview, ct);
            if (project is null)
            {
                return Results.NotFound();
            }

            var query = InterviewEntryStore.Query(db, principal.UserId(), project.Id);
            if (from is not null)
            {
                query = query.Where(x => x.LoggedAt >= from.Value.ToUniversalTime());
            }

            if (to is not null)
            {
                query = query.Where(x => x.LoggedAt <= to.Value.ToUniversalTime());
            }

            if (!string.IsNullOrWhiteSpace(topic))
            {
                var filter = JsonSerializer.Serialize(new { topic_tags = new[] { topic.ToLowerInvariant() } });
                query = query.Where(x => EF.Functions.JsonContains(x.Data, filter));
            }
            return Results.Ok(await query.OrderByDescending(x => x.LoggedAt).ToListAsync(ct));
        }).RequireAuthorization();

        api.MapGet("/insights/weak-topics", async (Guid? projectId, ClaimsPrincipal principal, AppDbContext db,
            ProjectAccess access, WeakTopicScorer scorer, CancellationToken ct) =>
        {
            var project = await access.FindAsync(principal.UserId(), projectId, ModuleIds.Interview, ct);
            if (project is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(scorer.Score(await InterviewEntryStore.Query(db, principal.UserId(), project.Id).ToListAsync(ct), DateTimeOffset.UtcNow));
        }).RequireAuthorization();

        api.MapGet("/problems/recommend", async (Guid? projectId, int? excludeDays, ClaimsPrincipal principal,
            ProjectAccess access, RecommendationService service, CancellationToken ct) =>
        {
            var project = await access.FindAsync(principal.UserId(), projectId, ModuleIds.Interview, ct);
            if (project is null)
            {
                return Results.NotFound();
            }

            var problem = await service.RecommendAsync(principal.UserId(), project.Id, Math.Clamp(excludeDays ?? 7, 0, 90), ct);
            return problem is null ? Results.NotFound() : Results.Ok(problem);
        }).RequireAuthorization();

        api.MapPost("/system-design/generate", async (Guid? projectId, SystemDesignRequest request,
            ClaimsPrincipal principal, ProjectAccess access, SystemDesignService service, CancellationToken ct) =>
        {
            var project = await access.FindAsync(principal.UserId(), projectId, ModuleIds.Interview, ct);
            if (project is null)
            {
                return Results.NotFound();
            }

            try { return Results.Ok(await service.GenerateAsync(principal.UserId(), project.Id, request.WeakTopic, request.Level, ct)); }
            catch (InvalidOperationException e) { return Results.Problem(e.Message, statusCode: 503); }
        }).RequireAuthorization();
    }

}
