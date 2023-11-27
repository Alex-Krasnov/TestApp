using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Addres = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "ChildOrganizations",
                columns: table => new
                {
                    ChildOrganizationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Addres = table.Column<string>(type: "text", nullable: false),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildOrganizations", x => x.ChildOrganizationId);
                    table.ForeignKey(
                        name: "FK_ChildOrganizations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjConsumptions",
                columns: table => new
                {
                    ObjConsumptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Addres = table.Column<string>(type: "text", nullable: false),
                    ChildOrganizationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjConsumptions", x => x.ObjConsumptionId);
                    table.ForeignKey(
                        name: "FK_ObjConsumptions_ChildOrganizations_ChildOrganizationId",
                        column: x => x.ChildOrganizationId,
                        principalTable: "ChildOrganizations",
                        principalColumn: "ChildOrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckPoints",
                columns: table => new
                {
                    CheckPointId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ObjConsumptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckPoints", x => x.CheckPointId);
                    table.ForeignKey(
                        name: "FK_CheckPoints_ObjConsumptions_ObjConsumptionId",
                        column: x => x.ObjConsumptionId,
                        principalTable: "ObjConsumptions",
                        principalColumn: "ObjConsumptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricitySupplyPoints",
                columns: table => new
                {
                    ElectricitySupplyPointId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxPower = table.Column<int>(type: "integer", nullable: false),
                    ObjConsumptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricitySupplyPoints", x => x.ElectricitySupplyPointId);
                    table.ForeignKey(
                        name: "FK_ElectricitySupplyPoints_ObjConsumptions_ObjConsumptionId",
                        column: x => x.ObjConsumptionId,
                        principalTable: "ObjConsumptions",
                        principalColumn: "ObjConsumptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTransformers",
                columns: table => new
                {
                    CurrentTransformerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    CurrentTransformerType = table.Column<string>(type: "text", nullable: false),
                    CheckDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TransformationCoefficient = table.Column<int>(type: "integer", nullable: false),
                    CheckPointId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTransformers", x => x.CurrentTransformerId);
                    table.ForeignKey(
                        name: "FK_CurrentTransformers_CheckPoints_CheckPointId",
                        column: x => x.CheckPointId,
                        principalTable: "CheckPoints",
                        principalColumn: "CheckPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityMeters",
                columns: table => new
                {
                    ElectricityMeterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    CheckDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckPointId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeters", x => x.ElectricityMeterId);
                    table.ForeignKey(
                        name: "FK_ElectricityMeters_CheckPoints_CheckPointId",
                        column: x => x.CheckPointId,
                        principalTable: "CheckPoints",
                        principalColumn: "CheckPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoltageTransformers",
                columns: table => new
                {
                    VoltageTransformerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    VoltageTransformerType = table.Column<string>(type: "text", nullable: false),
                    CheckDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TransformationCoefficient = table.Column<int>(type: "integer", nullable: false),
                    CheckPointId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoltageTransformers", x => x.VoltageTransformerId);
                    table.ForeignKey(
                        name: "FK_VoltageTransformers_CheckPoints_CheckPointId",
                        column: x => x.CheckPointId,
                        principalTable: "CheckPoints",
                        principalColumn: "CheckPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "Addres", "Name" },
                values: new object[,]
                {
                    { 1, "Street1", "Organization1" },
                    { 2, "Street2", "Organization2" }
                });

            migrationBuilder.InsertData(
                table: "ChildOrganizations",
                columns: new[] { "ChildOrganizationId", "Addres", "Name", "OrganizationId" },
                values: new object[,]
                {
                    { 1, "Street1", "ChildOrganization1", 1 },
                    { 2, "Street2", "ChildOrganization2", 1 },
                    { 3, "Street3", "ChildOrganization3", 2 }
                });

            migrationBuilder.InsertData(
                table: "ObjConsumptions",
                columns: new[] { "ObjConsumptionId", "Addres", "ChildOrganizationId", "Name" },
                values: new object[,]
                {
                    { 1, "Street1", 1, "ObjConsumption1" },
                    { 2, "Street2", 2, "ObjConsumption2" },
                    { 3, "Street3", 3, "ObjConsumption3" },
                    { 4, "Street4", 3, "ObjConsumption4" }
                });

            migrationBuilder.InsertData(
                table: "CheckPoints",
                columns: new[] { "CheckPointId", "Name", "ObjConsumptionId" },
                values: new object[,]
                {
                    { 1, "CheckPoint1", 1 },
                    { 2, "CheckPoint2", 1 },
                    { 3, "CheckPoint3", 2 },
                    { 4, "CheckPoint4", 3 },
                    { 5, "CheckPoint5", 3 }
                });

            migrationBuilder.InsertData(
                table: "ElectricitySupplyPoints",
                columns: new[] { "ElectricitySupplyPointId", "MaxPower", "Name", "ObjConsumptionId" },
                values: new object[,]
                {
                    { 1, 1, "ElectricitySupplyPoint1", 1 },
                    { 2, 2, "ElectricitySupplyPoint2", 1 },
                    { 3, 3, "ElectricitySupplyPoint3", 2 },
                    { 4, 4, "ElectricitySupplyPoint4", 3 },
                    { 5, 3, "ElectricitySupplyPoint5", 4 }
                });

            migrationBuilder.InsertData(
                table: "CurrentTransformers",
                columns: new[] { "CurrentTransformerId", "CheckDate", "CheckPointId", "CurrentTransformerType", "Number", "TransformationCoefficient" },
                values: new object[,]
                {
                    { 1, new DateOnly(1900, 1, 1), 1, "Type1", 1, 0 },
                    { 2, new DateOnly(1900, 1, 1), 2, "Type2", 2, 0 },
                    { 3, new DateOnly(2023, 11, 26), 3, "Type3", 3, 0 },
                    { 4, new DateOnly(2023, 11, 26), 4, "Type4", 4, 0 },
                    { 5, new DateOnly(2023, 11, 26), 5, "Type3", 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "ElectricityMeters",
                columns: new[] { "ElectricityMeterId", "CheckDate", "CheckPointId", "Number" },
                values: new object[,]
                {
                    { 1, new DateOnly(1900, 1, 1), 1, 1 },
                    { 2, new DateOnly(1900, 1, 1), 2, 2 },
                    { 3, new DateOnly(2023, 11, 26), 3, 3 },
                    { 4, new DateOnly(2023, 11, 26), 4, 4 },
                    { 5, new DateOnly(2023, 11, 26), 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "VoltageTransformers",
                columns: new[] { "VoltageTransformerId", "CheckDate", "CheckPointId", "Number", "TransformationCoefficient", "VoltageTransformerType" },
                values: new object[,]
                {
                    { 1, new DateOnly(1900, 1, 1), 1, 1, 0, "Type1" },
                    { 2, new DateOnly(1900, 1, 1), 2, 2, 0, "Type2" },
                    { 3, new DateOnly(2023, 11, 26), 3, 3, 0, "Type3" },
                    { 4, new DateOnly(2023, 11, 26), 4, 4, 0, "Type4" },
                    { 5, new DateOnly(2023, 11, 26), 5, 5, 0, "Type3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckPoints_ObjConsumptionId",
                table: "CheckPoints",
                column: "ObjConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildOrganizations_OrganizationId",
                table: "ChildOrganizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentTransformers_CheckPointId",
                table: "CurrentTransformers",
                column: "CheckPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeters_CheckPointId",
                table: "ElectricityMeters",
                column: "CheckPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricitySupplyPoints_ObjConsumptionId",
                table: "ElectricitySupplyPoints",
                column: "ObjConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjConsumptions_ChildOrganizationId",
                table: "ObjConsumptions",
                column: "ChildOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_VoltageTransformers_CheckPointId",
                table: "VoltageTransformers",
                column: "CheckPointId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTransformers");

            migrationBuilder.DropTable(
                name: "ElectricityMeters");

            migrationBuilder.DropTable(
                name: "ElectricitySupplyPoints");

            migrationBuilder.DropTable(
                name: "VoltageTransformers");

            migrationBuilder.DropTable(
                name: "CheckPoints");

            migrationBuilder.DropTable(
                name: "ObjConsumptions");

            migrationBuilder.DropTable(
                name: "ChildOrganizations");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
