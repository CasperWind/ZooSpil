using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class medR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dyrs",
                columns: table => new
                {
                    DyrId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(nullable: true),
                    Pris = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dyrs", x => x.DyrId);
                });

            migrationBuilder.CreateTable(
                name: "Kunders",
                columns: table => new
                {
                    KunderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunders", x => x.KunderId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Penge = table.Column<decimal>(nullable: false),
                    Navn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserDyrs",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    DyrId = table.Column<int>(nullable: false),
                    Antal = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDyrs", x => new { x.UserId, x.DyrId });
                    table.ForeignKey(
                        name: "FK_UserDyrs_Dyrs_DyrId",
                        column: x => x.DyrId,
                        principalTable: "Dyrs",
                        principalColumn: "DyrId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDyrs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserKunders",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    KunderId = table.Column<int>(nullable: false),
                    Antal = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKunders", x => new { x.UserID, x.KunderId });
                    table.ForeignKey(
                        name: "FK_UserKunders_Kunders_KunderId",
                        column: x => x.KunderId,
                        principalTable: "Kunders",
                        principalColumn: "KunderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserKunders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dyrs",
                columns: new[] { "DyrId", "Navn", "Pris" },
                values: new object[,]
                {
                    { 1, "🐊", 10000m },
                    { 2, "🦁", 10000m },
                    { 3, "🐘", 10000m },
                    { 4, "🐧", 10000m },
                    { 5, "🐉", 10000m },
                    { 6, "🐯", 10000m }
                });

            migrationBuilder.InsertData(
                table: "Kunders",
                columns: new[] { "KunderId", "Navn" },
                values: new object[,]
                {
                    { 1, "U+1F46A" },
                    { 2, "U+1F491" },
                    { 3, "U+1F466" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDyrs_DyrId",
                table: "UserDyrs",
                column: "DyrId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKunders_KunderId",
                table: "UserKunders",
                column: "KunderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDyrs");

            migrationBuilder.DropTable(
                name: "UserKunders");

            migrationBuilder.DropTable(
                name: "Dyrs");

            migrationBuilder.DropTable(
                name: "Kunders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
