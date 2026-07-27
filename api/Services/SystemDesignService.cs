using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Modulog.Api.Data;

namespace Modulog.Api.Services;

public sealed class SystemDesignService(HttpClient http, IConfiguration configuration, AppDbContext db, WeakTopicScorer scorer)
{
    public async Task<object> GenerateAsync(Guid userId, string? requestedTopic, string? level, CancellationToken ct)
    {
        var apiKey = configuration["OpenAI:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("OpenAI is not configured.");
        }

        var entries = await db.Entries.AsNoTracking().Where(x => x.UserId == userId).ToListAsync(ct);
        var topics = scorer.Score(entries, DateTimeOffset.UtcNow).Take(3).Select(x => x.Topic);
        var context = requestedTopic ?? string.Join(", ", topics);
        var body = new
        {
            model = configuration["OpenAI:Model"] ?? "gpt-4.1-mini",
            input = $"Generate one concise system design interview scenario for a {level ?? "intermediate"} candidate. Weak-topic context: {context}. Return the scenario, requirements, constraints, and interviewer follow-ups. Do not provide a solution."
        };
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/responses");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        using var response = await http.SendAsync(request, ct);
        var json = await response.Content.ReadAsStringAsync(ct);
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("The AI provider could not generate a prompt.");
        }

        string text;

        try
        {
            text = ExtractOutputText(json);
        }
        catch (JsonException exception)
        {
            throw new InvalidOperationException(
                "The AI provider returned an invalid response.",
                exception);
        }

        return new
        {
            scenario = text,
            weakTopicContext = context
        };
    }

    private static string ExtractOutputText(string json)
    {
        using var document = JsonDocument.Parse(json);
        var root = document.RootElement;

        if (!root.TryGetProperty("output", out var outputItems) ||
            outputItems.ValueKind != JsonValueKind.Array)
        {
            throw new InvalidOperationException(
                "The AI provider response did not contain an output array.");
        }

        var textSegments = new List<string>();

        // Responses may include reasoning or tool-call items, so only process messages.
        foreach (var outputItem in outputItems.EnumerateArray())
        {
            if (!outputItem.TryGetProperty("type", out var itemType) ||
                itemType.ValueKind != JsonValueKind.String ||
                itemType.GetString() != "message")
            {
                continue;
            }

            if (!outputItem.TryGetProperty("content", out var contentItems) ||
                contentItems.ValueKind != JsonValueKind.Array)
            {
                continue;
            }

            foreach (var contentItem in contentItems.EnumerateArray())
            {
                if (!contentItem.TryGetProperty("type", out var contentType) ||
                    contentType.ValueKind != JsonValueKind.String ||
                    contentType.GetString() != "output_text")
                {
                    continue;
                }

                if (!contentItem.TryGetProperty("text", out var textElement) ||
                    textElement.ValueKind != JsonValueKind.String)
                {
                    continue;
                }

                var segment = textElement.GetString();

                if (!string.IsNullOrWhiteSpace(segment))
                {
                    textSegments.Add(segment);
                }
            }
        }

        if (textSegments.Count == 0)
        {
            throw new InvalidOperationException(
                "The AI provider response did not contain generated text.");
        }

        return string.Join(Environment.NewLine, textSegments);
    }
}
