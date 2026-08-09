# Problem catalog

Modulog maintains one shared LeetCode problem catalog for all users. User-specific
attempt history remains in `entries`; catalog rows are not copied per user.

## Seed data

`api/Data/LeetCodeCatalog.cs` contains 1,894 model-managed seed rows assembled
from:

- the NeetCode 150; and
- 95 problems from the linked legacy Amazon interview compilation, retained to
  avoid removing existing catalog rows; and
- the company-tagged problem lists in
  [`liquidslr/leetcode-company-wise-problems`](https://github.com/liquidslr/leetcode-company-wise-problems).

For every company, the generator reads `3. Six Months.csv`. If that file has
fewer than five valid problem rows, it reads `5. All.csv` instead. In the pinned
source snapshot this selects 6,526 company/problem associations: 67 companies
use six-month data and 403 use the all-history fallback. The result has 1,885
unique company-tagged problems; nine older catalog problems remain without a
current company association.

The union is deduplicated by LeetCode problem identifier and canonical URL. Each
row includes:

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
for multiple companies. Company labels come only from the selected CSVs; the
legacy Amazon list preserves catalog membership but no longer assigns an Amazon
label by itself. The checked-in
`catalog/leetcode-company-import-manifest.json` records the exact upstream commit,
selection rule, counts, and fallback-company list.

## Regenerating the catalog

Clone or update the source snapshot, then run the checked-in generator from the
repository root:

```powershell
git clone https://github.com/liquidslr/leetcode-company-wise-problems.git `
  .\.appdata\leetcode-company-wise-problems-source
powershell.exe -NoProfile -ExecutionPolicy Bypass `
  -File .\scripts\Generate-LeetCodeCatalog.ps1
```

If the source already exists, update it with `git pull`. You can also pass a
different checkout with `-CompanyRepositoryPath`.

The generator:

1. reads the public NeetCode 150 membership transcription and the checked-in
   legacy catalog slugs;
2. selects each company's six-month CSV or all-history fallback using the
   five-problem threshold;
3. joins every selected slug to public LeetCode metadata for canonical titles,
   difficulties, numeric identifiers, and topic tags;
4. accumulates all applicable company labels and deduplicates overlapping
   problems;
5. rejects missing CSVs, malformed URLs, missing metadata, and duplicate IDs or
   URLs; and
6. writes both the C# seed catalog and a source/import manifest.

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
