# Modulog frontend

This directory contains the React and TypeScript client for Modulog's LeetCode
module. It is intentionally organized as a teaching-friendly production
application: features are separated clearly, dependencies have a specific job,
and non-obvious security behavior is documented.

Start with [`../docs/frontend-guide.md`](../docs/frontend-guide.md). It explains
the React mental model, walks through the source in reading order, and compares
the major architectural choices with alternatives.

## Run locally

Start PostgreSQL and the API from the repository root:

```powershell
docker compose up -d
dotnet run --project api
```

In a second terminal:

```powershell
cd client
npm.cmd install
npm.cmd run dev
```

Open the URL Vite prints, normally `http://localhost:5173`.

`npm.cmd` is used in these examples because some Windows PowerShell
configurations block the unsigned `npm.ps1` shim. It runs the same npm program
without changing the machine's execution policy.

## Quality commands

```powershell
npm.cmd run lint
npm.cmd run test
npm.cmd run format:check
npm.cmd run build
```

- `lint` finds suspicious or inconsistent JavaScript/React patterns.
- `test` runs component and utility tests once.
- `format:check` verifies consistent TypeScript, JSON, Markdown, and CSS layout.
- `build` type-checks every TypeScript file and creates an optimized production
  bundle in `dist`.

Copy `.env.example` to `.env.local` only when the API runs at a different
address. Values prefixed with `VITE_` are compiled into browser code and must
never contain secrets.
