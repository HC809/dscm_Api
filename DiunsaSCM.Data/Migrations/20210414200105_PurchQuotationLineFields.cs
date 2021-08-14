using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PurchQuotationLineFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PurchQuotationLine");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorDescription",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventItemCode",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventItemDescription",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InventItemId",
                table: "PurchQuotationLine",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ItemBarcodeCode",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemBarcodeDescription",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ItemBarcodeId",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LineAmount",
                table: "PurchQuotationLine",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchPrice",
                table: "PurchQuotationLine",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "QtyOrdered",
                table: "PurchQuotationLine",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SizeCode",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeDescription",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SizeId",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLine_ColorId",
                table: "PurchQuotationLine",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLine_InventItemId",
                table: "PurchQuotationLine",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLine_ItemBarcodeId",
                table: "PurchQuotationLine",
                column: "ItemBarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLine_SizeId",
                table: "PurchQuotationLine",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLine_Color_ColorId",
                table: "PurchQuotationLine",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLine_InventItem_InventItemId",
                table: "PurchQuotationLine",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLine_ItemBarcode_ItemBarcodeId",
                table: "PurchQuotationLine",
                column: "ItemBarcodeId",
                principalTable: "ItemBarcode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLine_Size_SizeId",
                table: "PurchQuotationLine",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLine_Color_ColorId",
                table: "PurchQuotationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLine_InventItem_InventItemId",
                table: "PurchQuotationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLine_ItemBarcode_ItemBarcodeId",
                table: "PurchQuotationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLine_Size_SizeId",
                table: "PurchQuotationLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationLine_ColorId",
                table: "PurchQuotationLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationLine_InventItemId",
                table: "PurchQuotationLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationLine_ItemBarcodeId",
                table: "PurchQuotationLine");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationLine_SizeId",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "ColorDescription",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "InventItemCode",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "InventItemDescription",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "InventItemId",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "ItemBarcodeCode",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "ItemBarcodeDescription",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "ItemBarcodeId",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "LineAmount",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "PurchPrice",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "QtyOrdered",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "SizeCode",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "SizeDescription",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "PurchQuotationLine");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
