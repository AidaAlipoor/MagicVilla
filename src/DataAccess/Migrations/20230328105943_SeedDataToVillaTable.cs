using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreateDate", "Detail", "ImageUrl", "Name", "Occupancy", "Rate", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 3, 28, 15, 29, 42, 997, DateTimeKind.Local).AddTicks(4078), "Ziba", null, "Aida", 10, 0.0, new DateTime(2023, 3, 28, 15, 29, 42, 997, DateTimeKind.Local).AddTicks(4126) },
                    { 2, "", new DateTime(2023, 3, 28, 15, 29, 42, 997, DateTimeKind.Local).AddTicks(4131), "Yumurta", null, "Behnam", 10, 0.0, new DateTime(2023, 3, 28, 15, 29, 42, 997, DateTimeKind.Local).AddTicks(4133) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
