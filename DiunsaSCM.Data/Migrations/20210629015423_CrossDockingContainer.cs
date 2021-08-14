using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class CrossDockingContainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentCrossDocking_PurchOrderShipmentDetail_PurchOrderShipmentDetailId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentCrossDocking_PurchOrderShipmentDetailId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropColumn(
                name: "PurchOrderShipmentDetailId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.AddColumn<long>(
                name: "ShipmentContainerDetailId",
                table: "PurchOrderShipmentCrossDocking",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentCrossDocking_ShipmentContainerDetailId",
                table: "PurchOrderShipmentCrossDocking",
                column: "ShipmentContainerDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentCrossDocking_ShipmentContainerDetail_ShipmentContainerDetailId",
                table: "PurchOrderShipmentCrossDocking",
                column: "ShipmentContainerDetailId",
                principalTable: "ShipmentContainerDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentCrossDocking_ShipmentContainerDetail_ShipmentContainerDetailId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentCrossDocking_ShipmentContainerDetailId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropColumn(
                name: "ShipmentContainerDetailId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.AddColumn<long>(
                name: "PurchOrderShipmentDetailId",
                table: "PurchOrderShipmentCrossDocking",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentCrossDocking_PurchOrderShipmentDetailId",
                table: "PurchOrderShipmentCrossDocking",
                column: "PurchOrderShipmentDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentCrossDocking_PurchOrderShipmentDetail_PurchOrderShipmentDetailId",
                table: "PurchOrderShipmentCrossDocking",
                column: "PurchOrderShipmentDetailId",
                principalTable: "PurchOrderShipmentDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
