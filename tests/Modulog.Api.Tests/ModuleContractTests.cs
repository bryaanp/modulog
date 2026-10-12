using Modulog.Api.Domain;
using Modulog.Api.Modules.Software;
using Modulog.Api.Modules.Interview;

namespace Modulog.Api.Tests;

public sealed class ModuleContractTests
{
    [Theory]
    [InlineData("milestone", "planned", null, 1, true)]
    [InlineData("milestone", "done", "Shipped", 1, true)]
    [InlineData("milestone", "unknown", null, 1, false)]
    [InlineData("dev_log", null, "Decision recorded", 1, true)]
    [InlineData("dev_log", null, "", 1, false)]
    [InlineData("dev_log", "done", "Decision recorded", 1, false)]
    [InlineData("dev_log", null, "Decision recorded", 2, false)]
    [InlineData("other", null, "Decision recorded", 1, false)]
    public void SoftwareContractsRejectInvalidShapes(string type, string? status, string? notes, int version, bool expected)
    {
        Assert.Equal(expected, new SoftwareEntryRequest("Title", notes, null, status, version).IsValid(type));
    }

    [Fact]
    public void ScorerIgnoresOtherEntryTypesAndFutureVersions()
    {
        var entries = new[] {
            new Entry { EntryType = "dev_log", Data = "{\"notes\":\"Progress\"}" },
            new Entry { EntryType = "problem_attempt", SchemaVersion = 2, Data = "{}" }
        };
        Assert.Empty(new WeakTopicScorer().Score(entries, DateTimeOffset.UtcNow));
    }
}
