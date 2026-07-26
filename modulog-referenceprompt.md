# Project Brief: Personal Tracking Dashboard — LeetCode Module (Phase 1)

## Context

Build the first module of a personal, multi-domain tracking dashboard. The long-term
vision is a unified app that tracks LeetCode/interview prep, home maintenance, and
pet health records, with an AI layer that surfaces cross-domain insights. This phase
builds **only the LeetCode module**, but the schema and API must be designed so
future modules (home maintenance, pet health) can be added without breaking changes
or major refactors.

**Priorities, in order:** (1) minimal ongoing cost, (2) supports public signup using
industry-standard auth, while comfortably serving a small set of users (fewer than
10) at this stage, (3) clean enough architecture that adding a second module later
is additive, not a rewrite.

## Tech Stack

- **Backend:** .NET 8, minimal API style (not MVC controllers unless there's a strong reason)
- **ORM:** EF Core with PostgreSQL provider (Npgsql)
- **Database:** PostgreSQL (local Docker container for dev; self-hosted on a single
  Azure B1s VM in production — do not assume Azure Database for PostgreSQL Flexible
  Server, it's out of budget)
- **Frontend:** TypeScript, React (Vite, not Next.js — no SSR needed for this scale)
- **Auth:** JWT bearer tokens (short-lived access token + longer-lived refresh
  token), not cookie/session-based — this needs to work identically for a future
  native iOS client later
- **AI provider:** OpenAI API for weak-topic analysis and system design
  question generation
- **Hosting target (later, not this phase):** single Azure B1s VM running the API,
  Postgres, and a reverse proxy — no App Service, no managed Postgres, no Kubernetes
- **Local dev:** Docker Compose for Postgres only; API runs directly via `dotnet run`

## Cost Constraints (important — do not suggest managed services)

- No Azure Database for PostgreSQL, no App Service, no Azure Functions unless
  explicitly asked for later
- Prefer a free-tier-friendly, industry-standard auth approach for public signup
  (e.g. ASP.NET Core Identity issuing JWTs, or a provider with a generous free tier)
  over a paid third-party auth provider — avoid ongoing per-user auth costs at this
  scale
- Prefer solutions with zero or near-zero marginal cost as the user base grows to
  10 users

## Data Model

Design the schema to be **module-based** so LeetCode is the first module, not the
only one. Use these tables:

```sql
users
├── id (uuid, PK)
├── email (text, unique)
├── password_hash (text)
├── created_at (timestamptz)

modules
├── id (uuid, PK)
├── key (text, unique)              -- e.g. 'leetcode'
├── name (text)
├── schema_definition (jsonb)       -- describes expected fields for this module's entries

user_modules
├── id (uuid, PK)
├── user_id (uuid, FK -> users.id)
├── module_id (uuid, FK -> modules.id)
├── config (jsonb)                  -- per-user settings for this module
├── enabled (boolean, default true)

entries
├── id (uuid, PK)
├── user_id (uuid, FK -> users.id)
├── module_id (uuid, FK -> modules.id)
├── entry_type (text)               -- e.g. 'problem_attempt'
├── data (jsonb)                    -- shape defined by modules.schema_definition
├── review_due_at (timestamptz, nullable)
├── logged_at (timestamptz)

problem_bank
├── id (uuid, PK)
├── title (text)
├── external_url (text)             -- link to the actual LeetCode problem
├── topic_tags (text[])
├── difficulty (text)               -- 'easy' | 'medium' | 'hard'
├── created_at (timestamptz)
```

For this phase, seed the `modules` table with a single row: `key = 'leetcode'`.
`entries.data` for the LeetCode module should capture: `problem_bank_id`,
`time_spent_minutes`, `hints_used` (int), `self_rated_confidence` (1-5,
nullable), `topic_tags` (denormalized copy from problem_bank at time of entry,
so historical analysis isn't affected if tags change later).

## API Design

- Prefix all routes with `/api/v1/`
- Resource-oriented REST, not RPC-style
- Required endpoints for this phase:
  - `POST /api/v1/auth/register` — public signup using industry-standard auth
    practices (proper password hashing, e.g. via ASP.NET Core Identity; email
    verification recommended)
  - `POST /api/v1/auth/login` → returns access + refresh token pair
  - `POST /api/v1/auth/refresh`
  - `GET /api/v1/problems` — list/filter problem bank by topic/difficulty
  - `POST /api/v1/problems` — admin-only, add a problem to the bank
  - `POST /api/v1/entries` — log a practice attempt
  - `GET /api/v1/entries` — list the current user's entries, filterable by date range/topic
  - `GET /api/v1/insights/weak-topics` — returns weighted topic weaknesses based on the user's entry history
  - `GET /api/v1/problems/recommend` — returns a problem selection biased toward weak topics + spaced-repetition timing (see logic below)
  - `POST /api/v1/system-design/generate` — calls the AI provider to generate a system design interview prompt, optionally scoped to a weak topic

## Weak-Topic Detection Logic

Do **not** have the AI generate or invent problems. The AI's role is analysis and
selection, not content generation, for this part of the module:

1. Compute a weakness score per topic tag using signals from `entries`: recency of
   last attempt, time spent relative to difficulty, hints used, self-rated
   confidence, and spaced-repetition interval slippage (`review_due_at` vs now)
2. `GET /api/v1/insights/weak-topics` returns topics ranked by this score
3. `GET /api/v1/problems/recommend` selects from `problem_bank` biased toward the
   top weak topics, excluding problems logged in the last N days, and factoring in
   difficulty progression (don't always recommend hard problems just because a
   topic is weak)

Implement the scoring as a pure, testable function/service — not inline in the
endpoint handler — since this logic will likely need tuning.

## AI Integration — System Design Question Generation

Unlike LeetCode problems (curated, not generated), system design prompts are
open-ended and appropriate for direct AI generation:

- `POST /api/v1/system-design/generate` calls the OpenAI API with the user's
  current weak topics (if any) as context, and returns a generated scenario
  (e.g., "design a rate limiter") appropriate to their level
- Keep the AI call server-side only — never expose the OpenAI API key to the
  frontend
- Store the API key in an environment variable / appsettings secret, not committed
  to source control

## Non-Goals for This Phase

- Do not build the `subjects` table (needed later for pets/multi-property home
  tracking) — LeetCode doesn't need it, and we don't want to guess its shape before
  a second module needs it
- Do not build document upload/OCR/blob storage yet — this only matters once
  the pet/home modules are added
- Do not build a native iOS client yet — just make sure the API design (JWT,
  versioned routes, resource-oriented endpoints) doesn't preclude one later
- Public signup is in scope, but skip anything beyond industry-standard basics
  (e.g. no SSO/social login) for this phase

## Deliverables for This Session

1. .NET 8 minimal API project scaffolded with EF Core + Npgsql
2. Docker Compose file for local Postgres
3. EF Core migrations for the schema above
4. Auth endpoints (public register, login, refresh) with JWT issuance via
   industry-standard auth (e.g. ASP.NET Core Identity)
5. Problem bank CRUD (admin-only for writes)
6. Entry logging endpoint
7. Weak-topic scoring service + `/insights/weak-topics` endpoint
8. Problem recommendation endpoint using the scoring service
9. System design generation endpoint wired to the OpenAI API
10. A `README.md` documenting how to run locally (Docker Compose up, migrations,
    seed data for testing)

Ask clarifying questions before scaffolding if any of the above is ambiguous,
rather than guessing — this is a personal project I'll be maintaining long-term,
so I'd rather get the schema right early than refactor later.
