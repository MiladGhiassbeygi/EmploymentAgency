using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class successedContractCorrectRelations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuccessedContracts_Employers_EmployerId",
                table: "SuccessedContracts");

            migrationBuilder.DropIndex(
                name: "IX_SuccessedContracts_EmployerId",
                table: "SuccessedContracts");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "SuccessedContracts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 23, 14, 58, 21, 272, DateTimeKind.Local).AddTicks(7170),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 23, 14, 38, 8, 136, DateTimeKind.Local).AddTicks(1117));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 23, 14, 38, 8, 136, DateTimeKind.Local).AddTicks(1117),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 23, 14, 58, 21, 272, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.AddColumn<long>(
                name: "EmployerId",
                table: "SuccessedContracts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuccessedContracts_EmployerId",
                table: "SuccessedContracts",
                column: "EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuccessedContracts_Employers_EmployerId",
                table: "SuccessedContracts",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id");
        }
    }
}
