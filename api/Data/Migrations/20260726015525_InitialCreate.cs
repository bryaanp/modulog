using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modulog.Api.Data.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Catalogs the tracking modules available in Modulog, starting with LeetCode.
        // The JSON schema definition documents the entry payload expected by each module.
        migrationBuilder.CreateTable(
            name: "modules",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                key = table.Column<string>(type: "text", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                schema_definition = table.Column<string>(type: "jsonb", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_modules", x => x.id);
            });

        // Stores the curated LeetCode problem catalog used for logging and recommendations.
        // Problems are shared across users; personal attempt history belongs in entries.
        migrationBuilder.CreateTable(
            name: "problem_bank",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                title = table.Column<string>(type: "text", nullable: false),
                external_url = table.Column<string>(type: "text", nullable: false),
                topic_tags = table.Column<string[]>(type: "text[]", nullable: false),
                difficulty = table.Column<string>(type: "text", nullable: false),
                created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_problem_bank", x => x.id);
            });

        // Stores ASP.NET Core Identity roles, such as the admin role required for
        // protected problem-bank write operations.
        migrationBuilder.CreateTable(
            name: "roles",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                concurrency_stamp = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_roles", x => x.id);
            });

        // Stores Modulog accounts through ASP.NET Core Identity, including normalized
        // login fields, the password hash, verification state, and lockout state.
        migrationBuilder.CreateTable(
            name: "users",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                password_hash = table.Column<string>(type: "text", nullable: true),
                security_stamp = table.Column<string>(type: "text", nullable: true),
                concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                phone_number = table.Column<string>(type: "text", nullable: true),
                phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                access_failed_count = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_users", x => x.id);
            });

        // Stores claims assigned to Identity roles. A role claim applies to every user
        // assigned to that role and supports future policy-based authorization.
        migrationBuilder.CreateTable(
            name: "role_claims",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                role_id = table.Column<Guid>(type: "uuid", nullable: false),
                claim_type = table.Column<string>(type: "text", nullable: true),
                claim_value = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_role_claims", x => x.id);
                table.ForeignKey(
                    name: "fk_role_claims_roles_role_id",
                    column: x => x.role_id,
                    principalTable: "roles",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        // Stores user-owned activity records for every module. LeetCode attempts use a
        // JSONB payload so future modules can add different entry shapes additively.
        migrationBuilder.CreateTable(
            name: "entries",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                module_id = table.Column<Guid>(type: "uuid", nullable: false),
                entry_type = table.Column<string>(type: "text", nullable: false),
                data = table.Column<string>(type: "jsonb", nullable: false),
                review_due_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                logged_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_entries", x => x.id);
                table.ForeignKey(
                    name: "fk_entries_modules_module_id",
                    column: x => x.module_id,
                    principalTable: "modules",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_entries_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        // Stores only hashes of long-lived refresh tokens, plus expiration, revocation,
        // and replacement metadata used for secure single-use token rotation.
        migrationBuilder.CreateTable(
            name: "refresh_tokens",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                token_hash = table.Column<string>(type: "text", nullable: false),
                created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                expires_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                revoked_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                replaced_by_token_id = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_refresh_tokens", x => x.id);
                table.ForeignKey(
                    name: "fk_refresh_tokens_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        // Stores claims assigned directly to individual Identity users for authorization
        // data that should not be inherited through a role.
        migrationBuilder.CreateTable(
            name: "user_claims",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                claim_type = table.Column<string>(type: "text", nullable: true),
                claim_value = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_user_claims", x => x.id);
                table.ForeignKey(
                    name: "fk_user_claims_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        // Stores external login-provider associations required by ASP.NET Core Identity.
        // Phase 1 does not expose social login, but Identity retains this support table.
        migrationBuilder.CreateTable(
            name: "user_logins",
            columns: table => new
            {
                login_provider = table.Column<string>(type: "text", nullable: false),
                provider_key = table.Column<string>(type: "text", nullable: false),
                provider_display_name = table.Column<string>(type: "text", nullable: true),
                user_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_user_logins", x => new { x.login_provider, x.provider_key });
                table.ForeignKey(
                    name: "fk_user_logins_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        // Links users to enabled tracking modules and stores per-user module settings
        // without placing LeetCode-specific configuration on the users table.
        migrationBuilder.CreateTable(
            name: "user_modules",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                module_id = table.Column<Guid>(type: "uuid", nullable: false),
                config = table.Column<string>(type: "jsonb", nullable: false),
                enabled = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_user_modules", x => x.id);
                table.ForeignKey(
                    name: "fk_user_modules_modules_module_id",
                    column: x => x.module_id,
                    principalTable: "modules",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_user_modules_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        // Implements the many-to-many relationship between Identity users and roles,
        // such as assigning a registered user to the admin role.
        migrationBuilder.CreateTable(
            name: "user_roles",
            columns: table => new
            {
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                role_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_user_roles", x => new { x.user_id, x.role_id });
                table.ForeignKey(
                    name: "fk_user_roles_roles_role_id",
                    column: x => x.role_id,
                    principalTable: "roles",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_user_roles_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        // Stores named tokens generated by ASP.NET Core Identity for a user and login
        // provider. Modulog refresh tokens are intentionally stored separately.
        migrationBuilder.CreateTable(
            name: "user_tokens",
            columns: table => new
            {
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                login_provider = table.Column<string>(type: "text", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                value = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                table.ForeignKey(
                    name: "fk_user_tokens_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "modules",
            columns: new[] { "id", "key", "name", "schema_definition" },
            values: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), "leetcode", "LeetCode", "{\"problem_attempt\":{\"problem_bank_id\":\"uuid\",\"time_spent_minutes\":\"integer\",\"hints_used\":\"integer\",\"self_rated_confidence\":\"integer|null\",\"topic_tags\":\"string[]\"}}" });

        migrationBuilder.InsertData(
            table: "problem_bank",
            columns: new[] { "id", "created_at", "difficulty", "external_url", "title", "topic_tags" },
            values: new object[,]
            {
                { new Guid("20000000-0000-0000-0000-000000000001"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/two-sum/", "Two Sum", new[] { "array", "hash-table" } },
                { new Guid("20000000-0000-0000-0000-000000000002"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Easy", "https://leetcode.com/problems/valid-parentheses/", "Valid Parentheses", new[] { "stack", "string" } },
                { new Guid("20000000-0000-0000-0000-000000000003"), new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medium", "https://leetcode.com/problems/longest-substring-without-repeating-characters/", "Longest Substring Without Repeating Characters", new[] { "hash-table", "string", "sliding-window" } }
            });

        migrationBuilder.CreateIndex(
            name: "ix_entries_module_id",
            table: "entries",
            column: "module_id");

        migrationBuilder.CreateIndex(
            name: "ix_entries_user_id_logged_at",
            table: "entries",
            columns: new[] { "user_id", "logged_at" });

        migrationBuilder.CreateIndex(
            name: "ix_modules_key",
            table: "modules",
            column: "key",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_refresh_tokens_token_hash",
            table: "refresh_tokens",
            column: "token_hash",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_refresh_tokens_user_id_expires_at",
            table: "refresh_tokens",
            columns: new[] { "user_id", "expires_at" });

        migrationBuilder.CreateIndex(
            name: "ix_role_claims_role_id",
            table: "role_claims",
            column: "role_id");

        migrationBuilder.CreateIndex(
            name: "RoleNameIndex",
            table: "roles",
            column: "normalized_name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_user_claims_user_id",
            table: "user_claims",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "ix_user_logins_user_id",
            table: "user_logins",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "ix_user_modules_module_id",
            table: "user_modules",
            column: "module_id");

        migrationBuilder.CreateIndex(
            name: "ix_user_modules_user_id_module_id",
            table: "user_modules",
            columns: new[] { "user_id", "module_id" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_user_roles_role_id",
            table: "user_roles",
            column: "role_id");

        migrationBuilder.CreateIndex(
            name: "EmailIndex",
            table: "users",
            column: "normalized_email");

        migrationBuilder.CreateIndex(
            name: "UserNameIndex",
            table: "users",
            column: "normalized_user_name",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "entries");

        migrationBuilder.DropTable(
            name: "problem_bank");

        migrationBuilder.DropTable(
            name: "refresh_tokens");

        migrationBuilder.DropTable(
            name: "role_claims");

        migrationBuilder.DropTable(
            name: "user_claims");

        migrationBuilder.DropTable(
            name: "user_logins");

        migrationBuilder.DropTable(
            name: "user_modules");

        migrationBuilder.DropTable(
            name: "user_roles");

        migrationBuilder.DropTable(
            name: "user_tokens");

        migrationBuilder.DropTable(
            name: "modules");

        migrationBuilder.DropTable(
            name: "roles");

        migrationBuilder.DropTable(
            name: "users");
    }
}
