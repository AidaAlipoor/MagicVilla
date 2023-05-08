using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 5, 8, 16, 46, 37, 371, DateTimeKind.Local).AddTicks(2742), new DateTime(2023, 5, 8, 16, 46, 37, 371, DateTimeKind.Local).AddTicks(2792) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 5, 8, 16, 46, 37, 371, DateTimeKind.Local).AddTicks(2795), new DateTime(2023, 5, 8, 16, 46, 37, 371, DateTimeKind.Local).AddTicks(2797) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 3, 28, 15, 29, 42, 997, DateTimeKind.Local).AddTicks(4078), new DateTime(2023, 3, 28, 15, 29, 42, 997, DateTimeKind.Local).AddTicks(4126) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2023, 3, 28, 15, 29, 42, 997, DateTimeKind.Local).AddTicks(4131), new DateTime(2023, 3, 28, 15, 29, 42, 997, DateTimeKind.Local).AddTicks(4133) });
        }
    }
}
