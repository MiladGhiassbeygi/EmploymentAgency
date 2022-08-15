using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class correctEmployerFieldsAndDeleteEmployerCommissionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployerCommissions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 15, 12, 21, 15, 503, DateTimeKind.Local).AddTicks(9302),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 14, 18, 1, 21, 589, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.AddColumn<decimal>(
                name: "ExactAmountRecived",
                table: "Employers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixed",
                table: "Employers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExactAmountRecived",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "IsFixed",
                table: "Employers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 14, 18, 1, 21, 589, DateTimeKind.Local).AddTicks(7566),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 15, 12, 21, 15, 503, DateTimeKind.Local).AddTicks(9302));

            migrationBuilder.CreateTable(
                name: "EmployerCommissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsFixed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerCommissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerCommission_EmployerInformation",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployerCommissions_EmployerId",
                table: "EmployerCommissions",
                column: "EmployerId");
        }
    }
}
