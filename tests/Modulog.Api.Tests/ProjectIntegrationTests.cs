using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Modulog.Api.Data;
using Modulog.Api.Domain;
using Npgsql;

namespace Modulog.Api.Tests;

public sealed partial class ApiIntegrationTests
{
    [Fact]
    public async Task ProjectsIsolateOwnersModulesAndInterviewSignals()
    {
        var owner = await RegisterAndLoginAsync();
        var project = await CreateProjectAsync("Release a tool", ["software", "leetcode"]);
        var secondProject = await CreateProjectAsync("Another effort", ["software"]);
        var projectId = project.GetProperty("id").GetGuid();
        var otherProjectId = secondProject.GetProperty("id").GetGuid();
        var softwarePath = $"/api/v1/projects/{projectId}/software/entries";
        var milestone = new { title = "First release", notes = "Ship the core", dueAt = DateTimeOffset.UtcNow.AddDays(3), status = "planned", schemaVersion = 1 };
        using var created = await _client!.PostAsJsonAsync($"{softwarePath}/milestone", milestone);
        Assert.Equal(HttpStatusCode.Created, created.StatusCode);
        var entry = await created.Content.ReadFromJsonAsync<JsonElement>();
        var entryId = entry.GetProperty("id").GetGuid();
        using var log = await _client!.PostAsJsonAsync($"{softwarePath}/dev_log", new { title = "Design decision", notes = "Use one application", schemaVersion = 1 });
        Assert.Equal(HttpStatusCode.Created, log.StatusCode);
        using var invalid = await _client!.PostAsJsonAsync($"{softwarePath}/dev_log", new { title = "Bad log", notes = "", schemaVersion = 99 });
        Assert.Equal(HttpStatusCode.BadRequest, invalid.StatusCode);
        using var wrongProject = await _client!.PutAsJsonAsync($"/api/v1/projects/{otherProjectId}/software/entries/{entryId}", milestone);
        Assert.Equal(HttpStatusCode.NotFound, wrongProject.StatusCode);
        Assert.Empty((await _client!.GetFromJsonAsync<JsonElement>($"/api/v1/projects/{otherProjectId}/software/entries")).EnumerateArray());
        Assert.Empty((await _client!.GetFromJsonAsync<JsonElement>($"/api/v1/entries?projectId={projectId}")).EnumerateArray());
        Assert.Empty((await _client!.GetFromJsonAsync<JsonElement>($"/api/v1/insights/weak-topics?projectId={projectId}")).EnumerateArray());
        using var noInterview = await _client!.GetAsync($"/api/v1/entries?projectId={otherProjectId}");
        Assert.Equal(HttpStatusCode.NotFound, noInterview.StatusCode);

        var problems = await _client!.GetFromJsonAsync<JsonElement>("/api/v1/problems");
        var attempt = new { problemBankId = problems[0].GetProperty("id").GetGuid(), timeSpentMinutes = 30, hintsUsed = 1, notes = "Keep my notes", reviewDueAt = DateTimeOffset.UtcNow.AddDays(1) };
        using var practice = await _client!.PostAsJsonAsync($"/api/v1/entries?projectId={projectId}", attempt);
        Assert.Equal(HttpStatusCode.Created, practice.StatusCode);
        Assert.Single((await _client!.GetFromJsonAsync<JsonElement>($"/api/v1/entries?projectId={projectId}")).EnumerateArray());
        Assert.Empty((await _client!.GetFromJsonAsync<JsonElement>("/api/v1/entries")).EnumerateArray());
        using var recommendation = await _client!.GetAsync($"/api/v1/problems/recommend?projectId={projectId}");
        Assert.Equal(HttpStatusCode.OK, recommendation.StatusCode);
        var overview = await _client!.GetFromJsonAsync<JsonElement>("/api/v1/overview");
        Assert.Equal(3, overview.GetProperty("recent").GetArrayLength());
        Assert.Equal(2, overview.GetProperty("upcoming").GetArrayLength());
        using var completed = await _client!.PutAsJsonAsync($"{softwarePath}/{entryId}", new { milestone.title, milestone.notes, milestone.dueAt, status = "done" });
        Assert.Equal(HttpStatusCode.OK, completed.StatusCode);
        Assert.Single((await _client!.GetFromJsonAsync<JsonElement>("/api/v1/overview")).GetProperty("upcoming").EnumerateArray());

        // A different account cannot discover or mutate the first account's work.
        await RegisterAndLoginAsync();
        foreach (var path in new[] { $"/api/v1/projects/{projectId}", softwarePath,
            $"/api/v1/entries?projectId={projectId}", $"/api/v1/insights/weak-topics?projectId={projectId}",
            $"/api/v1/problems/recommend?projectId={projectId}" })
        {
            using var response = await _client!.GetAsync(path);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        using var stolenWrite = await _client!.PostAsJsonAsync($"{softwarePath}/milestone", milestone);
        using var stolenEdit = await _client!.PutAsJsonAsync($"{softwarePath}/{entryId}", milestone);
        using var stolenAttempt = await _client!.PostAsJsonAsync($"/api/v1/entries?projectId={projectId}", attempt);
        using var stolenEnrollment = await _client!.PutAsJsonAsync($"/api/v1/projects/{projectId}/modules/software", new { enabled = false });
        using var stolenProject = await _client!.PutAsJsonAsync($"/api/v1/projects/{projectId}", new { name = "Stolen", isArchived = true });
        using var stolenPrompt = await _client!.PostAsJsonAsync($"/api/v1/system-design/generate?projectId={projectId}", new { level = "beginner" });
        Assert.All(new[] { stolenWrite, stolenEdit, stolenAttempt, stolenEnrollment, stolenProject, stolenPrompt }, r => Assert.Equal(HttpStatusCode.NotFound, r.StatusCode));
        Assert.Empty((await _client!.GetFromJsonAsync<JsonElement>("/api/v1/overview")).GetProperty("recent").EnumerateArray());
        Assert.DoesNotContain((await _client!.GetFromJsonAsync<JsonElement>("/api/v1/projects")).EnumerateArray(), p => p.GetProperty("id").GetGuid() == projectId);

        _client!.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", owner.AccessToken);
        using var disabled = await _client!.PutAsJsonAsync($"/api/v1/projects/{projectId}/modules/software", new { enabled = false });
        disabled.EnsureSuccessStatusCode();
        using var hidden = await _client!.GetAsync(softwarePath);
        Assert.Equal(HttpStatusCode.NotFound, hidden.StatusCode);
        using var blockedWrite = await _client!.PostAsJsonAsync($"{softwarePath}/milestone", milestone);
        Assert.Equal(HttpStatusCode.NotFound, blockedWrite.StatusCode);
        Assert.Single((await _client!.GetFromJsonAsync<JsonElement>("/api/v1/overview")).GetProperty("recent").EnumerateArray());
        using var enabled = await _client!.PutAsJsonAsync($"/api/v1/projects/{projectId}/modules/software", new { enabled = true });
        enabled.EnsureSuccessStatusCode();
        Assert.Equal(2, (await _client!.GetFromJsonAsync<JsonElement>(softwarePath)).GetArrayLength());
        using var archived = await _client!.PutAsJsonAsync($"/api/v1/projects/{projectId}", new { name = "Release a tool", isArchived = true });
        archived.EnsureSuccessStatusCode();
        using var archivedWrite = await _client!.PostAsJsonAsync($"{softwarePath}/milestone", milestone);
        Assert.Equal(HttpStatusCode.Conflict, archivedWrite.StatusCode);
        Assert.Empty((await _client!.GetFromJsonAsync<JsonElement>("/api/v1/overview")).GetProperty("recent").EnumerateArray());
        await using var db = CreateTestDb();
        var downgrade = await Assert.ThrowsAsync<PostgresException>(() =>
            db.GetService<IMigrator>().MigrateAsync("20260809064656_ImportCompanyTaggedLeetCodeCatalog"));
        Assert.Equal(PostgresErrorCodes.RaiseException, downgrade.SqlState);
        Assert.Equal(3, await db.Entries.CountAsync());
    }

    [Fact]
    public async Task MigrationPreservesLegacyPayloadsAndEnforcesOwnership()
    {
        await using var db = CreateTestDb();
        var migrator = db.GetService<IMigrator>();
        await migrator.MigrateAsync("20260809064656_ImportCompanyTaggedLeetCodeCatalog");
        var first = new AppUser { Id = Guid.NewGuid(), UserName = "legacy-first" };
        var second = new AppUser { Id = Guid.NewGuid(), UserName = "legacy-second" };
        db.Users.AddRange(first, second);
        db.UserModules.Add(new UserModule { UserId = second.Id, ModuleId = ModuleIds.Interview, Enabled = false, Config = "{\"goal\":5}" });
        await db.SaveChangesAsync();
        var problem = await db.ProblemBank.FirstAsync();
        var payload = JsonSerializer.Serialize(new LeetCodeEntryData(problem.Id, 30, 1, 3, problem.TopicTags, "Legacy notes survive"));
        var id = Guid.NewGuid();
        var logged = new DateTimeOffset(2026, 7, 25, 12, 0, 0, TimeSpan.Zero);
        var due = logged.AddDays(7);
        // First user intentionally lacks user_modules: old APIs permitted this.
        await db.Database.ExecuteSqlInterpolatedAsync($"INSERT INTO entries (id, user_id, module_id, entry_type, data, review_due_at, logged_at) VALUES ({id}, {first.Id}, {ModuleIds.Interview}, 'problem_attempt', {payload}::jsonb, {due}, {logged})");
        await migrator.MigrateAsync();
        db.ChangeTracker.Clear();
        var saved = await db.Entries.SingleAsync();
        Assert.Equal(id, saved.Id);
        Assert.Equal(logged, saved.LoggedAt);
        Assert.Equal(due, saved.ReviewDueAt);
        Assert.Equal(1, saved.SchemaVersion);
        Assert.True(JsonNode.DeepEquals(JsonNode.Parse(payload), JsonNode.Parse(saved.Data)));
        Assert.Equal("Legacy notes survive", JsonSerializer.Deserialize<LeetCodeEntryData>(saved.Data)!.Notes);
        Assert.Equal(JsonSerializer.Deserialize<LeetCodeEntryData>(payload)!.ProblemBankId, JsonSerializer.Deserialize<LeetCodeEntryData>(saved.Data)!.ProblemBankId);
        var project = await db.Projects.SingleAsync(p => p.UserId == first.Id);
        Assert.True(project.IsDefaultInterview);
        Assert.Equal(project.Id, saved.ProjectId);
        Assert.True((await db.ProjectModules.SingleAsync(m => m.UserId == first.Id)).Enabled);
        Assert.False((await db.ProjectModules.SingleAsync(m => m.UserId == second.Id)).Enabled);
        Assert.Equal(5, JsonDocument.Parse((await db.UserModules.SingleAsync()).Config).RootElement.GetProperty("goal").GetInt32());
        await db.Database.MigrateAsync();
        Assert.Equal(2, await db.Projects.CountAsync());
        db.Entries.Add(new Entry { UserId = second.Id, ProjectId = project.Id, ModuleId = ModuleIds.Interview, EntryType = "problem_attempt", Data = payload });
        var failure = await Assert.ThrowsAsync<DbUpdateException>(() => db.SaveChangesAsync());
        Assert.Equal(PostgresErrorCodes.ForeignKeyViolation, Assert.IsType<PostgresException>(failure.InnerException).SqlState);
    }

    private AppDbContext CreateTestDb() => new(new DbContextOptionsBuilder<AppDbContext>()
        .UseNpgsql($"{AdminConnection};Search Path={_schema}", p => p.MigrationsHistoryTable("__EFMigrationsHistory", _schema))
        .UseSnakeCaseNamingConvention().Options);

    private async Task<TokenResponse> RegisterAndLoginAsync()
    {
        var email = $"project-{Guid.NewGuid():N}@example.test";
        using var registration = await _client!.PostAsJsonAsync("/api/v1/auth/register", new { email, password = "Valid!Password123" });
        registration.EnsureSuccessStatusCode();
        var tokens = await LoginAsync(email, "Valid!Password123");
        _client!.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
        return tokens;
    }

    private async Task<JsonElement> CreateProjectAsync(string name, string[] modules)
    {
        using var response = await _client!.PostAsJsonAsync("/api/v1/projects", new { name, modules });
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        return await response.Content.ReadFromJsonAsync<JsonElement>();
    }
}
