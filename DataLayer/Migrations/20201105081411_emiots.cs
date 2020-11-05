using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class emiots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 1,
                column: "Navn",
                value: "🐊");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 2,
                column: "Navn",
                value: "🦁");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 3,
                column: "Navn",
                value: "🐘");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 4,
                column: "Navn",
                value: "🐧");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 5,
                column: "Navn",
                value: "🐉");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 6,
                column: "Navn",
                value: "🐯");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 1,
                column: "Navn",
                value: "Elefant");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 2,
                column: "Navn",
                value: "Abe");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 3,
                column: "Navn",
                value: "Tiger");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 4,
                column: "Navn",
                value: "Løve");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 5,
                column: "Navn",
                value: "Flodhest");

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 6,
                column: "Navn",
                value: "Dovendyr");
        }
    }
}
