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
        db.RefreshTokens.Add(new RefreshToken { UserId = user.Id, TokenHash = Hash(rawRefresh), ExpiresAt = now.AddDays(_options.RefreshTokenDays) });
        await db.SaveChangesAsync(ct);
        return new TokenPair(new JwtSecurityTokenHandler().WriteToken(token), rawRefresh, expiry);
    }

    public async Task<TokenPair?> RotateAsync(string rawToken, CancellationToken ct)
    {
        var hash = Hash(rawToken);
        var stored = await db.RefreshTokens.SingleOrDefaultAsync(x => x.TokenHash == hash, ct);
        if (stored is null || stored.RevokedAt is not null || stored.ExpiresAt <= DateTimeOffset.UtcNow)
        {
            return null;
        }

        var user = await users.FindByIdAsync(stored.UserId.ToString());
        if (user is null)
        {
            return null;
        }

        stored.RevokedAt = DateTimeOffset.UtcNow;
        var pair = await IssueAsync(user, ct);
        stored.ReplacedByTokenId = await db.RefreshTokens.Where(x => x.TokenHash == Hash(pair.RefreshToken)).Select(x => x.Id).SingleAsync(ct);
        await db.SaveChangesAsync(ct);
        return pair;
    }

    private static string Hash(string token) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(token)));
}
