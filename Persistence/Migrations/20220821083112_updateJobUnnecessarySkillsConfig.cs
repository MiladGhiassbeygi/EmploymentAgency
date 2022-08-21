using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class updateJobUnnecessarySkillsConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobUnnecessarySkills");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "JobUnnecessarySkills");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 13, 1, 12, 817, DateTimeKind.Local).AddTicks(1642),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 21, 12, 56, 30, 293, DateTimeKind.Local).AddTicks(2519));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 12, 56, 30, 293, DateTimeKind.Local).AddTicks(2519),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 21, 13, 1, 12, 817, DateTimeKind.Local).AddTicks(1642));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "JobUnnecessarySkills",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JobUnnecessarySkills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "JobUnnecessarySkills",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
