using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class successedContractCorrectRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuccessedContract_Employer",
                table: "SuccessedContracts");

            migrationBuilder.RenameColumn(
                name: "EmploymentAgencyId",
                table: "SuccessedContracts",
                newName: "ContractCreatorId");

            migrationBuilder.AlterColumn<long>(
                name: "EmployerId",
                table: "SuccessedContracts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 23, 14, 38, 8, 136, DateTimeKind.Local).AddTicks(1117),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 21, 15, 20, 10, 3, DateTimeKind.Local).AddTicks(8590));

            migrationBuilder.AddColumn<long>(
                name: "JobId",
                table: "SuccessedContracts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SuccessedContracts_ContractCreatorId",
                table: "SuccessedContracts",
                column: "ContractCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SuccessedContracts_JobId",
                table: "SuccessedContracts",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuccessedContract_Job",
                table: "SuccessedContracts",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SuccessedContracts_Employers_EmployerId",
                table: "SuccessedContracts",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SuccessedContracts_Users_ContractCreatorId",
                table: "SuccessedContracts",
                column: "ContractCreatorId",
                principalSchema: "usr",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuccessedContract_Job",
                table: "SuccessedContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_SuccessedContracts_Employers_EmployerId",
                table: "SuccessedContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_SuccessedContracts_Users_ContractCreatorId",
                table: "SuccessedContracts");

            migrationBuilder.DropIndex(
                name: "IX_SuccessedContracts_ContractCreatorId",
                table: "SuccessedContracts");

            migrationBuilder.DropIndex(
                name: "IX_SuccessedContracts_JobId",
                table: "SuccessedContracts");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "SuccessedContracts");

            migrationBuilder.RenameColumn(
                name: "ContractCreatorId",
                table: "SuccessedContracts",
                newName: "EmploymentAgencyId");

            migrationBuilder.AlterColumn<long>(
                name: "EmployerId",
                table: "SuccessedContracts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 21, 15, 20, 10, 3, DateTimeKind.Local).AddTicks(8590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 23, 14, 38, 8, 136, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.AddForeignKey(
                name: "FK_SuccessedContract_Employer",
                table: "SuccessedContracts",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
