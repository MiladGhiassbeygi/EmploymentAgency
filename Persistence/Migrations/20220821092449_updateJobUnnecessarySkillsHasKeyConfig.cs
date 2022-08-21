using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class updateJobUnnecessarySkillsHasKeyConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobUnnecessarySkills_SkillId",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropIndex(
                name: "IX_JobEssentialSkills_SkillId",
                table: "JobEssentialSkills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 13, 54, 49, 122, DateTimeKind.Local).AddTicks(1852),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 21, 13, 1, 12, 817, DateTimeKind.Local).AddTicks(1642));

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobUnnecessarySkills",
                table: "JobUnnecessarySkills",
                columns: new[] { "SkillId", "JobId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobEssentialSkills",
                table: "JobEssentialSkills",
                columns: new[] { "SkillId", "JobId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobUnnecessarySkills",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobEssentialSkills",
                table: "JobEssentialSkills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 13, 1, 12, 817, DateTimeKind.Local).AddTicks(1642),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 21, 13, 54, 49, 122, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.CreateIndex(
                name: "IX_JobUnnecessarySkills_SkillId",
                table: "JobUnnecessarySkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEssentialSkills_SkillId",
                table: "JobEssentialSkills",
                column: "SkillId");
        }
    }
}
