using Microsoft.EntityFrameworkCore;
using Modulog.Api.Data;
using Modulog.Api.Domain;

namespace Modulog.Api.Modules.Interview;

public static class InterviewEntryStore
{
    public static IQueryable<Entry> Query(AppDbContext db, Guid userId, Guid projectId) =>
        db.Entries.AsNoTracking().Where(x => x.UserId == userId && x.ProjectId == projectId
            && x.ModuleId == ModuleIds.Interview && x.EntryType == "problem_attempt" && x.SchemaVersion == 1);
}
