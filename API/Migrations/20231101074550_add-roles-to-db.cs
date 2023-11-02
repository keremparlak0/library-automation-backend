using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addrolestodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e3fbdf8a-4833-4134-ab87-cc8a06647cbf", "79952017-02fb-49b2-b4a6-25dcf787414b", "Admin", "ADMIN" },
                    { "f4974bfe-4606-494d-8fe0-ae13cd580947", "910f96f4-229b-4a4c-bf1d-0c6f4a980f7f", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CratedAt",
                value: new DateTime(2023, 11, 1, 10, 45, 50, 636, DateTimeKind.Local).AddTicks(62));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3fbdf8a-4833-4134-ab87-cc8a06647cbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4974bfe-4606-494d-8fe0-ae13cd580947");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CratedAt",
                value: new DateTime(2023, 11, 1, 10, 29, 44, 461, DateTimeKind.Local).AddTicks(2584));
        }
    }
}
