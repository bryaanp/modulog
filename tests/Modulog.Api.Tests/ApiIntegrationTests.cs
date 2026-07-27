using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Modulog.Api.Data;
using Npgsql;

namespace Modulog.Api.Tests;

public sealed class ApiIntegrationTests : IAsyncLifetime
{
    private const string AdminConnection =
        "Host=localhost;Port=5432;Database=modulog;Username=modulog;Password=modulog_dev";

    private readonly string _schema = $"test_{Guid.NewGuid():N}";
    private WebApplicationFactory<Program>? _factory;
    private HttpClient? _client;

    public async Task InitializeAsync()
    {
        await ExecuteAdminSqlAsync($"CREATE SCHEMA {_schema}");
        var testConnection = $"{AdminConnection};Search Path={_schema}";
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(
                testConnection,
                postgres => postgres.MigrationsHistoryTable("__EFMigrationsHistory", _schema))
            .UseSnakeCaseNamingConvention()
            .Options;
        await using (var db = new AppDbContext(options))
        {
            await db.Database.MigrateAsync();
        }

        _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Testing");
            builder.ConfigureAppConfiguration((_, configuration) =>
            {
                configuration.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["ConnectionStrings:Default"] = testConnection,
                    ["Cors:AllowedOrigins:0"] = "http://localhost:5173"
                });
            });
        });
        _client = _factory.CreateClient();
    }

    public async Task DisposeAsync()
    {
        _client?.Dispose();
        if (_factory is not null)
        {
            await _factory.DisposeAsync();
        }

        await ExecuteAdminSqlAsync($"DROP SCHEMA IF EXISTS {_schema} CASCADE");
    }

    [Fact]
    public async Task AuthenticationEntriesAndRefreshFlowUsesPostgreSql()
    {
        var email = $"integration-{Guid.NewGuid():N}@example.test";
        var password = "Valid!Password123";

        var registration = await _client!.PostAsJsonAsync(
            "/api/v1/auth/register",
            new { email, password });
        Assert.Equal(HttpStatusCode.Created, registration.StatusCode);

        var tokens = await LoginAsync(email, password);
        _client!.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

        var problems = await _client.GetFromJsonAsync<JsonElement>("/api/v1/problems");
        Assert.Equal(212, problems.GetArrayLength());
        Assert.Equal(
            212,
            problems
                .EnumerateArray()
                .Select(problem => problem.GetProperty("externalUrl").GetString())
                .Distinct()
                .Count());
        Assert.Contains(
            problems.EnumerateArray(),
            problem => problem.GetProperty("externalUrl").GetString()
                == "https://leetcode.com/problems/bus-routes/");
        Assert.Equal(
            95,
            problems
                .EnumerateArray()
                .Count(problem => problem
                    .GetProperty("companies")
                    .EnumerateArray()
                    .Any(company => company.GetString() == "Amazon")));

        var amazonProblems =
            await _client.GetFromJsonAsync<JsonElement>("/api/v1/problems?company=Amazon");
        Assert.Equal(95, amazonProblems.GetArrayLength());

        var problemId = problems[0].GetProperty("id").GetGuid();
        var entryResponse = await _client.PostAsJsonAsync(
            "/api/v1/entries",
            new
            {
                problemBankId = problemId,
                timeSpentMinutes = 20,
                hintsUsed = 1,
                selfRatedConfidence = 4
            });
        Assert.Equal(HttpStatusCode.Created, entryResponse.StatusCode);

        var entries = await _client.GetFromJsonAsync<JsonElement>("/api/v1/entries");
        Assert.Equal(1, entries.GetArrayLength());

        var refreshResponse = await _client.PostAsJsonAsync(
            "/api/v1/auth/refresh",
            new { refreshToken = tokens.RefreshToken });
        Assert.Equal(HttpStatusCode.OK, refreshResponse.StatusCode);

        var reuseResponse = await _client.PostAsJsonAsync(
            "/api/v1/auth/refresh",
            new { refreshToken = tokens.RefreshToken });
        Assert.Equal(HttpStatusCode.Unauthorized, reuseResponse.StatusCode);

        var concurrentTokens = await LoginAsync(email, password);
        var rotations = await Task.WhenAll(
            _client.PostAsJsonAsync(
                "/api/v1/auth/refresh",
                new { refreshToken = concurrentTokens.RefreshToken }),
            _client.PostAsJsonAsync(
                "/api/v1/auth/refresh",
                new { refreshToken = concurrentTokens.RefreshToken }));
        Assert.Equal(
            [HttpStatusCode.OK, HttpStatusCode.Unauthorized],
            rotations.Select(response => response.StatusCode).Order().ToArray());

        var logoutTokens = await LoginAsync(email, password);
        var logoutResponse = await _client.PostAsJsonAsync(
            "/api/v1/auth/logout",
            new { refreshToken = logoutTokens.RefreshToken });
        Assert.Equal(HttpStatusCode.NoContent, logoutResponse.StatusCode);

        var loggedOutRefreshResponse = await _client.PostAsJsonAsync(
            "/api/v1/auth/refresh",
            new { refreshToken = logoutTokens.RefreshToken });
        Assert.Equal(HttpStatusCode.Unauthorized, loggedOutRefreshResponse.StatusCode);
    }

    [Fact]
    public async Task CorsPreflightAllowsConfiguredFrontend()
    {
        using var request = new HttpRequestMessage(HttpMethod.Options, "/api/v1/auth/login");
        request.Headers.Add("Origin", "http://localhost:5173");
        request.Headers.Add("Access-Control-Request-Method", "POST");

        using var response = await _client!.SendAsync(request);

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.Equal(
            "http://localhost:5173",
            response.Headers.GetValues("Access-Control-Allow-Origin").Single());
    }

    private async Task<TokenResponse> LoginAsync(string email, string password)
    {
        using var response = await _client!.PostAsJsonAsync(
            "/api/v1/auth/login",
            new { email, password });
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<TokenResponse>())!;
    }

    private static async Task ExecuteAdminSqlAsync(string sql)
    {
        await using var connection = new NpgsqlConnection(AdminConnection);
        await connection.OpenAsync();
        await using var command = new NpgsqlCommand(sql, connection);
        await command.ExecuteNonQueryAsync();
    }

    private sealed record TokenResponse(string AccessToken, string RefreshToken);
}
