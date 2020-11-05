using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class famileemots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KundeId",
                keyValue: 1,
                column: "Navn",
                value: "👪");

            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KundeId",
                keyValue: 2,
                column: "Navn",
                value: "👫");

            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KundeId",
                keyValue: 3,
                column: "Navn",
                value: "👦");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KundeId",
                keyValue: 1,
                column: "Navn",
                value: "Famile");

            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KundeId",
                keyValue: 2,
                column: "Navn",
                value: "Par");

            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KundeId",
                keyValue: 3,
                column: "Navn",
                value: "Unge");
        }
    }
}
