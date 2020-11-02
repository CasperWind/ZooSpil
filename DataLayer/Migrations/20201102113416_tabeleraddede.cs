using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class tabeleraddede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDyr_Dyrs_DyrId",
                table: "UserDyr");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDyr_Users_UserId",
                table: "UserDyr");

            migrationBuilder.DropForeignKey(
                name: "FK_UserKunder_Kunders_KunderKundeId",
                table: "UserKunder");

            migrationBuilder.DropForeignKey(
                name: "FK_UserKunder_Users_UserID",
                table: "UserKunder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserKunder",
                table: "UserKunder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDyr",
                table: "UserDyr");

            migrationBuilder.RenameTable(
                name: "UserKunder",
                newName: "UserKunders");

            migrationBuilder.RenameTable(
                name: "UserDyr",
                newName: "UserDyrs");

            migrationBuilder.RenameIndex(
                name: "IX_UserKunder_KunderKundeId",
                table: "UserKunders",
                newName: "IX_UserKunders_KunderKundeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDyr_DyrId",
                table: "UserDyrs",
                newName: "IX_UserDyrs_DyrId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserKunders",
                table: "UserKunders",
                columns: new[] { "UserID", "KundeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDyrs",
                table: "UserDyrs",
                columns: new[] { "UserId", "DyrId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDyrs_Dyrs_DyrId",
                table: "UserDyrs",
                column: "DyrId",
                principalTable: "Dyrs",
                principalColumn: "DyrId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDyrs_Users_UserId",
                table: "UserDyrs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserKunders_Kunders_KunderKundeId",
                table: "UserKunders",
                column: "KunderKundeId",
                principalTable: "Kunders",
                principalColumn: "KundeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserKunders_Users_UserID",
                table: "UserKunders",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDyrs_Dyrs_DyrId",
                table: "UserDyrs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDyrs_Users_UserId",
                table: "UserDyrs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserKunders_Kunders_KunderKundeId",
                table: "UserKunders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserKunders_Users_UserID",
                table: "UserKunders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserKunders",
                table: "UserKunders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDyrs",
                table: "UserDyrs");

            migrationBuilder.RenameTable(
                name: "UserKunders",
                newName: "UserKunder");

            migrationBuilder.RenameTable(
                name: "UserDyrs",
                newName: "UserDyr");

            migrationBuilder.RenameIndex(
                name: "IX_UserKunders_KunderKundeId",
                table: "UserKunder",
                newName: "IX_UserKunder_KunderKundeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDyrs_DyrId",
                table: "UserDyr",
                newName: "IX_UserDyr_DyrId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserKunder",
                table: "UserKunder",
                columns: new[] { "UserID", "KundeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDyr",
                table: "UserDyr",
                columns: new[] { "UserId", "DyrId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDyr_Dyrs_DyrId",
                table: "UserDyr",
                column: "DyrId",
                principalTable: "Dyrs",
                principalColumn: "DyrId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDyr_Users_UserId",
                table: "UserDyr",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserKunder_Kunders_KunderKundeId",
                table: "UserKunder",
                column: "KunderKundeId",
                principalTable: "Kunders",
                principalColumn: "KundeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserKunder_Users_UserID",
                table: "UserKunder",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
