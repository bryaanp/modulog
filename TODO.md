# Modulog backlog

This file tracks planned work that is outside the currently completed milestone.
The original requirements remain unchanged in `modulog-referenceprompt.md`.

## System-design practice

- [ ] Add an opt-in suggested-answer experience for generated system-design
      scenarios.
  - Show a **Generate suggested answer** button only after a scenario has been
    generated.
  - Decide during implementation whether the answer belongs inline on the
    existing system-design page or on a dedicated scenario page.
  - Generate the answer only after the user clicks the button so the initial
    interview exercise continues to hide the solution.
  - Add an authenticated `/api/v1/` backend endpoint; keep the OpenAI API key and
    provider request entirely server-side.
  - Include loading, retry, and safe error states in the React client.
  - Add backend parsing tests and frontend interaction tests for successful,
    empty, and failed provider responses.
