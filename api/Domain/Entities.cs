using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Modulog.Api.Domain;

public sealed class AppUser : IdentityUser<Guid>
{
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

#pragma warning disable CA1716 // "Module" is the ubiquitous domain term and maps directly to the modules table.
public sealed class Module
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Key { get; set; }
    public required string Name { get; set; }
    public required string SchemaDefinition { get; set; }
}
#pragma warning restore CA1716

public sealed class UserModule
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid ModuleId { get; set; }
    public string Config { get; set; } = "{}";
    public bool Enabled { get; set; } = true;
}

public sealed class Entry
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid ModuleId { get; set; }
    public required string EntryType { get; set; }
    public required string Data { get; set; }
    public DateTimeOffset? ReviewDueAt { get; set; }
    public DateTimeOffset LoggedAt { get; set; } = DateTimeOffset.UtcNow;
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Difficulty { Easy, Medium, Hard }

public sealed class Problem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string ExternalUrl { get; set; }
    public string[] TopicTags { get; set; } = [];
    public string[] Companies { get; set; } = [];
    public Difficulty Difficulty { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

public sealed class RefreshToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public required string TokenHash { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset ExpiresAt { get; set; }
    public DateTimeOffset? RevokedAt { get; set; }
    public Guid? ReplacedByTokenId { get; set; }
}

public sealed record LeetCodeEntryData(
    [property: JsonPropertyName("problem_bank_id")] Guid ProblemBankId,
    [property: JsonPropertyName("time_spent_minutes")] int TimeSpentMinutes,
    [property: JsonPropertyName("hints_used")] int HintsUsed,
    [property: JsonPropertyName("self_rated_confidence")] int? SelfRatedConfidence,
    [property: JsonPropertyName("topic_tags")] string[] TopicTags);
