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
        if (string.IsNullOrWhiteSpace(apiKey)) throw new InvalidOperationException("OpenAI is not configured.");
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
        if (!response.IsSuccessStatusCode) throw new InvalidOperationException("The AI provider could not generate a prompt.");
        using var document = JsonDocument.Parse(json);
        var text = document.RootElement.TryGetProperty("output_text", out var output) ? output.GetString() : json;
        return new { scenario = text, weakTopicContext = context };
    }
}
