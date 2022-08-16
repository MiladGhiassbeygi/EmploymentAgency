using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class changeSomeFileds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 16, 18, 59, 21, 545, DateTimeKind.Local).AddTicks(1780),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 15, 12, 21, 15, 503, DateTimeKind.Local).AddTicks(9302));

            migrationBuilder.AddColumn<int>(
                name: "DefinerId",
                table: "Employers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employers_DefinerId",
                table: "Employers",
                column: "DefinerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employer_EmployerDefiner",
                table: "Employers",
                column: "DefinerId",
                principalSchema: "usr",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employer_EmployerDefiner",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_DefinerId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "DefinerId",
                table: "Employers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 15, 12, 21, 15, 503, DateTimeKind.Local).AddTicks(9302),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 16, 18, 59, 21, 545, DateTimeKind.Local).AddTicks(1780));
        }
    }
}
