using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Modulog.Api.Data;
using Modulog.Api.Domain;

namespace Modulog.Api.Services;

public sealed class RecommendationService(AppDbContext db, WeakTopicScorer scorer)
{
    public async Task<Problem?> RecommendAsync(Guid userId, int excludeDays, CancellationToken ct)
    {
        var entries = await db.Entries.AsNoTracking().Where(x => x.UserId == userId).ToListAsync(ct);
        var weaknesses = scorer.Score(entries, DateTimeOffset.UtcNow);
        var cutoff = DateTimeOffset.UtcNow.AddDays(-excludeDays);
        var recentIds = entries.Where(x => x.LoggedAt >= cutoff)
            .Select(x => JsonSerializer.Deserialize<LeetCodeEntryData>(x.Data)?.ProblemBankId)
            .OfType<Guid>().ToHashSet();
        var candidates = await db.ProblemBank.AsNoTracking().Where(x => !recentIds.Contains(x.Id)).ToListAsync(ct);
        if (candidates.Count == 0) return null;
        var weak = weaknesses.Take(3).Select((x, i) => (x.Topic, Weight: 3 - i)).ToDictionary(x => x.Topic, x => x.Weight);
        var attemptCount = entries.Count;
        var preferredDifficulty = attemptCount < 5 ? Difficulty.Easy : attemptCount < 20 ? Difficulty.Medium : Difficulty.Hard;
        return candidates.OrderByDescending(p => p.TopicTags.Sum(t => weak.GetValueOrDefault(t)))
            .ThenBy(p => Math.Abs((int)p.Difficulty - (int)preferredDifficulty))
            .ThenBy(p => p.Title).First();
    }
}
