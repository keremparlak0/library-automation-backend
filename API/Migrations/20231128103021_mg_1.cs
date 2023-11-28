using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class mg_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshtokenEndDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Refreshtoken",
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
                values: new object[] { new DateTime(2023, 11, 28, 13, 30, 20, 927, DateTimeKind.Local).AddTicks(9879), new DateTime(2023, 11, 28, 13, 30, 20, 927, DateTimeKind.Local).AddTicks(9896) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 30, 20, 927, DateTimeKind.Local).AddTicks(9916), new DateTime(2023, 11, 28, 13, 30, 20, 927, DateTimeKind.Local).AddTicks(9917) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 30, 20, 927, DateTimeKind.Local).AddTicks(9920), new DateTime(2023, 11, 28, 13, 30, 20, 927, DateTimeKind.Local).AddTicks(9921) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshtokenEndDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Refreshtoken",
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
                values: new object[] { new DateTime(2023, 11, 28, 13, 27, 12, 267, DateTimeKind.Local).AddTicks(4648), new DateTime(2023, 11, 28, 13, 27, 12, 267, DateTimeKind.Local).AddTicks(4669) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 27, 12, 267, DateTimeKind.Local).AddTicks(4707), new DateTime(2023, 11, 28, 13, 27, 12, 267, DateTimeKind.Local).AddTicks(4709) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CratedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 11, 28, 13, 27, 12, 267, DateTimeKind.Local).AddTicks(4714), new DateTime(2023, 11, 28, 13, 27, 12, 267, DateTimeKind.Local).AddTicks(4715) });
        }
    }
}
