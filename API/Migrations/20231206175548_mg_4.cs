using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class mg_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 6, 20, 55, 48, 250, DateTimeKind.Local).AddTicks(8464), new DateTime(2023, 12, 6, 20, 55, 48, 250, DateTimeKind.Local).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 6, 20, 55, 48, 250, DateTimeKind.Local).AddTicks(8512), new DateTime(2023, 12, 6, 20, 55, 48, 250, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 6, 20, 55, 48, 250, DateTimeKind.Local).AddTicks(8516), new DateTime(2023, 12, 6, 20, 55, 48, 250, DateTimeKind.Local).AddTicks(8517) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 5, 16, 24, 18, 190, DateTimeKind.Local).AddTicks(7541), new DateTime(2023, 12, 5, 16, 24, 18, 190, DateTimeKind.Local).AddTicks(7560) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 5, 16, 24, 18, 190, DateTimeKind.Local).AddTicks(7585), new DateTime(2023, 12, 5, 16, 24, 18, 190, DateTimeKind.Local).AddTicks(7587) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 5, 16, 24, 18, 190, DateTimeKind.Local).AddTicks(7592), new DateTime(2023, 12, 5, 16, 24, 18, 190, DateTimeKind.Local).AddTicks(7593) });
        }
    }
}
