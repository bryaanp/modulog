using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1825 // EF scaffolds concrete empty arrays for PostgreSQL seed values.

namespace Modulog.Api.Data.Migrations;

/// <inheritdoc />
public partial class AddProblemCompanies : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string[]>(
            name: "companies",
            table: "problem_bank",
            type: "text[]",
            nullable: false,
            defaultValue: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("20000000-0000-0000-0000-000000000001"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("20000000-0000-0000-0000-000000000003"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000002"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000004"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000005"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000007"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000010"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000011"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000015"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000017"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000019"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000021"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000022"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000023"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000025"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000031"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000032"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000033"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000036"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000039"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000040"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000041"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000042"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000043"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000045"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000046"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000048"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000049"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000050"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000051"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000053"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000054"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000055"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000056"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000057"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000062"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000064"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000066"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000070"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000072"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000073"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000074"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000075"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000076"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000078"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000079"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000084"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000090"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000091"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000097"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000098"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000100"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000102"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000104"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000105"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000110"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000115"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000121"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000122"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000124"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000125"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000127"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000128"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000130"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000131"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000133"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000134"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000136"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000138"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000139"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000140"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000141"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000143"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000146"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000148"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000150"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000152"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000153"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000155"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000167"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000190"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000191"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000198"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000199"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000200"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000202"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000206"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000207"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000208"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000210"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000211"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000212"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000213"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000215"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000217"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000224"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000226"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000230"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000235"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000238"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000239"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000242"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000250"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000252"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000253"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000261"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000268"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000269"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000271"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000272"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000273"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000277"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000286"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000287"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000295"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000297"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000300"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000309"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000312"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000316"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000322"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000323"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000329"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000332"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000337"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000338"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000340"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000347"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000355"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000371"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000380"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000381"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000399"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000402"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000416"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000417"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000424"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000432"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000435"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000460"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000472"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000475"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000494"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000518"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000528"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000543"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000567"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000572"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000621"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000647"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000662"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000678"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000684"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000692"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000695"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000703"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000704"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000716"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000735"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000739"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000743"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000746"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000763"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000767"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000774"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000778"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000787"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000802"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000815"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000827"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000841"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000846"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000853"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000863"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000875"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000881"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000901"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000904"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000911"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000934"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000973"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000981"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000000994"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001004"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001046"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001143"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001186"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001197"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001209"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001235"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001277"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001297"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001392"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001423"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001448"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001552"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001559"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001584"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001658"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001851"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000001899"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002001"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002013"),
            column: "companies",
            value: new string[0]);

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002080"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002115"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002385"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002517"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000002643"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000003159"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000003193"),
            column: "companies",
            value: new[] { "Amazon" });

        migrationBuilder.UpdateData(
            table: "problem_bank",
            keyColumn: "id",
            keyValue: new Guid("21000000-0000-0000-0000-000000003388"),
            column: "companies",
            value: new[] { "Amazon" });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "companies",
            table: "problem_bank");
    }
}
