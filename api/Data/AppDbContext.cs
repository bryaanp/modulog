using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modulog.Api.Domain;

namespace Modulog.Api.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Module> Modules => Set<Module>();
    public DbSet<UserModule> UserModules => Set<UserModule>();
    public DbSet<Entry> Entries => Set<Entry>();
    public DbSet<Problem> ProblemBank => Set<Problem>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        b.Entity<AppUser>().ToTable("users");
        b.Entity<IdentityRole<Guid>>().ToTable("roles");
        b.Entity<IdentityUserRole<Guid>>().ToTable("user_roles");
        b.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        b.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        b.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claims");
        b.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        b.Entity<AppUser>().Property(x => x.CreatedAt).HasColumnName("created_at");

        b.Entity<Module>(e => { e.ToTable("modules"); e.HasIndex(x => x.Key).IsUnique(); e.Property(x => x.SchemaDefinition).HasColumnType("jsonb"); });
        b.Entity<UserModule>(e => { e.ToTable("user_modules"); e.HasIndex(x => new { x.UserId, x.ModuleId }).IsUnique(); e.Property(x => x.Config).HasColumnType("jsonb"); e.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade); e.HasOne<Module>().WithMany().HasForeignKey(x => x.ModuleId); });
        b.Entity<Entry>(e => { e.ToTable("entries"); e.Property(x => x.Data).HasColumnType("jsonb"); e.HasIndex(x => new { x.UserId, x.LoggedAt }); e.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade); e.HasOne<Module>().WithMany().HasForeignKey(x => x.ModuleId); });
        b.Entity<Problem>(e => { e.ToTable("problem_bank"); e.Property(x => x.TopicTags).HasColumnType("text[]"); e.Property(x => x.Difficulty).HasConversion<string>(); });
        b.Entity<RefreshToken>(e => { e.ToTable("refresh_tokens"); e.HasIndex(x => x.TokenHash).IsUnique(); e.HasIndex(x => new { x.UserId, x.ExpiresAt }); e.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade); });

        b.Entity<Module>().HasData(new Module
        {
            Id = Guid.Parse("10000000-0000-0000-0000-000000000001"), Key = "leetcode", Name = "LeetCode",
            SchemaDefinition = """{"problem_attempt":{"problem_bank_id":"uuid","time_spent_minutes":"integer","hints_used":"integer","self_rated_confidence":"integer|null","topic_tags":"string[]"}}"""
        });
        b.Entity<Problem>().HasData(
            Seed("20000000-0000-0000-0000-000000000001", "Two Sum", "https://leetcode.com/problems/two-sum/", ["array", "hash-table"], Difficulty.Easy),
            Seed("20000000-0000-0000-0000-000000000002", "Valid Parentheses", "https://leetcode.com/problems/valid-parentheses/", ["stack", "string"], Difficulty.Easy),
            Seed("20000000-0000-0000-0000-000000000003", "Longest Substring Without Repeating Characters", "https://leetcode.com/problems/longest-substring-without-repeating-characters/", ["hash-table", "string", "sliding-window"], Difficulty.Medium));
    }

    private static Problem Seed(string id, string title, string url, string[] topics, Difficulty difficulty) =>
        new() { Id = Guid.Parse(id), Title = title, ExternalUrl = url, TopicTags = topics, Difficulty = difficulty, CreatedAt = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero) };
}
