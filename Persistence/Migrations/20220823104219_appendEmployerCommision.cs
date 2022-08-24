using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class appendEmployerCommision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 23, 15, 12, 18, 945, DateTimeKind.Local).AddTicks(6417),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 23, 14, 58, 21, 272, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.CreateTable(
                name: "EmployerCommissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsFixed = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    EmployerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerCommissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerCommission_Employer",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployerCommissions_EmployerId",
                table: "EmployerCommissions",
                column: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployerCommissions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SuccessedContracts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 23, 14, 58, 21, 272, DateTimeKind.Local).AddTicks(7170),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2022, 8, 23, 15, 12, 18, 945, DateTimeKind.Local).AddTicks(6417));
        }
    }
}
