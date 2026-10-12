using Microsoft.EntityFrameworkCore;
using Modulog.Api.Data;
using Modulog.Api.Domain;

namespace Modulog.Api.Services;

public sealed class ProjectAccess(AppDbContext db)
{
    // Omitted project IDs on v1 interview routes deliberately select the migrated
    // default project, never aggregate unrelated projects or modules.
    public Task<Project?> FindAsync(Guid userId, Guid? projectId, Guid moduleId, CancellationToken ct) =>
        db.Projects.SingleOrDefaultAsync(p => p.UserId == userId
            && (projectId == null ? p.IsDefaultInterview : p.Id == projectId)
            && db.ProjectModules.Any(m => m.UserId == userId && m.ProjectId == p.Id
                && m.ModuleId == moduleId && m.Enabled), ct);

    public static Project AddDefaultInterview(AppDbContext db, Guid userId)
    {
        var project = new Project { UserId = userId, Name = "Interview preparation", IsDefaultInterview = true };
        db.Projects.Add(project);
        db.ProjectModules.Add(new ProjectModule { UserId = userId, ProjectId = project.Id, ModuleId = ModuleIds.Interview });
        return project;
    }
}
