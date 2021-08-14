using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class ItemFieldsInPurchoOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "PurchOrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventColorId",
                table: "PurchOrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventSizeId",
                table: "PurchOrderDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "PurchOrderDetail");

            migrationBuilder.DropColumn(
                name: "InventColorId",
                table: "PurchOrderDetail");

            migrationBuilder.DropColumn(
                name: "InventSizeId",
                table: "PurchOrderDetail");
        }
    }
}
