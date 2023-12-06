using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class mg_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 5, 16, 19, 42, 759, DateTimeKind.Local).AddTicks(8765), new DateTime(2023, 12, 5, 16, 19, 42, 759, DateTimeKind.Local).AddTicks(8791) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 5, 16, 19, 42, 759, DateTimeKind.Local).AddTicks(8839), new DateTime(2023, 12, 5, 16, 19, 42, 759, DateTimeKind.Local).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 5, 16, 19, 42, 759, DateTimeKind.Local).AddTicks(8846), new DateTime(2023, 12, 5, 16, 19, 42, 759, DateTimeKind.Local).AddTicks(8847) });
        }
    }
}
