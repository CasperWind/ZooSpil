using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dyrs",
                columns: new[] { "DyrId", "Antal", "Navn", "UserId" },
                values: new object[,]
                {
                    { 1, 0, "Elefant", null },
                    { 2, 0, "Abe", null },
                    { 3, 0, "Tiger", null },
                    { 4, 0, "Løve", null },
                    { 5, 0, "Flodhest", null },
                    { 6, 0, "Dovendyr", null }
                });

            migrationBuilder.InsertData(
                table: "Kunders",
                columns: new[] { "KundeId", "Antal", "Navn", "UserId" },
                values: new object[,]
                {
                    { 1, 0, "Famile", null },
                    { 2, 0, "Par", null },
                    { 3, 0, "Unge", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kunders",
                keyColumn: "KundeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kunders",
                keyColumn: "KundeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kunders",
                keyColumn: "KundeId",
                keyValue: 3);
        }
    }
}
