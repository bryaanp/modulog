# Problem catalog

Modulog maintains one shared LeetCode problem catalog for all users. User-specific
attempt history remains in `entries`; catalog rows are not copied per user.

## NeetCode 150 seed data

`api/Data/NeetCodeCatalog.cs` contains the 150 model-managed seed rows. Each row
includes:

- the official LeetCode title and URL;
- the current LeetCode difficulty;
- the current LeetCode topic-tag slugs; and
- a deterministic database identifier.

The three rows created by the initial migration retain their original identifiers
so existing attempt foreign keys remain valid. Other identifiers are derived from
the LeetCode problem number. A unique database index on `external_url` prevents
the same problem from being added twice.

The catalog intentionally stores metadata and links, not copied problem
statements or solutions.

## Regenerating the catalog

Run the checked-in generator from the repository root:

```powershell
powershell.exe -NoProfile -ExecutionPolicy Bypass `
  -File .\scripts\Generate-NeetCodeCatalog.ps1
```

The generator:

1. reads the public NeetCode 150 membership transcription;
2. joins each problem number to current public LeetCode metadata;
3. rejects missing or duplicate identifiers and URLs;
4. verifies there are exactly 150 problems; and
5. verifies the expected distribution of 28 easy, 101 medium, and 21 hard
   problems.

After regeneration, review the diff and create a new EF Core migration. Do not
edit an already-applied migration to refresh catalog data.

The official list and category totals are published on the
[NeetCode 150 page](https://neetcode.io/practice/practice/neetcode150). The
generator's exact machine-readable sources are declared near the top of
`scripts/Generate-NeetCodeCatalog.ps1`.
