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
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectModule> ProjectModules => Set<ProjectModule>();
    public DbSet<Problem> ProblemBank => Set<Problem>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<AppUser>().ToTable("users");
        builder.Entity<IdentityRole<Guid>>().ToTable("roles");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_roles");
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claims");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        builder.Entity<AppUser>().Property(x => x.CreatedAt).HasColumnName("created_at");

        builder.Entity<Module>(e => { e.ToTable("modules"); e.HasIndex(x => x.Key).IsUnique(); e.Property(x => x.SchemaDefinition).HasColumnType("jsonb"); });
        builder.Entity<UserModule>(e => { e.ToTable("user_modules"); e.HasIndex(x => new { x.UserId, x.ModuleId }).IsUnique(); e.Property(x => x.Config).HasColumnType("jsonb"); e.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade); e.HasOne<Module>().WithMany().HasForeignKey(x => x.ModuleId); });
        builder.Entity<Entry>(e => { e.ToTable("entries"); e.Property(x => x.Data).HasColumnType("jsonb"); e.HasIndex(x => new { x.UserId, x.LoggedAt }); e.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade); e.HasOne<Module>().WithMany().HasForeignKey(x => x.ModuleId); });
        builder.Entity<Project>(e =>
        {
            e.ToTable("projects");
            e.HasAlternateKey(x => new { x.UserId, x.Id });
            e.HasIndex(x => x.UserId).IsUnique().HasFilter("is_default_interview = true");
            e.Property(x => x.Name).HasMaxLength(160);
            e.Property(x => x.Description).HasMaxLength(4000);
            e.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<ProjectModule>(e =>
        {
            e.ToTable("project_modules");
            e.HasKey(x => new { x.UserId, x.ProjectId, x.ModuleId });
            e.HasOne<Project>().WithMany().HasForeignKey(x => new { x.UserId, x.ProjectId })
                .HasPrincipalKey(x => new { x.UserId, x.Id }).OnDelete(DeleteBehavior.Cascade);
            e.HasOne<Module>().WithMany().HasForeignKey(x => x.ModuleId);
        });
        builder.Entity<Entry>(e =>
        {
            e.Property(x => x.Title).HasMaxLength(200);
            e.Property(x => x.Status).HasMaxLength(20);
            e.HasIndex(x => new { x.UserId, x.ProjectId, x.ModuleId, x.LoggedAt });
            e.HasIndex(x => new { x.UserId, x.ReviewDueAt });
            e.HasOne<ProjectModule>().WithMany().HasForeignKey(x => new { x.UserId, x.ProjectId, x.ModuleId });
        });
        builder.Entity<Problem>(e =>
        {
            e.ToTable("problem_bank");
            e.HasIndex(x => x.ExternalUrl).IsUnique();
            e.Property(x => x.TopicTags).HasColumnType("text[]");
            e.Property(x => x.Companies).HasColumnType("text[]");
            e.Property(x => x.Difficulty).HasConversion<string>();
        });
        builder.Entity<RefreshToken>(e => { e.ToTable("refresh_tokens"); e.HasIndex(x => x.TokenHash).IsUnique(); e.HasIndex(x => new { x.UserId, x.ExpiresAt }); e.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade); });

        builder.Entity<Module>().HasData(new Module
        {
            Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
            Key = "leetcode",
            Name = "LeetCode",
            SchemaDefinition = """{"problem_attempt":{"problem_bank_id":"uuid","time_spent_minutes":"integer","hints_used":"integer","self_rated_confidence":"integer|null","topic_tags":"string[]"}}"""
        });
        builder.Entity<Problem>().HasData(LeetCodeCatalog.Problems);
        builder.Entity<Module>().HasData(new Module
        {
            Id = ModuleIds.Software,
            Key = "software",
            Name = "Software projects",
            SchemaDefinition = """{"version":1,"milestone":{"notes":"string|null"},"dev_log":{"notes":"string"}}"""
        });
    }
}
