using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modulog.Api.Data.Migrations;

/// <inheritdoc />
public partial class AddProjectsAndSoftwareModule : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "project_id",
            table: "entries",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<int>(
            name: "schema_version",
            table: "entries",
            type: "integer",
            nullable: false,
            defaultValue: 1);

        migrationBuilder.AddColumn<string>(
            name: "status",
            table: "entries",
            type: "character varying(20)",
            maxLength: 20,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "title",
            table: "entries",
            type: "character varying(200)",
            maxLength: 200,
            nullable: true);

        migrationBuilder.CreateTable(
            name: "projects",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                is_archived = table.Column<bool>(type: "boolean", nullable: false),
                is_default_interview = table.Column<bool>(type: "boolean", nullable: false),
                created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_projects", x => x.id);
                table.UniqueConstraint("ak_projects_user_id_id", x => new { x.user_id, x.id });
                table.ForeignKey(
                    name: "fk_projects_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "project_modules",
            columns: table => new
            {
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                project_id = table.Column<Guid>(type: "uuid", nullable: false),
                module_id = table.Column<Guid>(type: "uuid", nullable: false),
                enabled = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_project_modules", x => new { x.user_id, x.project_id, x.module_id });
                table.ForeignKey(
                    name: "fk_project_modules_modules_module_id",
                    column: x => x.module_id,
                    principalTable: "modules",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_project_modules_projects_user_id_project_id",
                    columns: x => new { x.user_id, x.project_id },
                    principalTable: "projects",
                    principalColumns: new[] { "user_id", "id" },
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "modules",
            columns: new[] { "id", "key", "name", "schema_definition" },
            values: new object[] { new Guid("10000000-0000-0000-0000-000000000002"), "software", "Software projects", "{\"version\":1,\"milestone\":{\"notes\":\"string|null\"},\"dev_log\":{\"notes\":\"string\"}}" });

        migrationBuilder.CreateIndex(
            name: "ix_entries_user_id_project_id_module_id_logged_at",
            table: "entries",
            columns: new[] { "user_id", "project_id", "module_id", "logged_at" });

        migrationBuilder.CreateIndex(
            name: "ix_entries_user_id_review_due_at",
            table: "entries",
            columns: new[] { "user_id", "review_due_at" });

        migrationBuilder.CreateIndex(
            name: "ix_project_modules_module_id",
            table: "project_modules",
            column: "module_id");

        migrationBuilder.CreateIndex(
            name: "ix_projects_user_id",
            table: "projects",
            column: "user_id",
            unique: true,
            filter: "is_default_interview = true");

        // Use a deterministic UUID without requiring a PostgreSQL extension.
        // Keep payloads, timestamps, IDs, and user_modules/configuration intact.
        migrationBuilder.Sql("""
            INSERT INTO projects (id, user_id, name, is_archived, is_default_interview, created_at)
            SELECT md5('modulog:interview:' || id::text)::uuid, id, 'Interview preparation', false, true, created_at
            FROM users;

            INSERT INTO project_modules (user_id, project_id, module_id, enabled)
            SELECT ownership.user_id, p.id, ownership.module_id, COALESCE(um.enabled, true)
            FROM (
                SELECT id AS user_id, '10000000-0000-0000-0000-000000000001'::uuid AS module_id FROM users
                UNION SELECT user_id, module_id FROM user_modules
                UNION SELECT user_id, module_id FROM entries
            ) ownership
            JOIN projects p ON p.user_id = ownership.user_id AND p.is_default_interview
            LEFT JOIN user_modules um ON um.user_id = ownership.user_id AND um.module_id = ownership.module_id;

            UPDATE entries e SET project_id = p.id
            FROM projects p WHERE p.user_id = e.user_id AND p.is_default_interview;

            UPDATE entries e SET title = left(p.title, 200)
            FROM problem_bank p WHERE e.module_id = '10000000-0000-0000-0000-000000000001'::uuid
                AND e.entry_type = 'problem_attempt' AND e.data->>'problem_bank_id' = p.id::text;
            """);

        migrationBuilder.AddForeignKey(
            name: "fk_entries_project_modules_user_id_project_id_module_id",
            table: "entries",
            columns: new[] { "user_id", "project_id", "module_id" },
            principalTable: "project_modules",
            principalColumns: new[] { "user_id", "project_id", "module_id" },
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // An old binary cannot represent new project or software data. Refuse
        // a lossy downgrade; operators must restore a pre-upgrade backup instead.
        migrationBuilder.Sql("""
            DO $$ BEGIN
                IF EXISTS (SELECT 1 FROM projects WHERE NOT is_default_interview)
                   OR EXISTS (SELECT 1 FROM entries WHERE module_id = '10000000-0000-0000-0000-000000000002'::uuid)
                THEN RAISE EXCEPTION 'Cannot downgrade after creating project/software data. Restore a pre-upgrade backup.';
                END IF;
            END $$;
            """);

        migrationBuilder.DropForeignKey(
            name: "fk_entries_project_modules_user_id_project_id_module_id",
            table: "entries");

        migrationBuilder.DropTable(
            name: "project_modules");

        migrationBuilder.DropTable(
            name: "projects");

        migrationBuilder.DropIndex(
            name: "ix_entries_user_id_project_id_module_id_logged_at",
            table: "entries");

        migrationBuilder.DropIndex(
            name: "ix_entries_user_id_review_due_at",
            table: "entries");

        migrationBuilder.DeleteData(
            table: "modules",
            keyColumn: "id",
            keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

        migrationBuilder.DropColumn(
            name: "project_id",
            table: "entries");

        migrationBuilder.DropColumn(
            name: "schema_version",
            table: "entries");

        migrationBuilder.DropColumn(
            name: "status",
            table: "entries");

        migrationBuilder.DropColumn(
            name: "title",
            table: "entries");
    }
}
