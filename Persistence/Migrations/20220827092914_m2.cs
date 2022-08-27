using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobEssentialSkills_Job",
                table: "JobEssentialSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEssentialSkills_Skill",
                table: "JobEssentialSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUnnecessarySkills_Job",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUnnecessarySkills_Skill",
                table: "JobUnnecessarySkills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 27, 13, 59, 14, 47, DateTimeKind.Local).AddTicks(4247),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 23, 15, 12, 18, 945, DateTimeKind.Local).AddTicks(6417));

            migrationBuilder.AddColumn<long>(
                name: "JobId1",
                table: "JobUnnecessarySkills",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "JobId1",
                table: "JobEssentialSkills",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobUnnecessarySkills_JobId1",
                table: "JobUnnecessarySkills",
                column: "JobId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobEssentialSkills_JobId1",
                table: "JobEssentialSkills",
                column: "JobId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobEssentialSkills_Job",
                table: "JobEssentialSkills",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEssentialSkills_Jobs_JobId1",
                table: "JobEssentialSkills",
                column: "JobId1",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobEssentialSkills_Skill",
                table: "JobEssentialSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobUnnecessarySkills_Job",
                table: "JobUnnecessarySkills",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobUnnecessarySkills_Jobs_JobId1",
                table: "JobUnnecessarySkills",
                column: "JobId1",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobUnnecessarySkills_Skill",
                table: "JobUnnecessarySkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobEssentialSkills_Job",
                table: "JobEssentialSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEssentialSkills_Jobs_JobId1",
                table: "JobEssentialSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEssentialSkills_Skill",
                table: "JobEssentialSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUnnecessarySkills_Job",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUnnecessarySkills_Jobs_JobId1",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobUnnecessarySkills_Skill",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropIndex(
                name: "IX_JobUnnecessarySkills_JobId1",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropIndex(
                name: "IX_JobEssentialSkills_JobId1",
                table: "JobEssentialSkills");

            migrationBuilder.DropColumn(
                name: "JobId1",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropColumn(
                name: "JobId1",
                table: "JobEssentialSkills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 23, 15, 12, 18, 945, DateTimeKind.Local).AddTicks(6417),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 27, 13, 59, 14, 47, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.AddForeignKey(
                name: "FK_JobEssentialSkills_Job",
                table: "JobEssentialSkills",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobEssentialSkills_Skill",
                table: "JobEssentialSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobUnnecessarySkills_Job",
                table: "JobUnnecessarySkills",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobUnnecessarySkills_Skill",
                table: "JobUnnecessarySkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}
