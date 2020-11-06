using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class medemio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KunderId",
                keyValue: 1,
                column: "Navn",
                value: "👪");

            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KunderId",
                keyValue: 2,
                column: "Navn",
                value: "👫");

            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KunderId",
                keyValue: 3,
                column: "Navn",
                value: "👦");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KunderId",
                keyValue: 1,
                column: "Navn",
                value: "U+1F46A");

            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KunderId",
                keyValue: 2,
                column: "Navn",
                value: "U+1F491");

            migrationBuilder.UpdateData(
                table: "Kunders",
                keyColumn: "KunderId",
                keyValue: 3,
                column: "Navn",
                value: "U+1F466");
        }
    }
}
