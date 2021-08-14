using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class ItemGroupInHierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchQuotationApprovalAction",
                table: "PurchQuotationApprovalLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "InventItemGroupId",
                table: "ItemHierarchy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemHierarchy_InventItemGroupId",
                table: "ItemHierarchy",
                column: "InventItemGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemHierarchy_InventItemGroup_InventItemGroupId",
                table: "ItemHierarchy",
                column: "InventItemGroupId",
                principalTable: "InventItemGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemHierarchy_InventItemGroup_InventItemGroupId",
                table: "ItemHierarchy");

            migrationBuilder.DropIndex(
                name: "IX_ItemHierarchy_InventItemGroupId",
                table: "ItemHierarchy");

            migrationBuilder.DropColumn(
                name: "PurchQuotationApprovalAction",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropColumn(
                name: "InventItemGroupId",
                table: "ItemHierarchy");
        }
    }
}
