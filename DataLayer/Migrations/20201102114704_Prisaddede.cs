using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Prisaddede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Pris",
                table: "Dyrs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 1,
                column: "Pris",
                value: 10000m);

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 2,
                column: "Pris",
                value: 10000m);

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 3,
                column: "Pris",
                value: 10000m);

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 4,
                column: "Pris",
                value: 10000m);

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 5,
                column: "Pris",
                value: 10000m);

            migrationBuilder.UpdateData(
                table: "Dyrs",
                keyColumn: "DyrId",
                keyValue: 6,
                column: "Pris",
                value: 10000m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pris",
                table: "Dyrs");
        }
    }
}
