using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class MangeTIlMange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dyrs",
                columns: table => new
                {
                    DyrId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dyrs", x => x.DyrId);
                });

            migrationBuilder.CreateTable(
                name: "Kunders",
                columns: table => new
                {
                    KundeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunders", x => x.KundeId);
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
                name: "UserDyr",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    DyrId = table.Column<int>(nullable: false),
                    Antal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDyr", x => new { x.UserId, x.DyrId });
                    table.ForeignKey(
                        name: "FK_UserDyr_Dyrs_DyrId",
                        column: x => x.DyrId,
                        principalTable: "Dyrs",
                        principalColumn: "DyrId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDyr_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserKunder",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    KundeId = table.Column<int>(nullable: false),
                    Antal = table.Column<int>(nullable: false),
                    KunderKundeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKunder", x => new { x.UserID, x.KundeId });
                    table.ForeignKey(
                        name: "FK_UserKunder_Kunders_KunderKundeId",
                        column: x => x.KunderKundeId,
                        principalTable: "Kunders",
                        principalColumn: "KundeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserKunder_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dyrs",
                columns: new[] { "DyrId", "Navn" },
                values: new object[,]
                {
                    { 1, "Elefant" },
                    { 2, "Abe" },
                    { 3, "Tiger" },
                    { 4, "Løve" },
                    { 5, "Flodhest" },
                    { 6, "Dovendyr" }
                });

            migrationBuilder.InsertData(
                table: "Kunders",
                columns: new[] { "KundeId", "Navn" },
                values: new object[,]
                {
                    { 1, "Famile" },
                    { 2, "Par" },
                    { 3, "Unge" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDyr_DyrId",
                table: "UserDyr",
                column: "DyrId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKunder_KunderKundeId",
                table: "UserKunder",
                column: "KunderKundeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDyr");

            migrationBuilder.DropTable(
                name: "UserKunder");

            migrationBuilder.DropTable(
                name: "Dyrs");

            migrationBuilder.DropTable(
                name: "Kunders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
