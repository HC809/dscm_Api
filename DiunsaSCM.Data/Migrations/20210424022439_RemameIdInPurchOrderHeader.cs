using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class RemameIdInPurchOrderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchOrderHeader",
                table: "PurchOrderHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchOrderDetail",
                table: "PurchOrderDetail");

            migrationBuilder.DropColumn(
                name: "PurchOrderHeaderId",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "PurchOrderDetailId",
                table: "PurchOrderDetail");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PurchOrderHeader",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PurchOrderDetail",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchOrderHeader",
                table: "PurchOrderHeader",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchOrderDetail",
                table: "PurchOrderDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderDetail",
                column: "PurchOrderHeaderId",
                principalTable: "PurchOrderHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "PurchOrderShipmentDetail",
                column: "PurchOrderDetailId",
                principalTable: "PurchOrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderShipmentHeader",
                column: "PurchOrderHeaderId",
                principalTable: "PurchOrderHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "ShipmentContainerDetail",
                column: "PurchOrderDetailId",
                principalTable: "PurchOrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchOrderHeader",
                table: "PurchOrderHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchOrderDetail",
                table: "PurchOrderDetail");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PurchOrderDetail");

            migrationBuilder.AddColumn<long>(
                name: "PurchOrderHeaderId",
                table: "PurchOrderHeader",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "PurchOrderDetailId",
                table: "PurchOrderDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchOrderHeader",
                table: "PurchOrderHeader",
                column: "PurchOrderHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchOrderDetail",
                table: "PurchOrderDetail",
                column: "PurchOrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderDetail",
                column: "PurchOrderHeaderId",
                principalTable: "PurchOrderHeader",
                principalColumn: "PurchOrderHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "PurchOrderShipmentDetail",
                column: "PurchOrderDetailId",
                principalTable: "PurchOrderDetail",
                principalColumn: "PurchOrderDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderShipmentHeader",
                column: "PurchOrderHeaderId",
                principalTable: "PurchOrderHeader",
                principalColumn: "PurchOrderHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "ShipmentContainerDetail",
                column: "PurchOrderDetailId",
                principalTable: "PurchOrderDetail",
                principalColumn: "PurchOrderDetailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
