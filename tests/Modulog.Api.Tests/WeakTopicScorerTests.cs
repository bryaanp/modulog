using System.Text.Json;
using Modulog.Api.Domain;
using Modulog.Api.Services;

namespace Modulog.Api.Tests;

public sealed class WeakTopicScorerTests
{
    [Fact]
    public void Score_RanksLowConfidenceHintHeavyOverStrongRecentAttempt()
    {
        var now = new DateTimeOffset(2026, 7, 25, 12, 0, 0, TimeSpan.Zero);
        var weak = Entry("graph", 80, 3, 1, now.AddDays(-20), now.AddDays(-10));
        var strong = Entry("array", 10, 0, 5, now.AddDays(-1), now.AddDays(6));

        var result = new WeakTopicScorer().Score([strong, weak], now);

        Assert.Equal("graph", result[0].Topic);
        Assert.True(result[0].Score > result[1].Score);
    }

    [Fact]
    public void Score_AggregatesAttemptsPerTopic()
    {
        var now = DateTimeOffset.UtcNow;
        var result = new WeakTopicScorer().Score(
            [Entry("tree", 30, 1, 3, now.AddDays(-2), null), Entry("tree", 40, 2, 2, now.AddDays(-1), null)], now);
        Assert.Single(result);
        Assert.Equal(2, result[0].AttemptCount);
    }

    private static Entry Entry(string topic, int minutes, int hints, int confidence, DateTimeOffset logged, DateTimeOffset? due) =>
        new()
        {
            UserId = Guid.NewGuid(), ModuleId = Guid.NewGuid(), EntryType = "problem_attempt",
            Data = JsonSerializer.Serialize(new LeetCodeEntryData(Guid.NewGuid(), minutes, hints, confidence, [topic])),
            LoggedAt = logged, ReviewDueAt = due
        };
}
