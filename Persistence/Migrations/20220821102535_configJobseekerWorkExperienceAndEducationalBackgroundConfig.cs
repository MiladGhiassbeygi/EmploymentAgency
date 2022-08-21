using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class configJobseekerWorkExperienceAndEducationalBackgroundConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationalBackgrounds_JobSeekers_JobSeekerId",
                table: "EducationalBackgrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_JobSeekers_JobSeekerId",
                table: "WorkExperiences");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 14, 55, 35, 657, DateTimeKind.Local).AddTicks(5369),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 21, 13, 54, 49, 122, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeeker_JobseekerEducationalBackground",
                table: "EducationalBackgrounds",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeeker_JobseekerWorkExperience",
                table: "WorkExperiences",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeeker_JobseekerEducationalBackground",
                table: "EducationalBackgrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeeker_JobseekerWorkExperience",
                table: "WorkExperiences");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 13, 54, 49, 122, DateTimeKind.Local).AddTicks(1852),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 21, 14, 55, 35, 657, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalBackgrounds_JobSeekers_JobSeekerId",
                table: "EducationalBackgrounds",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_JobSeekers_JobSeekerId",
                table: "WorkExperiences",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
