using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Modulog.Api.Data;
using Modulog.Api.Domain;

namespace Modulog.Api.Services;

public sealed class JwtOptions
{
    public const string Section = "Jwt";
    public string Issuer { get; set; } = "modulog";
    public string Audience { get; set; } = "modulog-clients";
    public string SigningKey { get; set; } = "";
    public int AccessTokenMinutes { get; set; } = 15;
    public int RefreshTokenDays { get; set; } = 30;
}

public sealed record TokenPair(string AccessToken, string RefreshToken, DateTimeOffset AccessTokenExpiresAt);

public sealed class TokenService(AppDbContext db, UserManager<AppUser> users, IOptions<JwtOptions> options)
{
    private readonly JwtOptions _options = options.Value;

    public async Task<TokenPair> IssueAsync(AppUser user, CancellationToken ct)
    {
        var (pair, _) = await CreatePairAsync(user);
        await db.SaveChangesAsync(ct);
        return pair;
    }

    public async Task<TokenPair?> RotateAsync(string rawToken, CancellationToken ct)
    {
        var hash = Hash(rawToken);
        await using var transaction = await db.Database.BeginTransactionAsync(ct);

        // The row lock makes token consumption atomic. Concurrent requests for the same
        // refresh token serialize here, and only the first can observe an active token.
        var stored = await db.RefreshTokens
            .FromSqlInterpolated($"SELECT * FROM refresh_tokens WHERE token_hash = {hash} FOR UPDATE")
            .SingleOrDefaultAsync(ct);
        if (stored is null || stored.RevokedAt is not null || stored.ExpiresAt <= DateTimeOffset.UtcNow)
        {
            await transaction.RollbackAsync(ct);
            return null;
        }

        var user = await users.FindByIdAsync(stored.UserId.ToString());
        if (user is null)
        {
            await transaction.RollbackAsync(ct);
            return null;
        }

        stored.RevokedAt = DateTimeOffset.UtcNow;
        var (pair, replacement) = await CreatePairAsync(user);
        stored.ReplacedByTokenId = replacement.Id;
        await db.SaveChangesAsync(ct);
        await transaction.CommitAsync(ct);
        return pair;
    }

    private async Task<(TokenPair Pair, RefreshToken StoredToken)> CreatePairAsync(AppUser user)
    {
        var now = DateTimeOffset.UtcNow;
        var expiry = now.AddMinutes(_options.AccessTokenMinutes);
        var roles = await users.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email ?? ""),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
        var token = new JwtSecurityToken(_options.Issuer, _options.Audience, claims, now.UtcDateTime, expiry.UtcDateTime,
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey)), SecurityAlgorithms.HmacSha256));
        var rawRefresh = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        var stored = new RefreshToken
        {
            UserId = user.Id,
            TokenHash = Hash(rawRefresh),
            ExpiresAt = now.AddDays(_options.RefreshTokenDays)
        };
        db.RefreshTokens.Add(stored);
        return (new TokenPair(new JwtSecurityTokenHandler().WriteToken(token), rawRefresh, expiry), stored);
    }

    private static string Hash(string token) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(token)));
}
