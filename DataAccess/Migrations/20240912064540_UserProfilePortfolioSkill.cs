using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserProfilePortfolioSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePortfolio_UserProfiles_UserProfileId",
                table: "UserProfilePortfolio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfilePortfolio",
                table: "UserProfilePortfolio");

            migrationBuilder.RenameTable(
                name: "UserProfilePortfolio",
                newName: "UserProfilePortfolios");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfilePortfolio_UserProfileId",
                table: "UserProfilePortfolios",
                newName: "IX_UserProfilePortfolios_UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfilePortfolios",
                table: "UserProfilePortfolios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserProfilePortfolioSkill",
                columns: table => new
                {
                    UserProfilePortfolioId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfilePortfolioSkill", x => new { x.UserProfilePortfolioId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_UserProfilePortfolioSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfilePortfolioSkill_UserProfilePortfolios_UserProfilePortfolioId",
                        column: x => x.UserProfilePortfolioId,
                        principalTable: "UserProfilePortfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilePortfolioSkill_SkillId",
                table: "UserProfilePortfolioSkill",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilePortfolios_UserProfiles_UserProfileId",
                table: "UserProfilePortfolios",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePortfolios_UserProfiles_UserProfileId",
                table: "UserProfilePortfolios");

            migrationBuilder.DropTable(
                name: "UserProfilePortfolioSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfilePortfolios",
                table: "UserProfilePortfolios");

            migrationBuilder.RenameTable(
                name: "UserProfilePortfolios",
                newName: "UserProfilePortfolio");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfilePortfolios_UserProfileId",
                table: "UserProfilePortfolio",
                newName: "IX_UserProfilePortfolio_UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfilePortfolio",
                table: "UserProfilePortfolio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilePortfolio_UserProfiles_UserProfileId",
                table: "UserProfilePortfolio",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
