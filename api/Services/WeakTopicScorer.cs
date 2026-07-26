using System.Text.Json;
using Modulog.Api.Domain;

namespace Modulog.Api.Services;

public sealed record TopicWeakness(string Topic, double Score, int AttemptCount, DateTimeOffset LastAttemptAt);

public sealed class WeakTopicScorer
{
    public IReadOnlyList<TopicWeakness> Score(IEnumerable<Entry> entries, DateTimeOffset now)
    {
        var signals = entries.Select(e => (Entry: e, Data: JsonSerializer.Deserialize<LeetCodeEntryData>(e.Data)))
            .Where(x => x.Data is not null)
            .SelectMany(x => x.Data!.TopicTags.Select(topic => (Topic: topic, x.Entry, x.Data)));
        return signals.GroupBy(x => x.Topic, StringComparer.OrdinalIgnoreCase)
            .Select(g =>
            {
                var attempts = g.ToList();
                var last = attempts.Max(x => x.Entry.LoggedAt);
                var average = attempts.Average(x =>
                {
                    var recency = Math.Min(2, Math.Max(0, (now - x.Entry.LoggedAt).TotalDays) / 14d);
                    var time = Math.Min(2, x.Data.TimeSpentMinutes / 45d);
                    var hints = Math.Min(2, x.Data.HintsUsed * .5);
                    var confidence = x.Data.SelfRatedConfidence is { } c ? (5 - c) / 2d : .5;
                    var slippage = x.Entry.ReviewDueAt is { } due && due < now ? Math.Min(2, (now - due).TotalDays / 7d) : 0;
                    return recency * .2 + time * .25 + hints * .2 + confidence * .2 + slippage * .15;
                });
                return new TopicWeakness(g.Key.ToLowerInvariant(), Math.Round(average, 3), attempts.Count, last);
            })
            .OrderByDescending(x => x.Score).ThenBy(x => x.Topic).ToList();
    }
}
