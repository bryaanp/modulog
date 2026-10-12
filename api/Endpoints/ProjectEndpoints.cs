using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Modulog.Api.Data;
using Modulog.Api.Domain;

namespace Modulog.Api.Endpoints;

public sealed record ProjectRequest(string? Name, string? Description, string[]? Modules);
public sealed record UpdateProjectRequest(string? Name, string? Description, bool IsArchived);
public sealed record EnrollmentRequest(bool Enabled);

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints(this RouteGroupBuilder api)
    {
        var projects = api.MapGroup("/projects").RequireAuthorization();
        projects.MapGet("/", async (ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
            Results.Ok(await db.Projects.AsNoTracking().Where(p => p.UserId == principal.UserId())
                .OrderBy(p => p.IsArchived).ThenBy(p => p.Name).ToListAsync(ct)));

        projects.MapPost("/", async (ProjectRequest request, ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
        {
            if (!ValidProject(request.Name, request.Description) || request.Modules is not { Length: > 0 }
                || request.Modules.Any(m => m is not ("leetcode" or "software")))
            {
                return InvalidProject();
            }

            var project = new Project { UserId = principal.UserId(), Name = request.Name!.Trim(), Description = request.Description?.Trim() };
            db.Projects.Add(project);
            foreach (var key in request.Modules.Distinct(StringComparer.Ordinal))
            {
                db.ProjectModules.Add(new ProjectModule { UserId = project.UserId, ProjectId = project.Id,
                    ModuleId = key == "leetcode" ? ModuleIds.Interview : ModuleIds.Software });
            }

            await db.SaveChangesAsync(ct);
            return Results.Created($"/api/v1/projects/{project.Id}", project);
        });
        projects.MapGet("/{projectId:guid}", async (Guid projectId, ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
        {
            var project = await db.Projects.AsNoTracking().SingleOrDefaultAsync(p => p.Id == projectId && p.UserId == principal.UserId(), ct);
            if (project is null)
            {
                return Results.NotFound();
            }

            var modules = await (from enrollment in db.ProjectModules.AsNoTracking()
                join module in db.Modules on enrollment.ModuleId equals module.Id
                where enrollment.UserId == principal.UserId() && enrollment.ProjectId == projectId
                select new { module.Key, module.Name, enrollment.Enabled }).ToListAsync(ct);
            return Results.Ok(new { project, modules });
        });
        projects.MapPut("/{projectId:guid}", async (Guid projectId, UpdateProjectRequest request, ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
        {
            var project = await db.Projects.SingleOrDefaultAsync(p => p.Id == projectId && p.UserId == principal.UserId(), ct);
            if (project is null)
            {
                return Results.NotFound();
            }

            if (!ValidProject(request.Name, request.Description))
            {
                return InvalidProject();
            }

            project.Name = request.Name!.Trim();
            project.Description = request.Description?.Trim();
            project.IsArchived = request.IsArchived;
            await db.SaveChangesAsync(ct);
            return Results.Ok(project);
        });
        projects.MapPut("/{projectId:guid}/modules/{key}", async (Guid projectId, string key, EnrollmentRequest request,
            ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
        {
            var project = await db.Projects.SingleOrDefaultAsync(p => p.Id == projectId && p.UserId == principal.UserId(), ct);
            if (project is null || key is not ("leetcode" or "software"))
            {
                return Results.NotFound();
            }

            var moduleId = key == "leetcode" ? ModuleIds.Interview : ModuleIds.Software;
            var enrollment = await db.ProjectModules.SingleOrDefaultAsync(m => m.UserId == principal.UserId()
                && m.ProjectId == projectId && m.ModuleId == moduleId, ct);
            if (enrollment is null)
            {
                enrollment = new ProjectModule { UserId = principal.UserId(), ProjectId = projectId, ModuleId = moduleId };
                db.ProjectModules.Add(enrollment);
            }
            enrollment.Enabled = request.Enabled;
            await db.SaveChangesAsync(ct);
            return Results.Ok(enrollment);
        });

        api.MapGet("/overview", async (ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
        {
            var userId = principal.UserId();
            var activeProjects = db.Projects.AsNoTracking().Where(p => p.UserId == userId && !p.IsArchived);
            var entries = db.Entries.AsNoTracking().Where(e => e.UserId == userId
                && activeProjects.Any(p => p.Id == e.ProjectId)
                && db.ProjectModules.Any(m => m.UserId == userId && m.ProjectId == e.ProjectId && m.ModuleId == e.ModuleId && m.Enabled));
            var summaries = await (from enrollment in db.ProjectModules.AsNoTracking()
                join project in activeProjects on enrollment.ProjectId equals project.Id
                join module in db.Modules on enrollment.ModuleId equals module.Id
                where enrollment.UserId == userId && enrollment.Enabled
                select new
                {
                    ProjectId = project.Id, ProjectName = project.Name, ModuleKey = module.Key, ModuleName = module.Name,
                    EntryCount = entries.Count(e => e.ProjectId == project.Id && e.ModuleId == module.Id),
                    OpenMilestones = entries.Count(e => e.ProjectId == project.Id && e.ModuleId == module.Id && e.EntryType == "milestone" && e.Status != "done")
                }).ToListAsync(ct);
            var upcoming = await entries.Where(e => e.ReviewDueAt != null && e.Status != "done")
                .OrderBy(e => e.ReviewDueAt).ThenBy(e => e.Id).Take(12).ToListAsync(ct);
            var recent = await entries.OrderByDescending(e => e.LoggedAt).ThenBy(e => e.Id).Take(12).ToListAsync(ct);
            return Results.Ok(new { projects = await activeProjects.OrderBy(p => p.Name).ToListAsync(ct), summaries, upcoming, recent });
        }).RequireAuthorization();
    }

    private static bool ValidProject(string? name, string? description) =>
        !string.IsNullOrWhiteSpace(name) && name.Trim().Length <= 160 && description?.Length is not > 4000;

    private static IResult InvalidProject() => Results.ValidationProblem(new Dictionary<string, string[]>
    { ["project"] = ["Provide a name up to 160 characters, a description up to 4,000 characters, and at least one supported module (leetcode or software)."] });
}
