using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class BarcodeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarcodeSetupId",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "InventColorId",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "InventSizeId",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "NameAlias",
                table: "ItemBarcode");

            migrationBuilder.AddColumn<long>(
                name: "InventDimId",
                table: "ItemBarcode",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InventItemId",
                table: "ItemBarcode",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ItemBarcode_InventDimId",
                table: "ItemBarcode",
                column: "InventDimId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBarcode_InventItemId",
                table: "ItemBarcode",
                column: "InventItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemBarcode_InventDim_InventDimId",
                table: "ItemBarcode",
                column: "InventDimId",
                principalTable: "InventDim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemBarcode_InventItem_InventItemId",
                table: "ItemBarcode",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemBarcode_InventDim_InventDimId",
                table: "ItemBarcode");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemBarcode_InventItem_InventItemId",
                table: "ItemBarcode");

            migrationBuilder.DropIndex(
                name: "IX_ItemBarcode_InventDimId",
                table: "ItemBarcode");

            migrationBuilder.DropIndex(
                name: "IX_ItemBarcode_InventItemId",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "InventDimId",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "InventItemId",
                table: "ItemBarcode");

            migrationBuilder.AddColumn<string>(
                name: "BarcodeSetupId",
                table: "ItemBarcode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "ItemBarcode",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "InventColorId",
                table: "ItemBarcode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventSizeId",
                table: "ItemBarcode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemId",
                table: "ItemBarcode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ItemBarcode",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAlias",
                table: "ItemBarcode",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
