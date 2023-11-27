using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Refreshtoken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshtokenEndDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 27, 16, 10, 26, 683, DateTimeKind.Local).AddTicks(2671), new DateTime(2023, 11, 27, 16, 10, 26, 683, DateTimeKind.Local).AddTicks(2691) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 27, 16, 10, 26, 683, DateTimeKind.Local).AddTicks(2721), new DateTime(2023, 11, 27, 16, 10, 26, 683, DateTimeKind.Local).AddTicks(2722) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 27, 16, 10, 26, 683, DateTimeKind.Local).AddTicks(2726), new DateTime(2023, 11, 27, 16, 10, 26, 683, DateTimeKind.Local).AddTicks(2727) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Refreshtoken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshtokenEndDate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 25, 19, 6, 33, 794, DateTimeKind.Local).AddTicks(9165), new DateTime(2023, 11, 25, 19, 6, 33, 794, DateTimeKind.Local).AddTicks(9188) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 25, 19, 6, 33, 794, DateTimeKind.Local).AddTicks(9224), new DateTime(2023, 11, 25, 19, 6, 33, 794, DateTimeKind.Local).AddTicks(9226) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 25, 19, 6, 33, 794, DateTimeKind.Local).AddTicks(9233), new DateTime(2023, 11, 25, 19, 6, 33, 794, DateTimeKind.Local).AddTicks(9236) });
        }
    }
}
