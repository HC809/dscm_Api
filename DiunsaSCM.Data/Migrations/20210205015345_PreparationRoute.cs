using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PreparationRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PreparationShippingRouteId",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                column: "PreparationCurrentShippingRouteStepId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_PreparationShippingRouteId",
                table: "PurchOrderShipmentHeader",
                column: "PreparationShippingRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                column: "PreparationCurrentShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRoute_PreparationShippingRouteId",
                table: "PurchOrderShipmentHeader",
                column: "PreparationShippingRouteId",
                principalTable: "ShippingRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRoute_PreparationShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_PreparationShippingRouteId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "PreparationShippingRouteId",
                table: "PurchOrderShipmentHeader");
        }
    }
}
