using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightningLab2.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CheckoutDate",
                value: new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CheckoutDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CheckoutDate",
                value: new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CheckoutDate",
                value: new DateTime(2026, 2, 4, 11, 25, 45, 112, DateTimeKind.Local).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CheckoutDate", "ReturnDate" },
                values: new object[] { new DateTime(2026, 1, 28, 11, 25, 45, 116, DateTimeKind.Local).AddTicks(7042), new DateTime(2026, 2, 9, 11, 25, 45, 116, DateTimeKind.Local).AddTicks(7067) });

            migrationBuilder.UpdateData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CheckoutDate",
                value: new DateTime(2026, 2, 8, 11, 25, 45, 116, DateTimeKind.Local).AddTicks(7140));
        }
    }
}
