using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Job : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePortfolioSkill_Skills_SkillId",
                table: "UserProfilePortfolioSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePortfolioSkill_UserProfilePortfolios_UserProfilePortfolioId",
                table: "UserProfilePortfolioSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfilePortfolioSkill",
                table: "UserProfilePortfolioSkill");

            migrationBuilder.RenameTable(
                name: "UserProfilePortfolioSkill",
                newName: "UserProfilePortfolioSkills");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfilePortfolioSkill_SkillId",
                table: "UserProfilePortfolioSkills",
                newName: "IX_UserProfilePortfolioSkills_SkillId");

            migrationBuilder.AddColumn<int>(
                name: "Connects",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfilePortfolioSkills",
                table: "UserProfilePortfolioSkills",
                columns: new[] { "UserProfilePortfolioId", "SkillId" });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    MinRequiredConnects = table.Column<int>(type: "int", nullable: false),
                    SalaryTypeId = table.Column<int>(type: "int", nullable: false),
                    WorkHourId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_SalaryTypes_SalaryTypeId",
                        column: x => x.SalaryTypeId,
                        principalTable: "SalaryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_WorkHours_WorkHourId",
                        column: x => x.WorkHourId,
                        principalTable: "WorkHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => new { x.JobId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ExperienceId",
                table: "Jobs",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SalaryTypeId",
                table: "Jobs",
                column: "SalaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkHourId",
                table: "Jobs",
                column: "WorkHourId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilePortfolioSkills_Skills_SkillId",
                table: "UserProfilePortfolioSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilePortfolioSkills_UserProfilePortfolios_UserProfilePortfolioId",
                table: "UserProfilePortfolioSkills",
                column: "UserProfilePortfolioId",
                principalTable: "UserProfilePortfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePortfolioSkills_Skills_SkillId",
                table: "UserProfilePortfolioSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePortfolioSkills_UserProfilePortfolios_UserProfilePortfolioId",
                table: "UserProfilePortfolioSkills");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfilePortfolioSkills",
                table: "UserProfilePortfolioSkills");

            migrationBuilder.DropColumn(
                name: "Connects",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserProfilePortfolioSkills",
                newName: "UserProfilePortfolioSkill");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfilePortfolioSkills_SkillId",
                table: "UserProfilePortfolioSkill",
                newName: "IX_UserProfilePortfolioSkill_SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfilePortfolioSkill",
                table: "UserProfilePortfolioSkill",
                columns: new[] { "UserProfilePortfolioId", "SkillId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilePortfolioSkill_Skills_SkillId",
                table: "UserProfilePortfolioSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilePortfolioSkill_UserProfilePortfolios_UserProfilePortfolioId",
                table: "UserProfilePortfolioSkill",
                column: "UserProfilePortfolioId",
                principalTable: "UserProfilePortfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
