using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Table4URest.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LocationFilters",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "PostalCode", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5347), new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5363), 520824, "System" },
                    { 2, "System", new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5366), new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5368), 460218, "System" }
                });

            migrationBuilder.InsertData(
                table: "PriceFilters",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "PriceRange", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(6363), new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(6365), "Budget", "System" },
                    { 2, "System", new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(6367), new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(6368), "Normal", "System" },
                    { 3, "System", new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(6371), new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(6372), "Fancy", "System" }
                });

            migrationBuilder.InsertData(
                table: "ServeFilters",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "ServeRange", "ServeTime", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5989), new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5990), "Breakfast", 0, "System" },
                    { 2, "System", new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5993), new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5994), "Lunch", 0, "System" },
                    { 3, "System", new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5997), new DateTime(2024, 1, 10, 15, 48, 21, 642, DateTimeKind.Local).AddTicks(5998), "Dinner", 0, "System" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocationFilters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LocationFilters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PriceFilters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PriceFilters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PriceFilters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServeFilters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServeFilters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServeFilters",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
