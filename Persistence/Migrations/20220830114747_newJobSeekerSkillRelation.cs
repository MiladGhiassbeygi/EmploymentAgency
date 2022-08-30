using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class newJobSeekerSkillRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSeekerEssentialSkills");

            migrationBuilder.DropTable(
                name: "JobSeekerUnnecessarySkills");

            migrationBuilder.DropTable(
                name: "JobUnnecessarySkills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 16, 17, 47, 475, DateTimeKind.Local).AddTicks(5270),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 30, 13, 21, 50, 867, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.CreateTable(
                name: "JobSeekerSkills",
                columns: table => new
                {
                    JobSeekerId = table.Column<long>(type: "bigint", nullable: false),
                    SkillId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerSkills", x => new { x.SkillId, x.JobSeekerId });
                    table.ForeignKey(
                        name: "FK_JobSeekerSkills_JobSeeker",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSeekerSkills_Skill",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobUnnessecarySkills",
                columns: table => new
                {
                    JobId = table.Column<long>(type: "bigint", nullable: false),
                    SkillId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUnnessecarySkills", x => new { x.SkillId, x.JobId });
                    table.ForeignKey(
                        name: "FK_JobUnnecessarySkills_Job",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobUnnecessarySkills_Skill",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerSkills_JobSeekerId",
                table: "JobSeekerSkills",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobUnnessecarySkills_JobId",
                table: "JobUnnessecarySkills",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSeekerSkills");

            migrationBuilder.DropTable(
                name: "JobUnnessecarySkills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 30, 13, 21, 50, 867, DateTimeKind.Local).AddTicks(5135),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 30, 16, 17, 47, 475, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.CreateTable(
                name: "JobSeekerEssentialSkills",
                columns: table => new
                {
                    SkillId = table.Column<short>(type: "smallint", nullable: false),
                    JobSeekerId = table.Column<long>(type: "bigint", nullable: false)
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
                    SkillId = table.Column<short>(type: "smallint", nullable: false),
                    JobSeekerId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "JobUnnecessarySkills",
                columns: table => new
                {
                    SkillId = table.Column<short>(type: "smallint", nullable: false),
                    JobId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobUnnecessarySkills", x => new { x.SkillId, x.JobId });
                    table.ForeignKey(
                        name: "FK_JobUnnecessarySkills_Job",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobUnnecessarySkills_Skill",
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

            migrationBuilder.CreateIndex(
                name: "IX_JobUnnecessarySkills_JobId",
                table: "JobUnnecessarySkills",
                column: "JobId");
        }
    }
}
