# Frontend dependency security notes

## React Router advisory exception

Reviewed: 2026-07-26

`npm audit` currently reports `GHSA-qwww-vcr4-c8h2` against React Router 7.18.1.
The advisory applies to React Server Components action handling. Modulog is a
browser-only Vite single-page application and does not enable React Server
Components, server actions, or React Router framework mode, so the affected
code path is not reachable in this client.

Version 7.18.1 is pinned exactly because it contains fixes for the other
published React Router advisories available at the time of review. Upgrade to
the first stable release outside the advisory range after confirming the
application build and tests.

This is a time-limited, usage-based exception—not a claim that the advisory can
be ignored in applications using React Router's server features.
