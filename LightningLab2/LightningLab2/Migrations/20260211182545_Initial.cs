using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LightningLab2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<string>(type: "TEXT", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Fines = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsBanned = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Status", "Title" },
                values: new object[,]
                {
                    { "B001", 0, "Clean Code" },
                    { "B002", 1, "Design Patterns" },
                    { "B003", 0, "The Pragmatic Programmer" },
                    { "B004", 2, "Refactoring" },
                    { "B005", 0, "The C# Player's Guide" }
                });

            migrationBuilder.InsertData(
                table: "Checkouts",
                columns: new[] { "Id", "BookId", "CheckoutDate", "ReturnDate", "UserId" },
                values: new object[,]
                {
                    { 1, "B001", new DateTime(2026, 2, 4, 11, 25, 45, 112, DateTimeKind.Local).AddTicks(3935), null, 1 },
                    { 2, "B002", new DateTime(2026, 1, 28, 11, 25, 45, 116, DateTimeKind.Local).AddTicks(7042), new DateTime(2026, 2, 9, 11, 25, 45, 116, DateTimeKind.Local).AddTicks(7067), 4 },
                    { 3, "B003", new DateTime(2026, 2, 8, 11, 25, 45, 116, DateTimeKind.Local).AddTicks(7140), null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Fines", "IsBanned", "Name" },
                values: new object[,]
                {
                    { 1, 5.00m, false, "Alice Johnson" },
                    { 2, 15.00m, false, "Bob Smith" },
                    { 3, 0m, true, "Charlie Brown" },
                    { 4, 0m, false, "Diana Prince" },
                    { 5, 3.50m, false, "Eve Wilson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
