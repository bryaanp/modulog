# Modulog

Modulog is a modular personal tracking API. Phase 1 implements the LeetCode/interview-prep module; the React client is intentionally deferred to the next milestone. The original requirements remain in [`modulog-referenceprompt.md`](modulog-referenceprompt.md).

## Phase 1 architecture

- .NET 8 minimal API, EF Core 8, and PostgreSQL 16
- ASP.NET Core Identity with its user entity mapped to `users`; Identity's required role, claim, login, and token tables are retained
- 15-minute JWT access tokens and rotating 30-day refresh tokens. Only SHA-256 refresh-token hashes are persisted
- Email confirmation token generation/confirmation is wired, but email delivery is deferred and unverified users may log in
- Module-oriented `modules`, `user_modules`, and `entries` tables; LeetCode entry payloads are JSONB
- Curated problem bank, deterministic weak-topic scoring, recommendations, and server-side OpenAI Responses API integration

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Docker Desktop (or another Docker Engine with Compose)
- Optional: an OpenAI API key for system-design prompt generation

If a newly installed Windows tool is not found, restart the terminal or use `C:\Program Files\dotnet\dotnet.exe` directly.

## Run locally

```powershell
docker compose up -d
dotnet tool restore
dotnet ef database update --project api
dotnet run --project api
```

Swagger UI is available at the URL printed by `dotnet run`, under `/swagger`. The health check is `/health`; every application route begins with `/api/v1/`.

Development database settings are committed for local use only. Configure secrets without committing them:

```powershell
dotnet user-secrets --project api set "Jwt:SigningKey" "<at-least-32-random-bytes>"
dotnet user-secrets --project api set "OpenAI:ApiKey" "<your-key>"
```

Production must override the connection string and JWT key using environment variables such as `ConnectionStrings__Default` and `Jwt__SigningKey`.

## Seed data and admin access

The initial migration seeds the `leetcode` module plus Two Sum, Valid Parentheses, and Longest Substring Without Repeating Characters. Public registration creates the user's `user_modules` row automatically.

Problem writes require the `admin` role. Phase 1 deliberately does not expose a public role-management endpoint. To bootstrap the first administrator, register normally and assign the role through a trusted maintenance script or database operation; never let clients select their own role.

## Authentication

1. `POST /api/v1/auth/register`
2. `POST /api/v1/auth/login`
3. Send `Authorization: Bearer <accessToken>`.
4. Rotate the refresh token with `POST /api/v1/auth/refresh`. A used token is revoked immediately.

Email infrastructure endpoints are `/api/v1/auth/email-verification-token` and `/api/v1/auth/verify-email`. The first returns a token directly only because delivery is not configured yet; replace that response with an email sender before public production use.

## Tests

```powershell
dotnet test Modulog.sln
```

The unit tests cover the pure weak-topic scoring service. API integration tests against PostgreSQL are a recommended follow-up once the local Docker daemon is available.

## API summary

- Auth: register, login, refresh, email verification
- Problems: list/filter, get, recommend; admin create/update/delete
- Entries: create and list with date/topic filters
- Insights: ranked weak topics
- System design: generate a prompt through OpenAI

The scoring weights are centralized in `WeakTopicScorer` so they can be tuned without endpoint changes.
