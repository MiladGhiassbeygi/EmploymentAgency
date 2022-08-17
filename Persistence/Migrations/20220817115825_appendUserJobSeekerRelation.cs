using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class appendUserJobSeekerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 17, 16, 28, 25, 277, DateTimeKind.Local).AddTicks(1973),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 16, 18, 59, 21, 545, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.AddColumn<int>(
                name: "DefinerId",
                table: "JobSeekers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_DefinerId",
                table: "JobSeekers",
                column: "DefinerId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_Users_DefinerId",
                table: "JobSeekers",
                column: "DefinerId",
                principalSchema: "usr",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_Users_DefinerId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_DefinerId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "DefinerId",
                table: "JobSeekers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 16, 18, 59, 21, 545, DateTimeKind.Local).AddTicks(1780),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 17, 16, 28, 25, 277, DateTimeKind.Local).AddTicks(1973));
        }
    }
}
