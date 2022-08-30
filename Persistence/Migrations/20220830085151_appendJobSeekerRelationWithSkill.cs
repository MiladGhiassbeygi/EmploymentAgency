using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class appendJobSeekerRelationWithSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 13, 21, 50, 867, DateTimeKind.Local).AddTicks(5135),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 27, 14, 18, 51, 429, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.CreateTable(
                name: "JobSeekerEssentialSkills",
                columns: table => new
                {
                    JobSeekerId = table.Column<long>(type: "bigint", nullable: false),
                    SkillId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerEssentialSkills", x => new { x.SkillId, x.JobSeekerId });
                    table.ForeignKey(
                        name: "FK_JobSeekerEssentialSkills_JobSeeker",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSeekerEssentialSkills_Skill",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerUnnecessarySkills",
                columns: table => new
                {
                    JobSeekerId = table.Column<long>(type: "bigint", nullable: false),
                    SkillId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerUnnecessarySkills", x => new { x.SkillId, x.JobSeekerId });
                    table.ForeignKey(
                        name: "FK_JobSeekerUnnecessarySkills_JobSeeker",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSeekerUnnecessarySkills_Skill",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerEssentialSkills_JobSeekerId",
                table: "JobSeekerEssentialSkills",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerUnnecessarySkills_JobSeekerId",
                table: "JobSeekerUnnecessarySkills",
                column: "JobSeekerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSeekerEssentialSkills");

            migrationBuilder.DropTable(
                name: "JobSeekerUnnecessarySkills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 27, 14, 18, 51, 429, DateTimeKind.Local).AddTicks(503),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 30, 13, 21, 50, 867, DateTimeKind.Local).AddTicks(5135));
        }
    }
}
