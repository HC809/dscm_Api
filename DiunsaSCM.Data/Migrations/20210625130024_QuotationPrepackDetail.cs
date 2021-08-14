using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class QuotationPrepackDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentCrossDocking_Warehouse_WarehouseId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentCrossDocking_WarehouseId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "PurchOrderShipmentCrossDocking",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "PurchQuotationLinePrepackDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchPrice = table.Column<decimal>(nullable: false),
                    InventItemPrepackBarcodeId = table.Column<long>(nullable: false),
                    PurchQuotationLineId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationLinePrepackDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchQuotationLinePrepackDetail_InventItemPrepackBarcode_InventItemPrepackBarcodeId",
                        column: x => x.InventItemPrepackBarcodeId,
                        principalTable: "InventItemPrepackBarcode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchQuotationLinePrepackDetail_PurchQuotationLine_PurchQuotationLineId",
                        column: x => x.PurchQuotationLineId,
                        principalTable: "PurchQuotationLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentCrossDocking_StoreId",
                table: "PurchOrderShipmentCrossDocking",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLinePrepackDetail_InventItemPrepackBarcodeId",
                table: "PurchQuotationLinePrepackDetail",
                column: "InventItemPrepackBarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLinePrepackDetail_PurchQuotationLineId",
                table: "PurchQuotationLinePrepackDetail",
                column: "PurchQuotationLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentCrossDocking_Store_StoreId",
                table: "PurchOrderShipmentCrossDocking",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentCrossDocking_Store_StoreId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropTable(
                name: "PurchQuotationLinePrepackDetail");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentCrossDocking_StoreId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "PurchOrderShipmentCrossDocking");

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                table: "PurchOrderShipmentCrossDocking",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentCrossDocking_WarehouseId",
                table: "PurchOrderShipmentCrossDocking",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentCrossDocking_Warehouse_WarehouseId",
                table: "PurchOrderShipmentCrossDocking",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
