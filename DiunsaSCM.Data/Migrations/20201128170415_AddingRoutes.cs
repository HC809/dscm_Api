using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class AddingRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Port");

            migrationBuilder.AddColumn<long>(
                name: "CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShippingRouteId",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "Port",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingRoute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingRoute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingStepType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingStepType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingRouteStep",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingRouteId = table.Column<long>(nullable: false),
                    ShippingStepTypeId = table.Column<long>(nullable: false),
                    StepNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingRouteStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingRouteStep_ShippingRoute_ShippingRouteId",
                        column: x => x.ShippingRouteId,
                        principalTable: "ShippingRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingRouteStep_ShippingStepType_ShippingStepTypeId",
                        column: x => x.ShippingStepTypeId,
                        principalTable: "ShippingStepType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentLogEntry",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchOrderShipmentHeaderId = table.Column<long>(nullable: false),
                    ShippingRouteStepId = table.Column<long>(nullable: false),
                    LogText = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentLogEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentLogEntry_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                        column: x => x.PurchOrderShipmentHeaderId,
                        principalTable: "PurchOrderShipmentHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentLogEntry_ShippingRouteStep_ShippingRouteStepId",
                        column: x => x.ShippingRouteStepId,
                        principalTable: "ShippingRouteStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader",
                column: "CurrentShippingRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_ShippingRouteId",
                table: "PurchOrderShipmentHeader",
                column: "ShippingRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Port_CountryId",
                table: "Port",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLogEntry_PurchOrderShipmentHeaderId",
                table: "ShipmentLogEntry",
                column: "PurchOrderShipmentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLogEntry_ShippingRouteStepId",
                table: "ShipmentLogEntry",
                column: "ShippingRouteStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRouteStep_ShippingRouteId",
                table: "ShippingRouteStep",
                column: "ShippingRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRouteStep_ShippingStepTypeId",
                table: "ShippingRouteStep",
                column: "ShippingStepTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Port_Country_CountryId",
                table: "Port",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader",
                column: "CurrentShippingRouteId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRoute_ShippingRouteId",
                table: "PurchOrderShipmentHeader",
                column: "ShippingRouteId",
                principalTable: "ShippingRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Port_Country_CountryId",
                table: "Port");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRoute_ShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "ShipmentLogEntry");

            migrationBuilder.DropTable(
                name: "ShippingRouteStep");

            migrationBuilder.DropTable(
                name: "ShippingRoute");

            migrationBuilder.DropTable(
                name: "ShippingStepType");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_ShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_Port_CountryId",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "ShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Port");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Port",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
