using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Modulog.Api.Data;
using Modulog.Api.Domain;
using Modulog.Api.Services;

namespace Modulog.Api.Modules.Software;

public sealed record SoftwareEntryData([property: JsonPropertyName("notes")] string? Notes);
public sealed record SoftwareEntryRequest(string? Title, string? Notes, DateTimeOffset? DueAt, string? Status, int SchemaVersion = 1)
{
    public bool IsValid(string type) => SchemaVersion == 1 && !string.IsNullOrWhiteSpace(Title)
        && Title.Trim().Length <= 200 && Notes?.Length is not > 20000
        && (type == "milestone" ? Status is "planned" or "in_progress" or "done"
            : type == "dev_log" && !string.IsNullOrWhiteSpace(Notes) && Status is null && DueAt is null);

    public void Apply(Entry entry)
    {
        entry.Title = Title!.Trim();
        entry.Data = JsonSerializer.Serialize(new SoftwareEntryData(Notes?.Trim()));
        entry.ReviewDueAt = DueAt?.ToUniversalTime();
        entry.Status = Status;
    }
}

public static class SoftwareEndpoints
{
    public static void MapSoftwareEndpoints(this RouteGroupBuilder api)
    {
        var group = api.MapGroup("/projects/{projectId:guid}/software").RequireAuthorization();
        group.MapGet("/entries", async (Guid projectId, ClaimsPrincipal principal, AppDbContext db,
            ProjectAccess access, CancellationToken ct) =>
        {
            if (await access.FindAsync(principal.UserId(), projectId, ModuleIds.Software, ct) is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(await db.Entries.AsNoTracking().Where(e => e.UserId == principal.UserId()
                && e.ProjectId == projectId && e.ModuleId == ModuleIds.Software).OrderByDescending(e => e.LoggedAt).ToListAsync(ct));
        });
        group.MapPost("/entries/{type}", async (Guid projectId, string type, SoftwareEntryRequest request,
            ClaimsPrincipal principal, AppDbContext db, ProjectAccess access, CancellationToken ct) =>
        {
            var project = await access.FindAsync(principal.UserId(), projectId, ModuleIds.Software, ct);
            if (project is null)
            {
                return Results.NotFound();
            }

            if (project.IsArchived)
            {
                return Results.Conflict(new { detail = "Restore this project before logging work." });
            }

            if (!request.IsValid(type))
            {
                return InvalidEntry();
            }

            var entry = new Entry { UserId = principal.UserId(), ProjectId = projectId,
                ModuleId = ModuleIds.Software, EntryType = type, Data = "{}" };
            request.Apply(entry);
            db.Entries.Add(entry);
            await db.SaveChangesAsync(ct);
            return Results.Created($"/api/v1/projects/{projectId}/software/entries/{entry.Id}", entry);
        });
        group.MapPut("/entries/{entryId:guid}", async (Guid projectId, Guid entryId, SoftwareEntryRequest request,
            ClaimsPrincipal principal, AppDbContext db, ProjectAccess access, CancellationToken ct) =>
        {
            var project = await access.FindAsync(principal.UserId(), projectId, ModuleIds.Software, ct);
            if (project is null)
            {
                return Results.NotFound();
            }

            if (project.IsArchived)
            {
                return Results.Conflict(new { detail = "Restore this project before editing work." });
            }

            var entry = await db.Entries.SingleOrDefaultAsync(e => e.Id == entryId && e.UserId == principal.UserId()
                && e.ProjectId == projectId && e.ModuleId == ModuleIds.Software, ct);
            if (entry is null)
            {
                return Results.NotFound();
            }

            if (!request.IsValid(entry.EntryType))
            {
                return InvalidEntry();
            }

            request.Apply(entry);
            await db.SaveChangesAsync(ct);
            return Results.Ok(entry);
        });
    }

    private static IResult InvalidEntry() => Results.ValidationProblem(new Dictionary<string, string[]>
    {
        ["entry"] = ["Use version 1 and a title up to 200 characters. Milestones need status planned, in_progress, or done. Development logs need notes and no due date or status. Notes are limited to 20,000 characters."]
    });
}
