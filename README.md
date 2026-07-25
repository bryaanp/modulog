# modulog

A modular personal tracking dashboard with AI-powered insights.

## Tech Stack

| Layer      | Choice                                      |
|------------|----------------------------------------------|
| Backend    | .NET 8, minimal API                          |
| ORM        | EF Core (Npgsql)                             |
| Database   | PostgreSQL                                   |
| Frontend   | TypeScript, React (Vite)                     |
| Auth       | JWT (access + refresh tokens)                |
| AI         | OpenAI API                                   |
| Hosting    | Single Azure B1s VM (self-hosted Postgres)   |

## Architecture

The app is built around a **module-based schema** — each tracked domain (LeetCode,
and later home maintenance, pet health, etc.) is a `module`, and all user activity is
stored in a shared `entries` table with a JSONB payload shaped by that module's
schema. This keeps adding a new domain additive rather than a rewrite. See
`PROJECT_BRIEF.md` for the full data model and design rationale.

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (LTS) + npm
- [Docker](https://www.docker.com/) (for local PostgreSQL)
- An OpenAI API key

### Local Setup

1. **Clone the repo**
   ```bash
   git clone https://github.com/<your-username>/modulog.git
   cd modulog
   ```

2. **Start PostgreSQL locally**
   ```bash
   docker compose up -d
   ```

3. **Configure secrets** (backend)
   ```bash
   cd api
   dotnet user-secrets set "OpenAI:ApiKey" "<your-key>"
   dotnet user-secrets set "ConnectionStrings:Default" "Host=localhost;Database=modulog;Username=postgres;Password=postgres"
   ```

4. **Run database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Start the API**
   ```bash
   dotnet run
   ```

6. **Start the frontend**
   ```bash
   cd ../client
   npm install
   npm run dev
   ```

The API will be available at `http://localhost:5000` (or as configured) and the
frontend dev server at `http://localhost:5173`.

## Project Structure

```
modulog/
├── api/              # .NET 8 minimal API backend
├── client/           # React + TypeScript frontend (Vite)
├── docker-compose.yml
├── PROJECT_BRIEF.md  # full design spec and rationale
└── README.md
```

## Roadmap

- [x] LeetCode module (weak-topic detection, problem recommendations, system design generation)
- [ ] Home maintenance module
- [ ] Pet health module
- [ ] Cross-module AI insights/digest
- [ ] Native iOS client

## License

MIT License
