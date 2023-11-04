using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Villas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Detail", "Name", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 26, 14, 24, 41, 512, DateTimeKind.Local).AddTicks(5984), "", "Villa", 30000000, new DateTime(2023, 10, 26, 14, 24, 41, 512, DateTimeKind.Local).AddTicks(5997) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Detail", "Name", "Price", "UpdateDate" },
                values: new object[] { new DateTime(2023, 10, 26, 14, 24, 41, 512, DateTimeKind.Local).AddTicks(5999), "...", "Villa2", 400000000, new DateTime(2023, 10, 26, 14, 24, 41, 512, DateTimeKind.Local).AddTicks(6000) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Villas");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Detail", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2023, 7, 11, 16, 8, 10, 429, DateTimeKind.Local).AddTicks(9759), "Ziba", "Aida", new DateTime(2023, 7, 11, 16, 8, 10, 429, DateTimeKind.Local).AddTicks(9771) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Detail", "Name", "UpdateDate" },
                values: new object[] { new DateTime(2023, 7, 11, 16, 8, 10, 429, DateTimeKind.Local).AddTicks(9773), "Yumurta", "Behnam", new DateTime(2023, 7, 11, 16, 8, 10, 429, DateTimeKind.Local).AddTicks(9774) });
        }
    }
}
