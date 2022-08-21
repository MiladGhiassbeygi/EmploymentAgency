using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class appendWorkExperienceSkillRelationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skills",
                table: "WorkExperiences");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 15, 20, 10, 3, DateTimeKind.Local).AddTicks(8590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 21, 14, 55, 35, 657, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.CreateTable(
                name: "WorkExperienceSkills",
                columns: table => new
                {
                    SkillId = table.Column<short>(type: "smallint", nullable: false),
                    WorkExperienceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperienceSkills", x => new { x.SkillId, x.WorkExperienceId });
                    table.ForeignKey(
                        name: "FK_Skill_WorkExperience",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkExperience_Skill",
                        column: x => x.WorkExperienceId,
                        principalTable: "WorkExperiences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperienceSkills_WorkExperienceId",
                table: "WorkExperienceSkills",
                column: "WorkExperienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkExperienceSkills");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "WorkExperiences",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 14, 55, 35, 657, DateTimeKind.Local).AddTicks(5369),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 21, 15, 20, 10, 3, DateTimeKind.Local).AddTicks(8590));
        }
    }
}
