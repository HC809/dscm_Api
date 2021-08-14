using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class ModifyingRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_Port_PortOfDestinationId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_Port_PortOfOriginId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_PortOfDestinationId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_PortOfOriginId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "PortOfDestinationId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "PortOfOriginId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "Route",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "TransitTime",
                table: "Port");

            migrationBuilder.AddColumn<int>(
                name: "TransitTimeDays",
                table: "ShippingRouteStep",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransitTimeHours",
                table: "ShippingRouteStep",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PortOfDestinationId",
                table: "ShippingRoute",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PortOfOriginId",
                table: "ShippingRoute",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransportationMethod",
                table: "ShippingRoute",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.RenameColumn(
                name: "CurrentShippingRouteId",
                newName: "CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRoute_PortOfDestinationId",
                table: "ShippingRoute",
                column: "PortOfDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRoute_PortOfOriginId",
                table: "ShippingRoute",
                column: "PortOfOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                column: "CurrentShippingRouteStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                column: "CurrentShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingRoute_Port_PortOfDestinationId",
                table: "ShippingRoute",
                column: "PortOfDestinationId",
                principalTable: "Port",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingRoute_Port_PortOfOriginId",
                table: "ShippingRoute",
                column: "PortOfOriginId",
                principalTable: "Port",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingRoute_Port_PortOfDestinationId",
                table: "ShippingRoute");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingRoute_Port_PortOfOriginId",
                table: "ShippingRoute");

            migrationBuilder.DropIndex(
                name: "IX_ShippingRoute_PortOfDestinationId",
                table: "ShippingRoute");

            migrationBuilder.DropIndex(
                name: "IX_ShippingRoute_PortOfOriginId",
                table: "ShippingRoute");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "TransitTimeDays",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "TransitTimeHours",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "PortOfDestinationId",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "PortOfOriginId",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "TransportationMethod",
                table: "ShippingRoute");

            migrationBuilder.RenameColumn(
                name: "CurrentShippingRouteStepId",
                newName: "CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.AddColumn<long>(
                name: "PortOfDestinationId",
                table: "PurchOrderShipmentHeader",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PortOfOriginId",
                table: "PurchOrderShipmentHeader",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Route",
                table: "Port",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TransitTime",
                table: "Port",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader",
                column: "CurrentShippingRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_PortOfDestinationId",
                table: "PurchOrderShipmentHeader",
                column: "PortOfDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_PortOfOriginId",
                table: "PurchOrderShipmentHeader",
                column: "PortOfOriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteId",
                table: "PurchOrderShipmentHeader",
                column: "CurrentShippingRouteId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_Port_PortOfDestinationId",
                table: "PurchOrderShipmentHeader",
                column: "PortOfDestinationId",
                principalTable: "Port",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_Port_PortOfOriginId",
                table: "PurchOrderShipmentHeader",
                column: "PortOfOriginId",
                principalTable: "Port",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
