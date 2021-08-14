
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class TaxInInventItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_EmployeeDiscounts_EmployeeDiscountId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_InventModelGroups_InventModelGroupId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_ItemHierarchies_ItemHierarchyId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_Vendors_VendorId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItemStoreConfigurations_InventItem_InventItemId",
                table: "InventItemStoreConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItemStoreConfigurations_Store_StoreId",
                table: "InventItemStoreConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_CommercialEvents_CommercialEventId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropTable(
                name: "EmployeeDiscounts");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_EmployeeDiscountId",
                table: "InventItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchQuotationApprovals",
                table: "PurchQuotationApprovals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemHierarchies",
                table: "ItemHierarchies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventModelGroups",
                table: "InventModelGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventItemStoreConfigurations",
                table: "InventItemStoreConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommercialEvents",
                table: "CommercialEvents");

            migrationBuilder.DropColumn(
                name: "EmployeeDiscountId",
                table: "InventItem");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "Vendor");

            migrationBuilder.RenameTable(
                name: "PurchQuotationApprovals",
                newName: "PurchQuotationApproval");

            migrationBuilder.RenameTable(
                name: "ItemHierarchies",
                newName: "ItemHierarchy");

            migrationBuilder.RenameTable(
                name: "InventModelGroups",
                newName: "InventModelGroup");

            migrationBuilder.RenameTable(
                name: "InventItemStoreConfigurations",
                newName: "InventItemStoreConfiguration");

            migrationBuilder.RenameTable(
                name: "CommercialEvents",
                newName: "CommercialEvent");

            migrationBuilder.RenameIndex(
                name: "IX_InventItemStoreConfigurations_StoreId",
                table: "InventItemStoreConfiguration",
                newName: "IX_InventItemStoreConfiguration_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_InventItemStoreConfigurations_InventItemId",
                table: "InventItemStoreConfiguration",
                newName: "IX_InventItemStoreConfiguration_InventItemId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDiscountType",
                table: "InventItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "InventDimGroupId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaxItemGroupHeadingId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchQuotationApproval",
                table: "PurchQuotationApproval",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemHierarchy",
                table: "ItemHierarchy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventModelGroup",
                table: "InventModelGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventItemStoreConfiguration",
                table: "InventItemStoreConfiguration",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommercialEvent",
                table: "CommercialEvent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_InventDimGroupId",
                table: "InventItem",
                column: "InventDimGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_TaxItemGroupHeadingId",
                table: "InventItem",
                column: "TaxItemGroupHeadingId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_InventDimGroup_InventDimGroupId",
                table: "InventItem",
                column: "InventDimGroupId",
                principalTable: "InventDimGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_InventModelGroup_InventModelGroupId",
                table: "InventItem",
                column: "InventModelGroupId",
                principalTable: "InventModelGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_ItemHierarchy_ItemHierarchyId",
                table: "InventItem",
                column: "ItemHierarchyId",
                principalTable: "ItemHierarchy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "InventItem",
                column: "TaxItemGroupHeadingId",
                principalTable: "TaxItemGroupHeading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_Vendor_VendorId",
                table: "InventItem",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItemStoreConfiguration_InventItem_InventItemId",
                table: "InventItemStoreConfiguration",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItemStoreConfiguration_Store_StoreId",
                table: "InventItemStoreConfiguration",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_CommercialEvent_CommercialEventId",
                table: "PurchOrderShipmentHeader",
                column: "CommercialEventId",
                principalTable: "CommercialEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_InventDimGroup_InventDimGroupId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_InventModelGroup_InventModelGroupId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_ItemHierarchy_ItemHierarchyId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_Vendor_VendorId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItemStoreConfiguration_InventItem_InventItemId",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItemStoreConfiguration_Store_StoreId",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_CommercialEvent_CommercialEventId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_InventDimGroupId",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_TaxItemGroupHeadingId",
                table: "InventItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchQuotationApproval",
                table: "PurchQuotationApproval");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemHierarchy",
                table: "ItemHierarchy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventModelGroup",
                table: "InventModelGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventItemStoreConfiguration",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommercialEvent",
                table: "CommercialEvent");

            migrationBuilder.DropColumn(
                name: "EmployeeDiscountType",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "InventDimGroupId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "TaxItemGroupHeadingId",
                table: "InventItem");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Vendors");

            migrationBuilder.RenameTable(
                name: "PurchQuotationApproval",
                newName: "PurchQuotationApprovals");

            migrationBuilder.RenameTable(
                name: "ItemHierarchy",
                newName: "ItemHierarchies");

            migrationBuilder.RenameTable(
                name: "InventModelGroup",
                newName: "InventModelGroups");

            migrationBuilder.RenameTable(
                name: "InventItemStoreConfiguration",
                newName: "InventItemStoreConfigurations");

            migrationBuilder.RenameTable(
                name: "CommercialEvent",
                newName: "CommercialEvents");

            migrationBuilder.RenameIndex(
                name: "IX_InventItemStoreConfiguration_StoreId",
                table: "InventItemStoreConfigurations",
                newName: "IX_InventItemStoreConfigurations_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_InventItemStoreConfiguration_InventItemId",
                table: "InventItemStoreConfigurations",
                newName: "IX_InventItemStoreConfigurations_InventItemId");

            migrationBuilder.AddColumn<long>(
                name: "EmployeeDiscountId",
                table: "InventItem",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchQuotationApprovals",
                table: "PurchQuotationApprovals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemHierarchies",
                table: "ItemHierarchies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventModelGroups",
                table: "InventModelGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventItemStoreConfigurations",
                table: "InventItemStoreConfigurations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommercialEvents",
                table: "CommercialEvents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmployeeDiscounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDiscounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_EmployeeDiscountId",
                table: "InventItem",
                column: "EmployeeDiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_EmployeeDiscounts_EmployeeDiscountId",
                table: "InventItem",
                column: "EmployeeDiscountId",
                principalTable: "EmployeeDiscounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_InventModelGroups_InventModelGroupId",
                table: "InventItem",
                column: "InventModelGroupId",
                principalTable: "InventModelGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_ItemHierarchies_ItemHierarchyId",
                table: "InventItem",
                column: "ItemHierarchyId",
                principalTable: "ItemHierarchies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_Vendors_VendorId",
                table: "InventItem",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItemStoreConfigurations_InventItem_InventItemId",
                table: "InventItemStoreConfigurations",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItemStoreConfigurations_Store_StoreId",
                table: "InventItemStoreConfigurations",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_CommercialEvents_CommercialEventId",
                table: "PurchOrderShipmentHeader",
                column: "CommercialEventId",
                principalTable: "CommercialEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
