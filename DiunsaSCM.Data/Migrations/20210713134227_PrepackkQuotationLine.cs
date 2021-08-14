using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PrepackkQuotationLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_InventItemPrepackBarcode_InventItemPrepackBarcodeId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_PurchQuotationLine_PurchQuotationLineId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationLinePrepackDetail_InventItemPrepackBarcodeId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentCrossDocking_ShipmentContainerDetailId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropIndex(
                name: "IX_InventItemPrepackBarcode_InventItemId",
                table: "InventItemPrepackBarcode");

            migrationBuilder.DropColumn(
                name: "InventItemPrepackBarcodeId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "PurchQuotationLinePrepackDetail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InventItemId",
                table: "PurchQuotationLinePrepackDetail",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ItemBarcodeId",
                table: "PurchQuotationLinePrepackDetail",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "QtyPerPrepack",
                table: "PurchQuotationLinePrepackDetail",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "SizeId",
                table: "PurchQuotationLinePrepackDetail",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchPrice",
                table: "InventItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLinePrepackDetail_ColorId",
                table: "PurchQuotationLinePrepackDetail",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLinePrepackDetail_InventItemId",
                table: "PurchQuotationLinePrepackDetail",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLinePrepackDetail_ItemBarcodeId",
                table: "PurchQuotationLinePrepackDetail",
                column: "ItemBarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLinePrepackDetail_SizeId",
                table: "PurchQuotationLinePrepackDetail",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentCrossDocking_ShipmentContainerDetailId_StoreId",
                table: "PurchOrderShipmentCrossDocking",
                columns: new[] { "ShipmentContainerDetailId", "StoreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventItemPrepackBarcode_InventItemId_ItemBarcodeId",
                table: "InventItemPrepackBarcode",
                columns: new[] { "InventItemId", "ItemBarcodeId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_Color_ColorId",
                table: "PurchQuotationLinePrepackDetail",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_InventItem_InventItemId",
                table: "PurchQuotationLinePrepackDetail",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_ItemBarcode_ItemBarcodeId",
                table: "PurchQuotationLinePrepackDetail",
                column: "ItemBarcodeId",
                principalTable: "ItemBarcode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_PurchQuotationLine_PurchQuotationLineId",
                table: "PurchQuotationLinePrepackDetail",
                column: "PurchQuotationLineId",
                principalTable: "PurchQuotationLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_Size_SizeId",
                table: "PurchQuotationLinePrepackDetail",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_Color_ColorId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_InventItem_InventItemId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_ItemBarcode_ItemBarcodeId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_PurchQuotationLine_PurchQuotationLineId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_Size_SizeId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationLinePrepackDetail_ColorId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationLinePrepackDetail_InventItemId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationLinePrepackDetail_ItemBarcodeId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationLinePrepackDetail_SizeId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentCrossDocking_ShipmentContainerDetailId_StoreId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropIndex(
                name: "IX_InventItemPrepackBarcode_InventItemId_ItemBarcodeId",
                table: "InventItemPrepackBarcode");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropColumn(
                name: "InventItemId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropColumn(
                name: "ItemBarcodeId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropColumn(
                name: "QtyPerPrepack",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropColumn(
                name: "PurchPrice",
                table: "InventItem");

            migrationBuilder.AddColumn<long>(
                name: "InventItemPrepackBarcodeId",
                table: "PurchQuotationLinePrepackDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLinePrepackDetail_InventItemPrepackBarcodeId",
                table: "PurchQuotationLinePrepackDetail",
                column: "InventItemPrepackBarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentCrossDocking_ShipmentContainerDetailId",
                table: "PurchOrderShipmentCrossDocking",
                column: "ShipmentContainerDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemPrepackBarcode_InventItemId",
                table: "InventItemPrepackBarcode",
                column: "InventItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_InventItemPrepackBarcode_InventItemPrepackBarcodeId",
                table: "PurchQuotationLinePrepackDetail",
                column: "InventItemPrepackBarcodeId",
                principalTable: "InventItemPrepackBarcode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLinePrepackDetail_PurchQuotationLine_PurchQuotationLineId",
                table: "PurchQuotationLinePrepackDetail",
                column: "PurchQuotationLineId",
                principalTable: "PurchQuotationLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
