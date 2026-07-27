using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modulog.Api.Data.Migrations;

/// <inheritdoc />
public partial class SeedAmazonInterviewCatalog : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "problem_bank",
            columns: new[] { "id", "created_at", "difficulty", "external_url", "title", "topic_tags" },
            values: new object[,]
            {
                    { new Guid("21000000-0000-0000-0000-000000000031"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/next-permutation/", "Next Permutation", new[] { "array", "two-pointers" } },
                    { new Guid("21000000-0000-0000-0000-000000000032"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/longest-valid-parentheses/", "Longest Valid Parentheses", new[] { "string", "dynamic-programming", "stack" } },
                    { new Guid("21000000-0000-0000-0000-000000000041"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/first-missing-positive/", "First Missing Positive", new[] { "array", "hash-table" } },
                    { new Guid("21000000-0000-0000-0000-000000000064"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/minimum-path-sum/", "Minimum Path Sum", new[] { "array", "dynamic-programming", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000075"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/sort-colors/", "Sort Colors", new[] { "array", "two-pointers", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000122"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/", "Best Time to Buy and Sell Stock II", new[] { "array", "dynamic-programming", "greedy" } },
                    { new Guid("21000000-0000-0000-0000-000000000140"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/word-break-ii/", "Word Break II", new[] { "array", "hash-table", "string", "dynamic-programming", "backtracking", "trie", "memoization" } },
                    { new Guid("21000000-0000-0000-0000-000000000148"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/sort-list/", "Sort List", new[] { "linked-list", "two-pointers", "divide-and-conquer", "sorting", "merge-sort" } },
                    { new Guid("21000000-0000-0000-0000-000000000224"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/basic-calculator/", "Basic Calculator", new[] { "math", "string", "stack", "recursion" } },
                    { new Guid("21000000-0000-0000-0000-000000000250"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/count-univalue-subtrees/", "Count Univalue Subtrees", new[] { "tree", "depth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000272"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/closest-binary-search-tree-value-ii/", "Closest Binary Search Tree Value II", new[] { "two-pointers", "stack", "tree", "depth-first-search", "binary-search-tree", "heap-priority-queue", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000273"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/integer-to-english-words/", "Integer to English Words", new[] { "math", "string", "recursion" } },
                    { new Guid("21000000-0000-0000-0000-000000000277"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/find-the-celebrity/", "Find the Celebrity", new[] { "two-pointers", "graph", "interactive" } },
                    { new Guid("21000000-0000-0000-0000-000000000316"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/remove-duplicate-letters/", "Remove Duplicate Letters", new[] { "string", "stack", "greedy", "monotonic-stack" } },
                    { new Guid("21000000-0000-0000-0000-000000000337"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/house-robber-iii/", "House Robber III", new[] { "dynamic-programming", "tree", "depth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000340"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/", "Longest Substring with At Most K Distinct Characters", new[] { "hash-table", "string", "sliding-window" } },
                    { new Guid("21000000-0000-0000-0000-000000000380"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/insert-delete-getrandom-o1/", "Insert Delete GetRandom O(1)", new[] { "array", "hash-table", "math", "design", "randomized" } },
                    { new Guid("21000000-0000-0000-0000-000000000381"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/", "Insert Delete GetRandom O(1) - Duplicates allowed", new[] { "array", "hash-table", "math", "design", "randomized" } },
                    { new Guid("21000000-0000-0000-0000-000000000399"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/evaluate-division/", "Evaluate Division", new[] { "array", "string", "depth-first-search", "breadth-first-search", "union-find", "graph", "shortest-path" } },
                    { new Guid("21000000-0000-0000-0000-000000000402"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/remove-k-digits/", "Remove K Digits", new[] { "string", "stack", "greedy", "monotonic-stack" } },
                    { new Guid("21000000-0000-0000-0000-000000000432"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/all-oone-data-structure/", "All O`one Data Structure", new[] { "hash-table", "linked-list", "design", "doubly-linked-list" } },
                    { new Guid("21000000-0000-0000-0000-000000000460"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/lfu-cache/", "LFU Cache", new[] { "hash-table", "linked-list", "design", "doubly-linked-list" } },
                    { new Guid("21000000-0000-0000-0000-000000000472"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/concatenated-words/", "Concatenated Words", new[] { "array", "string", "dynamic-programming", "depth-first-search", "trie", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000475"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/heaters/", "Heaters", new[] { "array", "two-pointers", "binary-search", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000528"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/random-pick-with-weight/", "Random Pick with Weight", new[] { "array", "math", "binary-search", "prefix-sum", "randomized" } },
                    { new Guid("21000000-0000-0000-0000-000000000662"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/maximum-width-of-binary-tree/", "Maximum Width of Binary Tree", new[] { "tree", "depth-first-search", "breadth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000692"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/top-k-frequent-words/", "Top K Frequent Words", new[] { "array", "hash-table", "string", "trie", "sorting", "heap-priority-queue", "bucket-sort", "counting" } },
                    { new Guid("21000000-0000-0000-0000-000000000716"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/max-stack/", "Max Stack", new[] { "linked-list", "stack", "design", "doubly-linked-list", "ordered-set" } },
                    { new Guid("21000000-0000-0000-0000-000000000735"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/asteroid-collision/", "Asteroid Collision", new[] { "array", "stack", "simulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000767"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/reorganize-string/", "Reorganize String", new[] { "hash-table", "string", "greedy", "sorting", "heap-priority-queue", "counting" } },
                    { new Guid("21000000-0000-0000-0000-000000000774"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/minimize-max-distance-to-gas-station/", "Minimize Max Distance to Gas Station", new[] { "array", "binary-search" } },
                    { new Guid("21000000-0000-0000-0000-000000000802"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/find-eventual-safe-states/", "Find Eventual Safe States", new[] { "depth-first-search", "breadth-first-search", "graph", "topological-sort" } },
                    { new Guid("21000000-0000-0000-0000-000000000815"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/bus-routes/", "Bus Routes", new[] { "array", "hash-table", "breadth-first-search" } },
                    { new Guid("21000000-0000-0000-0000-000000000827"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/making-a-large-island/", "Making A Large Island", new[] { "array", "depth-first-search", "breadth-first-search", "union-find", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000841"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/keys-and-rooms/", "Keys and Rooms", new[] { "depth-first-search", "breadth-first-search", "graph" } },
                    { new Guid("21000000-0000-0000-0000-000000000863"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/", "All Nodes Distance K in Binary Tree", new[] { "hash-table", "tree", "depth-first-search", "breadth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000881"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/boats-to-save-people/", "Boats to Save People", new[] { "array", "two-pointers", "greedy", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000901"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/online-stock-span/", "Online Stock Span", new[] { "stack", "design", "monotonic-stack", "data-stream" } },
                    { new Guid("21000000-0000-0000-0000-000000000904"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/fruit-into-baskets/", "Fruit Into Baskets", new[] { "array", "hash-table", "sliding-window" } },
                    { new Guid("21000000-0000-0000-0000-000000000911"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/online-election/", "Online Election", new[] { "array", "hash-table", "binary-search", "design" } },
                    { new Guid("21000000-0000-0000-0000-000000000934"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/shortest-bridge/", "Shortest Bridge", new[] { "array", "depth-first-search", "breadth-first-search", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000001004"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/max-consecutive-ones-iii/", "Max Consecutive Ones III", new[] { "array", "binary-search", "sliding-window", "prefix-sum" } },
                    { new Guid("21000000-0000-0000-0000-000000001186"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/maximum-subarray-sum-with-one-deletion/", "Maximum Subarray Sum with One Deletion", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000001197"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/minimum-knight-moves/", "Minimum Knight Moves", new[] { "breadth-first-search" } },
                    { new Guid("21000000-0000-0000-0000-000000001209"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string-ii/", "Remove All Adjacent Duplicates in String II", new[] { "string", "stack" } },
                    { new Guid("21000000-0000-0000-0000-000000001235"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/maximum-profit-in-job-scheduling/", "Maximum Profit in Job Scheduling", new[] { "array", "binary-search", "dynamic-programming", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000001277"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/count-square-submatrices-with-all-ones/", "Count Square Submatrices with All Ones", new[] { "array", "dynamic-programming", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000001297"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/maximum-number-of-occurrences-of-a-substring/", "Maximum Number of Occurrences of a Substring", new[] { "hash-table", "string", "sliding-window" } },
                    { new Guid("21000000-0000-0000-0000-000000001392"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/longest-happy-prefix/", "Longest Happy Prefix", new[] { "string", "rolling-hash", "string-matching", "hash-function" } },
                    { new Guid("21000000-0000-0000-0000-000000001423"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/", "Maximum Points You Can Obtain from Cards", new[] { "array", "sliding-window", "prefix-sum" } },
                    { new Guid("21000000-0000-0000-0000-000000001552"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/magnetic-force-between-two-balls/", "Magnetic Force Between Two Balls", new[] { "array", "binary-search", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000001559"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/detect-cycles-in-2d-grid/", "Detect Cycles in 2D Grid", new[] { "array", "depth-first-search", "breadth-first-search", "union-find", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000001658"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero/", "Minimum Operations to Reduce X to Zero", new[] { "array", "hash-table", "binary-search", "sliding-window", "prefix-sum" } },
                    { new Guid("21000000-0000-0000-0000-000000002001"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/number-of-pairs-of-interchangeable-rectangles/", "Number of Pairs of Interchangeable Rectangles", new[] { "array", "hash-table", "math", "counting", "number-theory" } },
                    { new Guid("21000000-0000-0000-0000-000000002080"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/range-frequency-queries/", "Range Frequency Queries", new[] { "array", "hash-table", "binary-search", "design", "segment-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000002115"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/find-all-possible-recipes-from-given-supplies/", "Find All Possible Recipes from Given Supplies", new[] { "array", "hash-table", "string", "graph", "topological-sort" } },
                    { new Guid("21000000-0000-0000-0000-000000002385"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/amount-of-time-for-binary-tree-to-be-infected/", "Amount of Time for Binary Tree to Be Infected", new[] { "hash-table", "tree", "depth-first-search", "breadth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000002517"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/maximum-tastiness-of-candy-basket/", "Maximum Tastiness of Candy Basket", new[] { "array", "binary-search", "greedy", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000002643"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/row-with-maximum-ones/", "Row With Maximum Ones", new[] { "array", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000003159"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/find-occurrences-of-an-element-in-an-array/", "Find Occurrences of an Element in an Array", new[] { "array", "hash-table" } },
                    { new Guid("21000000-0000-0000-0000-000000003193"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/count-the-number-of-inversions/", "Count the Number of Inversions", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000003388"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/count-beautiful-splits-in-an-array/", "Count Beautiful Splits in an Array", new[] { "array", "dynamic-programming" } }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000031"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000032"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000041"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000064"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000075"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000122"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000140"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000148"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000224"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000250"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000272"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000273"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000277"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000316"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000337"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000340"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000380"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000381"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000399"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000402"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000432"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000460"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000472"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000475"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000528"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000662"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000692"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000716"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000735"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000767"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000774"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000802"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000815"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000827"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000841"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000863"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000881"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000901"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000904"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000911"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000934"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001004"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001186"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001197"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001209"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001235"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001277"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001297"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001392"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001423"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001552"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001559"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001658"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002001"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002080"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002115"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002385"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002517"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002643"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000003159"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000003193"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000003388"));
    }
}
