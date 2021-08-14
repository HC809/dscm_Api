using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class UniqueSalesPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPrice_InventItemId",
                table: "SalesPrice");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPrice_InventItemId_CustomerPriceGroupId",
                table: "SalesPrice",
                columns: new[] { "InventItemId", "CustomerPriceGroupId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SalesPrice_InventItemId_CustomerPriceGroupId",
                table: "SalesPrice");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPrice_InventItemId",
                table: "SalesPrice",
                column: "InventItemId");
        }
    }
}
