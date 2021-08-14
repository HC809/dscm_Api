using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class AddingShippingImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ShipmentImportId",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShipmentImport",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingRouteId = table.Column<long>(nullable: false),
                    CurrentShippingRouteStepId = table.Column<long>(nullable: false),
                    ShippingCompanyId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ShipmentDateRequested = table.Column<DateTime>(nullable: false),
                    ShipmentDateConfirmed = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    ReceiptDateConfirmed = table.Column<DateTime>(nullable: false),
                    BLNumber = table.Column<string>(nullable: true),
                    EstimatedVolume = table.Column<decimal>(nullable: false),
                    EstimatedWeight = table.Column<decimal>(nullable: false),
                    Incoterm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentImport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentImport_ShippingRouteStep_CurrentShippingRouteStepId",
                        column: x => x.CurrentShippingRouteStepId,
                        principalTable: "ShippingRouteStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentImport_ShippingCompany_ShippingCompanyId",
                        column: x => x.ShippingCompanyId,
                        principalTable: "ShippingCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentImport_ShippingRoute_ShippingRouteId",
                        column: x => x.ShippingRouteId,
                        principalTable: "ShippingRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_ShipmentImportId",
                table: "PurchOrderShipmentHeader",
                column: "ShipmentImportId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentImport_CurrentShippingRouteStepId",
                table: "ShipmentImport",
                column: "CurrentShippingRouteStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentImport_ShippingCompanyId",
                table: "ShipmentImport",
                column: "ShippingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentImport_ShippingRouteId",
                table: "ShipmentImport",
                column: "ShippingRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShipmentImport_ShipmentImportId",
                table: "PurchOrderShipmentHeader",
                column: "ShipmentImportId",
                principalTable: "ShipmentImport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShipmentImport_ShipmentImportId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropTable(
                name: "ShipmentImport");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_ShipmentImportId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "ShipmentImportId",
                table: "PurchOrderShipmentHeader");
        }
    }
}
