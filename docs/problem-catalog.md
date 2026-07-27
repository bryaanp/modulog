# Problem catalog

Modulog maintains one shared LeetCode problem catalog for all users. User-specific
attempt history remains in `entries`; catalog rows are not copied per user.

## Seed data

`api/Data/LeetCodeCatalog.cs` contains 212 model-managed seed rows assembled from:

- the NeetCode 150; and
- 95 problems from the linked Amazon interview compilation, 33 of which overlap
  with the NeetCode 150.

The union adds 62 problems and is deduplicated by LeetCode problem identifier and
canonical URL. Each row includes:

- the official LeetCode title and URL;
- the current LeetCode difficulty;
- the current LeetCode topic-tag slugs;
- zero or more company associations derived from the catalog source; and
- a deterministic database identifier.

The three rows created by the initial migration retain their original identifiers
so existing attempt foreign keys remain valid. Other identifiers are derived from
the LeetCode problem number. A unique database index on `external_url` prevents
the same problem from being added twice.

The catalog intentionally stores metadata and links, not copied problem
statements or solutions.

Company associations are stored as an array because the same problem may appear
in compilations for multiple companies. The 95 problems in the Amazon compilation
are labeled `Amazon`, including the 33 problems that already belonged to the
NeetCode 150. These labels record source association; they are not represented as
official LeetCode company metadata.

## Regenerating the catalog

Run the checked-in generator from the repository root:

```powershell
powershell.exe -NoProfile -ExecutionPolicy Bypass `
  -File .\scripts\Generate-LeetCodeCatalog.ps1
```

The generator:

1. reads the public NeetCode 150 membership transcription;
2. reads the checked-in snapshot of the Amazon compilation's LeetCode slugs;
3. joins both sources to current public LeetCode metadata;
4. deduplicates overlapping problems by their numeric LeetCode identifier;
5. rejects missing or duplicate identifiers and URLs; and
6. verifies the expected source and combined counts.

After regeneration, review the diff and create a new EF Core migration. Do not
edit an already-applied migration to refresh catalog data.

The NeetCode list and category totals are published on the
[NeetCode 150 page](https://neetcode.io/practice/practice/neetcode150). The
additional source is the
[Amazon last-six-months DSA compilation](https://www.reddit.com/r/leetcode/comments/1pq3c90/amazon_last_6_months_dsa_question_compilation/).
Its 95 canonical slugs are pinned in
`catalog/amazon-last-six-months-reddit.txt` so builds remain reproducible even if
the post changes or becomes unavailable. The generator's remote metadata sources
are declared near the top of `scripts/Generate-LeetCodeCatalog.ps1`.
