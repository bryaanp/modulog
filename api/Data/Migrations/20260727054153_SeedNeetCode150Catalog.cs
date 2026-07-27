using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modulog.Api.Data.Migrations;

/// <inheritdoc />
public partial class SeedNeetCode150Catalog : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
            column: "topic_tags",
            value: new[] { "string", "stack" });

        migrationBuilder.InsertData(
            table: "problem_bank",
            columns: ["id", "created_at", "difficulty", "external_url", "title", "topic_tags"],
            values: new object[,]
            {
                    { new Guid("21000000-0000-0000-0000-000000000002"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/add-two-numbers/", "Add Two Numbers", new[] { "linked-list", "math", "recursion" } },
                    { new Guid("21000000-0000-0000-0000-000000000004"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/median-of-two-sorted-arrays/", "Median of Two Sorted Arrays", new[] { "array", "binary-search", "divide-and-conquer" } },
                    { new Guid("21000000-0000-0000-0000-000000000005"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/longest-palindromic-substring/", "Longest Palindromic Substring", new[] { "two-pointers", "string", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000007"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/reverse-integer/", "Reverse Integer", new[] { "math" } },
                    { new Guid("21000000-0000-0000-0000-000000000010"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/regular-expression-matching/", "Regular Expression Matching", new[] { "string", "dynamic-programming", "recursion" } },
                    { new Guid("21000000-0000-0000-0000-000000000011"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/container-with-most-water/", "Container With Most Water", new[] { "array", "two-pointers", "greedy" } },
                    { new Guid("21000000-0000-0000-0000-000000000015"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/3sum/", "3Sum", new[] { "array", "two-pointers", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000017"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/letter-combinations-of-a-phone-number/", "Letter Combinations of a Phone Number", new[] { "hash-table", "string", "backtracking" } },
                    { new Guid("21000000-0000-0000-0000-000000000019"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/remove-nth-node-from-end-of-list/", "Remove Nth Node From End of List", new[] { "linked-list", "two-pointers" } },
                    { new Guid("21000000-0000-0000-0000-000000000021"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/merge-two-sorted-lists/", "Merge Two Sorted Lists", new[] { "linked-list", "recursion" } },
                    { new Guid("21000000-0000-0000-0000-000000000022"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/generate-parentheses/", "Generate Parentheses", new[] { "string", "dynamic-programming", "backtracking" } },
                    { new Guid("21000000-0000-0000-0000-000000000023"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/merge-k-sorted-lists/", "Merge k Sorted Lists", new[] { "linked-list", "divide-and-conquer", "heap-priority-queue", "merge-sort" } },
                    { new Guid("21000000-0000-0000-0000-000000000025"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/reverse-nodes-in-k-group/", "Reverse Nodes in k-Group", new[] { "linked-list", "recursion" } },
                    { new Guid("21000000-0000-0000-0000-000000000033"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/search-in-rotated-sorted-array/", "Search in Rotated Sorted Array", new[] { "array", "binary-search" } },
                    { new Guid("21000000-0000-0000-0000-000000000036"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/valid-sudoku/", "Valid Sudoku", new[] { "array", "hash-table", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000039"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/combination-sum/", "Combination Sum", new[] { "array", "backtracking" } },
                    { new Guid("21000000-0000-0000-0000-000000000040"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/combination-sum-ii/", "Combination Sum II", new[] { "array", "backtracking" } },
                    { new Guid("21000000-0000-0000-0000-000000000042"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/trapping-rain-water/", "Trapping Rain Water", new[] { "array", "two-pointers", "dynamic-programming", "stack", "monotonic-stack" } },
                    { new Guid("21000000-0000-0000-0000-000000000043"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/multiply-strings/", "Multiply Strings", new[] { "math", "string", "simulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000045"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/jump-game-ii/", "Jump Game II", new[] { "array", "dynamic-programming", "greedy" } },
                    { new Guid("21000000-0000-0000-0000-000000000046"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/permutations/", "Permutations", new[] { "array", "backtracking" } },
                    { new Guid("21000000-0000-0000-0000-000000000048"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/rotate-image/", "Rotate Image", new[] { "array", "math", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000049"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/group-anagrams/", "Group Anagrams", new[] { "array", "hash-table", "string", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000050"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/powx-n/", "Pow(x, n)", new[] { "math", "recursion" } },
                    { new Guid("21000000-0000-0000-0000-000000000051"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/n-queens/", "N-Queens", new[] { "array", "backtracking" } },
                    { new Guid("21000000-0000-0000-0000-000000000053"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/maximum-subarray/", "Maximum Subarray", new[] { "array", "divide-and-conquer", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000054"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/spiral-matrix/", "Spiral Matrix", new[] { "array", "matrix", "simulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000055"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/jump-game/", "Jump Game", new[] { "array", "dynamic-programming", "greedy" } },
                    { new Guid("21000000-0000-0000-0000-000000000056"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/merge-intervals/", "Merge Intervals", new[] { "array", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000057"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/insert-interval/", "Insert Interval", new[] { "array" } },
                    { new Guid("21000000-0000-0000-0000-000000000062"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/unique-paths/", "Unique Paths", new[] { "math", "dynamic-programming", "combinatorics" } },
                    { new Guid("21000000-0000-0000-0000-000000000066"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/plus-one/", "Plus One", new[] { "array", "math" } },
                    { new Guid("21000000-0000-0000-0000-000000000070"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/climbing-stairs/", "Climbing Stairs", new[] { "math", "dynamic-programming", "memoization" } },
                    { new Guid("21000000-0000-0000-0000-000000000072"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/edit-distance/", "Edit Distance", new[] { "string", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000073"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/set-matrix-zeroes/", "Set Matrix Zeroes", new[] { "array", "hash-table", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000074"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/search-a-2d-matrix/", "Search a 2D Matrix", new[] { "array", "binary-search", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000076"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/minimum-window-substring/", "Minimum Window Substring", new[] { "hash-table", "string", "sliding-window" } },
                    { new Guid("21000000-0000-0000-0000-000000000078"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/subsets/", "Subsets", new[] { "array", "backtracking", "bit-manipulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000079"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/word-search/", "Word Search", new[] { "array", "string", "backtracking", "depth-first-search", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000084"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/largest-rectangle-in-histogram/", "Largest Rectangle in Histogram", new[] { "array", "stack", "monotonic-stack" } },
                    { new Guid("21000000-0000-0000-0000-000000000090"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/subsets-ii/", "Subsets II", new[] { "array", "backtracking", "bit-manipulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000091"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/decode-ways/", "Decode Ways", new[] { "string", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000097"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/interleaving-string/", "Interleaving String", new[] { "string", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000098"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/validate-binary-search-tree/", "Validate Binary Search Tree", new[] { "tree", "depth-first-search", "binary-search-tree", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000100"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/same-tree/", "Same Tree", new[] { "tree", "depth-first-search", "breadth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000102"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/binary-tree-level-order-traversal/", "Binary Tree Level Order Traversal", new[] { "tree", "breadth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000104"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/maximum-depth-of-binary-tree/", "Maximum Depth of Binary Tree", new[] { "tree", "depth-first-search", "breadth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000105"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/", "Construct Binary Tree from Preorder and Inorder Traversal", new[] { "array", "hash-table", "divide-and-conquer", "tree", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000110"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/balanced-binary-tree/", "Balanced Binary Tree", new[] { "tree", "depth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000115"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/distinct-subsequences/", "Distinct Subsequences", new[] { "string", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000121"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/best-time-to-buy-and-sell-stock/", "Best Time to Buy and Sell Stock", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000124"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/binary-tree-maximum-path-sum/", "Binary Tree Maximum Path Sum", new[] { "dynamic-programming", "tree", "depth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000125"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/valid-palindrome/", "Valid Palindrome", new[] { "two-pointers", "string" } },
                    { new Guid("21000000-0000-0000-0000-000000000127"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/word-ladder/", "Word Ladder", new[] { "hash-table", "string", "breadth-first-search" } },
                    { new Guid("21000000-0000-0000-0000-000000000128"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/longest-consecutive-sequence/", "Longest Consecutive Sequence", new[] { "array", "hash-table", "union-find" } },
                    { new Guid("21000000-0000-0000-0000-000000000130"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/surrounded-regions/", "Surrounded Regions", new[] { "array", "depth-first-search", "breadth-first-search", "union-find", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000131"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/palindrome-partitioning/", "Palindrome Partitioning", new[] { "string", "dynamic-programming", "backtracking" } },
                    { new Guid("21000000-0000-0000-0000-000000000133"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/clone-graph/", "Clone Graph", new[] { "hash-table", "depth-first-search", "breadth-first-search", "graph" } },
                    { new Guid("21000000-0000-0000-0000-000000000134"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/gas-station/", "Gas Station", new[] { "array", "greedy" } },
                    { new Guid("21000000-0000-0000-0000-000000000136"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/single-number/", "Single Number", new[] { "array", "bit-manipulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000138"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/copy-list-with-random-pointer/", "Copy List with Random Pointer", new[] { "hash-table", "linked-list" } },
                    { new Guid("21000000-0000-0000-0000-000000000139"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/word-break/", "Word Break", new[] { "array", "hash-table", "string", "dynamic-programming", "trie", "memoization" } },
                    { new Guid("21000000-0000-0000-0000-000000000141"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/linked-list-cycle/", "Linked List Cycle", new[] { "hash-table", "linked-list", "two-pointers" } },
                    { new Guid("21000000-0000-0000-0000-000000000143"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/reorder-list/", "Reorder List", new[] { "linked-list", "two-pointers", "stack", "recursion" } },
                    { new Guid("21000000-0000-0000-0000-000000000146"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/lru-cache/", "LRU Cache", new[] { "hash-table", "linked-list", "design", "doubly-linked-list" } },
                    { new Guid("21000000-0000-0000-0000-000000000150"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/evaluate-reverse-polish-notation/", "Evaluate Reverse Polish Notation", new[] { "array", "math", "stack" } },
                    { new Guid("21000000-0000-0000-0000-000000000152"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/maximum-product-subarray/", "Maximum Product Subarray", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000153"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/", "Find Minimum in Rotated Sorted Array", new[] { "array", "binary-search" } },
                    { new Guid("21000000-0000-0000-0000-000000000155"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/min-stack/", "Min Stack", new[] { "stack", "design" } },
                    { new Guid("21000000-0000-0000-0000-000000000167"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/", "Two Sum II - Input Array Is Sorted", new[] { "array", "two-pointers", "binary-search" } },
                    { new Guid("21000000-0000-0000-0000-000000000190"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/reverse-bits/", "Reverse Bits", new[] { "divide-and-conquer", "bit-manipulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000191"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/number-of-1-bits/", "Number of 1 Bits", new[] { "divide-and-conquer", "bit-manipulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000198"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/house-robber/", "House Robber", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000199"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/binary-tree-right-side-view/", "Binary Tree Right Side View", new[] { "tree", "depth-first-search", "breadth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000200"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/number-of-islands/", "Number of Islands", new[] { "array", "depth-first-search", "breadth-first-search", "union-find", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000202"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/happy-number/", "Happy Number", new[] { "hash-table", "math", "two-pointers" } },
                    { new Guid("21000000-0000-0000-0000-000000000206"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/reverse-linked-list/", "Reverse Linked List", new[] { "linked-list", "recursion" } },
                    { new Guid("21000000-0000-0000-0000-000000000207"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/course-schedule/", "Course Schedule", new[] { "depth-first-search", "breadth-first-search", "graph", "topological-sort" } },
                    { new Guid("21000000-0000-0000-0000-000000000208"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/implement-trie-prefix-tree/", "Implement Trie (Prefix Tree)", new[] { "hash-table", "string", "design", "trie" } },
                    { new Guid("21000000-0000-0000-0000-000000000210"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/course-schedule-ii/", "Course Schedule II", new[] { "depth-first-search", "breadth-first-search", "graph", "topological-sort" } },
                    { new Guid("21000000-0000-0000-0000-000000000211"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/design-add-and-search-words-data-structure/", "Design Add and Search Words Data Structure", new[] { "string", "depth-first-search", "design", "trie" } },
                    { new Guid("21000000-0000-0000-0000-000000000212"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/word-search-ii/", "Word Search II", new[] { "array", "string", "backtracking", "trie", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000213"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/house-robber-ii/", "House Robber II", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000215"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/kth-largest-element-in-an-array/", "Kth Largest Element in an Array", new[] { "array", "divide-and-conquer", "sorting", "heap-priority-queue", "quickselect" } },
                    { new Guid("21000000-0000-0000-0000-000000000217"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/contains-duplicate/", "Contains Duplicate", new[] { "array", "hash-table", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000226"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/invert-binary-tree/", "Invert Binary Tree", new[] { "tree", "depth-first-search", "breadth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000230"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/kth-smallest-element-in-a-bst/", "Kth Smallest Element in a BST", new[] { "tree", "depth-first-search", "binary-search-tree", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000235"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/", "Lowest Common Ancestor of a Binary Search Tree", new[] { "tree", "depth-first-search", "binary-search-tree", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000238"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/product-of-array-except-self/", "Product of Array Except Self", new[] { "array", "prefix-sum" } },
                    { new Guid("21000000-0000-0000-0000-000000000239"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/sliding-window-maximum/", "Sliding Window Maximum", new[] { "array", "queue", "sliding-window", "heap-priority-queue", "monotonic-queue" } },
                    { new Guid("21000000-0000-0000-0000-000000000242"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/valid-anagram/", "Valid Anagram", new[] { "hash-table", "string", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000252"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/meeting-rooms/", "Meeting Rooms", new[] { "array", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000253"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/meeting-rooms-ii/", "Meeting Rooms II", new[] { "array", "two-pointers", "greedy", "sorting", "heap-priority-queue", "prefix-sum" } },
                    { new Guid("21000000-0000-0000-0000-000000000261"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/graph-valid-tree/", "Graph Valid Tree", new[] { "depth-first-search", "breadth-first-search", "union-find", "graph" } },
                    { new Guid("21000000-0000-0000-0000-000000000268"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/missing-number/", "Missing Number", new[] { "array", "hash-table", "math", "binary-search", "bit-manipulation", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000269"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/alien-dictionary/", "Alien Dictionary", new[] { "array", "string", "depth-first-search", "breadth-first-search", "graph", "topological-sort" } },
                    { new Guid("21000000-0000-0000-0000-000000000271"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/encode-and-decode-strings/", "Encode and Decode Strings", new[] { "array", "string", "design" } },
                    { new Guid("21000000-0000-0000-0000-000000000286"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/walls-and-gates/", "Walls and Gates", new[] { "array", "breadth-first-search", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000287"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/find-the-duplicate-number/", "Find the Duplicate Number", new[] { "array", "two-pointers", "binary-search", "bit-manipulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000295"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/find-median-from-data-stream/", "Find Median from Data Stream", new[] { "two-pointers", "design", "sorting", "heap-priority-queue", "data-stream" } },
                    { new Guid("21000000-0000-0000-0000-000000000297"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/serialize-and-deserialize-binary-tree/", "Serialize and Deserialize Binary Tree", new[] { "string", "tree", "depth-first-search", "breadth-first-search", "design", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000300"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/longest-increasing-subsequence/", "Longest Increasing Subsequence", new[] { "array", "binary-search", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000309"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/", "Best Time to Buy and Sell Stock with Cooldown", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000312"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/burst-balloons/", "Burst Balloons", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000322"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/coin-change/", "Coin Change", new[] { "array", "dynamic-programming", "breadth-first-search" } },
                    { new Guid("21000000-0000-0000-0000-000000000323"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/", "Number of Connected Components in an Undirected Graph", new[] { "depth-first-search", "breadth-first-search", "union-find", "graph" } },
                    { new Guid("21000000-0000-0000-0000-000000000329"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/longest-increasing-path-in-a-matrix/", "Longest Increasing Path in a Matrix", new[] { "array", "dynamic-programming", "depth-first-search", "breadth-first-search", "graph", "topological-sort", "memoization", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000332"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/reconstruct-itinerary/", "Reconstruct Itinerary", new[] { "array", "string", "depth-first-search", "graph", "sorting", "heap-priority-queue", "eulerian-circuit" } },
                    { new Guid("21000000-0000-0000-0000-000000000338"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/counting-bits/", "Counting Bits", new[] { "dynamic-programming", "bit-manipulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000347"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/top-k-frequent-elements/", "Top K Frequent Elements", new[] { "array", "hash-table", "divide-and-conquer", "sorting", "heap-priority-queue", "bucket-sort", "counting", "quickselect" } },
                    { new Guid("21000000-0000-0000-0000-000000000355"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/design-twitter/", "Design Twitter", new[] { "hash-table", "linked-list", "design", "heap-priority-queue" } },
                    { new Guid("21000000-0000-0000-0000-000000000371"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/sum-of-two-integers/", "Sum of Two Integers", new[] { "math", "bit-manipulation" } },
                    { new Guid("21000000-0000-0000-0000-000000000416"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/partition-equal-subset-sum/", "Partition Equal Subset Sum", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000417"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/pacific-atlantic-water-flow/", "Pacific Atlantic Water Flow", new[] { "array", "depth-first-search", "breadth-first-search", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000424"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/longest-repeating-character-replacement/", "Longest Repeating Character Replacement", new[] { "hash-table", "string", "sliding-window" } },
                    { new Guid("21000000-0000-0000-0000-000000000435"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/non-overlapping-intervals/", "Non-overlapping Intervals", new[] { "array", "dynamic-programming", "greedy", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000494"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/target-sum/", "Target Sum", new[] { "array", "dynamic-programming", "backtracking" } },
                    { new Guid("21000000-0000-0000-0000-000000000518"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/coin-change-ii/", "Coin Change II", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000543"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/diameter-of-binary-tree/", "Diameter of Binary Tree", new[] { "tree", "depth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000000567"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/permutation-in-string/", "Permutation in String", new[] { "hash-table", "two-pointers", "string", "sliding-window" } },
                    { new Guid("21000000-0000-0000-0000-000000000572"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/subtree-of-another-tree/", "Subtree of Another Tree", new[] { "tree", "depth-first-search", "string-matching", "binary-tree", "hash-function" } },
                    { new Guid("21000000-0000-0000-0000-000000000621"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/task-scheduler/", "Task Scheduler", new[] { "array", "hash-table", "greedy", "sorting", "heap-priority-queue", "counting" } },
                    { new Guid("21000000-0000-0000-0000-000000000647"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/palindromic-substrings/", "Palindromic Substrings", new[] { "two-pointers", "string", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000678"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/valid-parenthesis-string/", "Valid Parenthesis String", new[] { "string", "dynamic-programming", "stack", "greedy" } },
                    { new Guid("21000000-0000-0000-0000-000000000684"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/redundant-connection/", "Redundant Connection", new[] { "depth-first-search", "breadth-first-search", "union-find", "graph" } },
                    { new Guid("21000000-0000-0000-0000-000000000695"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/max-area-of-island/", "Max Area of Island", new[] { "array", "depth-first-search", "breadth-first-search", "union-find", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000703"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/kth-largest-element-in-a-stream/", "Kth Largest Element in a Stream", new[] { "tree", "design", "binary-search-tree", "heap-priority-queue", "binary-tree", "data-stream" } },
                    { new Guid("21000000-0000-0000-0000-000000000704"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/binary-search/", "Binary Search", new[] { "array", "binary-search" } },
                    { new Guid("21000000-0000-0000-0000-000000000739"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/daily-temperatures/", "Daily Temperatures", new[] { "array", "stack", "monotonic-stack" } },
                    { new Guid("21000000-0000-0000-0000-000000000743"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/network-delay-time/", "Network Delay Time", new[] { "depth-first-search", "breadth-first-search", "graph", "heap-priority-queue", "shortest-path" } },
                    { new Guid("21000000-0000-0000-0000-000000000746"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/min-cost-climbing-stairs/", "Min Cost Climbing Stairs", new[] { "array", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000000763"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/partition-labels/", "Partition Labels", new[] { "hash-table", "two-pointers", "string", "greedy" } },
                    { new Guid("21000000-0000-0000-0000-000000000778"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/swim-in-rising-water/", "Swim in Rising Water", new[] { "array", "binary-search", "depth-first-search", "breadth-first-search", "union-find", "heap-priority-queue", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000000787"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/cheapest-flights-within-k-stops/", "Cheapest Flights Within K Stops", new[] { "dynamic-programming", "depth-first-search", "breadth-first-search", "graph", "heap-priority-queue", "shortest-path" } },
                    { new Guid("21000000-0000-0000-0000-000000000846"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/hand-of-straights/", "Hand of Straights", new[] { "array", "hash-table", "greedy", "sorting" } },
                    { new Guid("21000000-0000-0000-0000-000000000853"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/car-fleet/", "Car Fleet", new[] { "array", "stack", "sorting", "monotonic-stack" } },
                    { new Guid("21000000-0000-0000-0000-000000000875"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/koko-eating-bananas/", "Koko Eating Bananas", new[] { "array", "binary-search" } },
                    { new Guid("21000000-0000-0000-0000-000000000973"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/k-closest-points-to-origin/", "K Closest Points to Origin", new[] { "array", "math", "divide-and-conquer", "geometry", "sorting", "heap-priority-queue", "quickselect" } },
                    { new Guid("21000000-0000-0000-0000-000000000981"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/time-based-key-value-store/", "Time Based Key-Value Store", new[] { "hash-table", "string", "binary-search", "design" } },
                    { new Guid("21000000-0000-0000-0000-000000000994"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/rotting-oranges/", "Rotting Oranges", new[] { "array", "breadth-first-search", "matrix" } },
                    { new Guid("21000000-0000-0000-0000-000000001046"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/last-stone-weight/", "Last Stone Weight", new[] { "array", "heap-priority-queue" } },
                    { new Guid("21000000-0000-0000-0000-000000001143"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/longest-common-subsequence/", "Longest Common Subsequence", new[] { "string", "dynamic-programming" } },
                    { new Guid("21000000-0000-0000-0000-000000001448"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/count-good-nodes-in-binary-tree/", "Count Good Nodes in Binary Tree", new[] { "tree", "depth-first-search", "breadth-first-search", "binary-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000001584"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/min-cost-to-connect-all-points/", "Min Cost to Connect All Points", new[] { "array", "union-find", "graph", "minimum-spanning-tree" } },
                    { new Guid("21000000-0000-0000-0000-000000001851"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hard", "https://leetcode.com/problems/minimum-interval-to-include-each-query/", "Minimum Interval to Include Each Query", new[] { "array", "binary-search", "sweep-line", "sorting", "heap-priority-queue" } },
                    { new Guid("21000000-0000-0000-0000-000000001899"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/merge-triplets-to-form-target-triplet/", "Merge Triplets to Form Target Triplet", new[] { "array", "greedy" } },
                    { new Guid("21000000-0000-0000-0000-000000002013"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/detect-squares/", "Detect Squares", new[] { "array", "hash-table", "design", "counting", "data-stream" } }
            });

        migrationBuilder.CreateIndex(
            name: "ix_problem_bank_external_url",
            table: "problem_bank",
            column: "external_url",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "ix_problem_bank_external_url",
            table: "problem_bank");

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000002"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000004"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000005"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000007"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000010"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000011"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000015"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000017"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000019"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000021"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000022"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000023"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000025"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000033"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000036"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000039"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000040"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000042"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000043"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000045"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000046"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000048"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000049"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000050"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000051"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000053"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000054"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000055"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000056"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000057"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000062"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000066"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000070"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000072"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000073"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000074"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000076"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000078"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000079"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000084"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000090"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000091"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000097"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000098"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000100"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000102"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000104"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000105"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000110"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000115"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000121"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000124"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000125"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000127"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000128"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000130"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000131"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000133"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000134"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000136"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000138"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000139"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000141"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000143"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000146"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000150"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000152"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000153"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000155"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000167"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000190"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000191"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000198"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000199"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000200"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000202"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000206"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000207"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000208"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000210"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000211"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000212"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000213"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000215"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000217"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000226"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000230"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000235"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000238"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000239"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000242"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000252"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000253"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000261"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000268"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000269"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000271"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000286"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000287"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000295"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000297"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000300"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000309"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000312"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000322"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000323"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000329"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000332"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000338"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000347"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000355"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000371"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000416"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000417"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000424"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000435"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000494"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000518"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000543"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000567"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000572"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000621"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000647"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000678"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000684"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000695"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000703"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000704"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000739"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000743"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000746"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000763"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000778"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000787"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000846"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000853"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000875"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000973"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000981"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000994"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001046"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001143"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001448"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001584"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001851"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001899"));

        migrationBuilder.DeleteData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002013"));

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
            column: "topic_tags",
            value: new[] { "stack", "string" });
    }
}
