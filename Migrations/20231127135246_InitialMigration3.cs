using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculationDeviceCheckPoint_CalculationDevices_CalculationD~",
                table: "CalculationDeviceCheckPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_CalculationDeviceCheckPoint_CheckPoints_CheckPointsCheckPoi~",
                table: "CalculationDeviceCheckPoint");

            migrationBuilder.RenameColumn(
                name: "CheckPointsCheckPointId",
                table: "CalculationDeviceCheckPoint",
                newName: "PointCheckPointId");

            migrationBuilder.RenameColumn(
                name: "CalculationDevicesCalculationDeviceId",
                table: "CalculationDeviceCheckPoint",
                newName: "DeviceCalculationDeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_CalculationDeviceCheckPoint_CheckPointsCheckPointId",
                table: "CalculationDeviceCheckPoint",
                newName: "IX_CalculationDeviceCheckPoint_PointCheckPointId");

            migrationBuilder.InsertData(
                table: "CalculationDevices",
                columns: new[] { "CalculationDeviceId", "Date", "Name" },
                values: new object[,]
                {
                    { 1, new DateOnly(1900, 1, 1), "CalculationDevice1" },
                    { 2, new DateOnly(2023, 11, 27), "CalculationDevice2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CalculationDeviceCheckPoint_CalculationDevices_DeviceCalcul~",
                table: "CalculationDeviceCheckPoint",
                column: "DeviceCalculationDeviceId",
                principalTable: "CalculationDevices",
                principalColumn: "CalculationDeviceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalculationDeviceCheckPoint_CheckPoints_PointCheckPointId",
                table: "CalculationDeviceCheckPoint",
                column: "PointCheckPointId",
                principalTable: "CheckPoints",
                principalColumn: "CheckPointId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalculationDeviceCheckPoint_CalculationDevices_DeviceCalcul~",
                table: "CalculationDeviceCheckPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_CalculationDeviceCheckPoint_CheckPoints_PointCheckPointId",
                table: "CalculationDeviceCheckPoint");

            migrationBuilder.DeleteData(
                table: "CalculationDevices",
                keyColumn: "CalculationDeviceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CalculationDevices",
                keyColumn: "CalculationDeviceId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "PointCheckPointId",
                table: "CalculationDeviceCheckPoint",
                newName: "CheckPointsCheckPointId");

            migrationBuilder.RenameColumn(
                name: "DeviceCalculationDeviceId",
                table: "CalculationDeviceCheckPoint",
                newName: "CalculationDevicesCalculationDeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_CalculationDeviceCheckPoint_PointCheckPointId",
                table: "CalculationDeviceCheckPoint",
                newName: "IX_CalculationDeviceCheckPoint_CheckPointsCheckPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalculationDeviceCheckPoint_CalculationDevices_CalculationD~",
                table: "CalculationDeviceCheckPoint",
                column: "CalculationDevicesCalculationDeviceId",
                principalTable: "CalculationDevices",
                principalColumn: "CalculationDeviceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalculationDeviceCheckPoint_CheckPoints_CheckPointsCheckPoi~",
                table: "CalculationDeviceCheckPoint",
                column: "CheckPointsCheckPointId",
                principalTable: "CheckPoints",
                principalColumn: "CheckPointId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
