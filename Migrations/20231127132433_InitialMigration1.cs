using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationDevices",
                columns: table => new
                {
                    CalculationDeviceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationDevices", x => x.CalculationDeviceId);
                });

            migrationBuilder.CreateTable(
                name: "CalculationDeviceCheckPoint",
                columns: table => new
                {
                    CalculationDevicesCalculationDeviceId = table.Column<int>(type: "integer", nullable: false),
                    CheckPointsCheckPointId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationDeviceCheckPoint", x => new { x.CalculationDevicesCalculationDeviceId, x.CheckPointsCheckPointId });
                    table.ForeignKey(
                        name: "FK_CalculationDeviceCheckPoint_CalculationDevices_CalculationD~",
                        column: x => x.CalculationDevicesCalculationDeviceId,
                        principalTable: "CalculationDevices",
                        principalColumn: "CalculationDeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalculationDeviceCheckPoint_CheckPoints_CheckPointsCheckPoi~",
                        column: x => x.CheckPointsCheckPointId,
                        principalTable: "CheckPoints",
                        principalColumn: "CheckPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CurrentTransformers",
                keyColumn: "CurrentTransformerId",
                keyValue: 3,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 27));

            migrationBuilder.UpdateData(
                table: "CurrentTransformers",
                keyColumn: "CurrentTransformerId",
                keyValue: 4,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 27));

            migrationBuilder.UpdateData(
                table: "CurrentTransformers",
                keyColumn: "CurrentTransformerId",
                keyValue: 5,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 27));

            migrationBuilder.UpdateData(
                table: "ElectricityMeters",
                keyColumn: "ElectricityMeterId",
                keyValue: 3,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 27));

            migrationBuilder.UpdateData(
                table: "ElectricityMeters",
                keyColumn: "ElectricityMeterId",
                keyValue: 4,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 27));

            migrationBuilder.UpdateData(
                table: "ElectricityMeters",
                keyColumn: "ElectricityMeterId",
                keyValue: 5,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 27));

            migrationBuilder.UpdateData(
                table: "VoltageTransformers",
                keyColumn: "VoltageTransformerId",
                keyValue: 3,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 27));

            migrationBuilder.UpdateData(
                table: "VoltageTransformers",
                keyColumn: "VoltageTransformerId",
                keyValue: 4,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 27));

            migrationBuilder.UpdateData(
                table: "VoltageTransformers",
                keyColumn: "VoltageTransformerId",
                keyValue: 5,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 27));

            migrationBuilder.CreateIndex(
                name: "IX_CalculationDeviceCheckPoint_CheckPointsCheckPointId",
                table: "CalculationDeviceCheckPoint",
                column: "CheckPointsCheckPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationDeviceCheckPoint");

            migrationBuilder.DropTable(
                name: "CalculationDevices");

            migrationBuilder.UpdateData(
                table: "CurrentTransformers",
                keyColumn: "CurrentTransformerId",
                keyValue: 3,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 26));

            migrationBuilder.UpdateData(
                table: "CurrentTransformers",
                keyColumn: "CurrentTransformerId",
                keyValue: 4,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 26));

            migrationBuilder.UpdateData(
                table: "CurrentTransformers",
                keyColumn: "CurrentTransformerId",
                keyValue: 5,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 26));

            migrationBuilder.UpdateData(
                table: "ElectricityMeters",
                keyColumn: "ElectricityMeterId",
                keyValue: 3,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 26));

            migrationBuilder.UpdateData(
                table: "ElectricityMeters",
                keyColumn: "ElectricityMeterId",
                keyValue: 4,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 26));

            migrationBuilder.UpdateData(
                table: "ElectricityMeters",
                keyColumn: "ElectricityMeterId",
                keyValue: 5,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 26));

            migrationBuilder.UpdateData(
                table: "VoltageTransformers",
                keyColumn: "VoltageTransformerId",
                keyValue: 3,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 26));

            migrationBuilder.UpdateData(
                table: "VoltageTransformers",
                keyColumn: "VoltageTransformerId",
                keyValue: 4,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 26));

            migrationBuilder.UpdateData(
                table: "VoltageTransformers",
                keyColumn: "VoltageTransformerId",
                keyValue: 5,
                column: "CheckDate",
                value: new DateOnly(2023, 11, 26));
        }
    }
}
