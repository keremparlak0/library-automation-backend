using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class mg_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 52, 30, 834, DateTimeKind.Local).AddTicks(4542), new DateTime(2023, 11, 28, 13, 52, 30, 834, DateTimeKind.Local).AddTicks(4564) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 52, 30, 834, DateTimeKind.Local).AddTicks(4583), new DateTime(2023, 11, 28, 13, 52, 30, 834, DateTimeKind.Local).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 52, 30, 834, DateTimeKind.Local).AddTicks(4588), new DateTime(2023, 11, 28, 13, 52, 30, 834, DateTimeKind.Local).AddTicks(4589) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 49, 36, 657, DateTimeKind.Local).AddTicks(1858), new DateTime(2023, 11, 28, 13, 49, 36, 657, DateTimeKind.Local).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 49, 36, 657, DateTimeKind.Local).AddTicks(1931), new DateTime(2023, 11, 28, 13, 49, 36, 657, DateTimeKind.Local).AddTicks(1932) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 49, 36, 657, DateTimeKind.Local).AddTicks(1935), new DateTime(2023, 11, 28, 13, 49, 36, 657, DateTimeKind.Local).AddTicks(1936) });
        }
    }
}
