using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class VendorIdInPurchQuotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VendorId",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotation_VendorId",
                table: "PurchQuotation",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotation_Vendor_VendorId",
                table: "PurchQuotation",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotation_Vendor_VendorId",
                table: "PurchQuotation");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotation_VendorId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "PurchQuotation");
        }
    }
}
