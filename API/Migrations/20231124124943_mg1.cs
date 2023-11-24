using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CratedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Kafka", new DateTime(2023, 11, 24, 15, 49, 43, 828, DateTimeKind.Local).AddTicks(1303), "Donusum", new DateTime(2023, 11, 24, 15, 49, 43, 828, DateTimeKind.Local).AddTicks(1326) },
                    { 2, "Mario Puzo", new DateTime(2023, 11, 24, 15, 49, 43, 828, DateTimeKind.Local).AddTicks(1350), "The Godfather", new DateTime(2023, 11, 24, 15, 49, 43, 828, DateTimeKind.Local).AddTicks(1352) },
                    { 3, "Aldous Huxley", new DateTime(2023, 11, 24, 15, 49, 43, 828, DateTimeKind.Local).AddTicks(1355), "Cesur Yeni Dunya", new DateTime(2023, 11, 24, 15, 49, 43, 828, DateTimeKind.Local).AddTicks(1356) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
