using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class ItemProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "InventItem");

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "UnitConvert",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "Unit",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "Size",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "InventItemId",
                table: "Size",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "ItemBarcode",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "InventItemGroup",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "AllowDiscount",
                table: "InventItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "InventItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EmployeeDiscountId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossDepth",
                table: "InventItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossHeight",
                table: "InventItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossWidth",
                table: "InventItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "InventItemGroupId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InventModelGroupId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "InventItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ItemHierarchyId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemType",
                table: "InventItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "VendorId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ColorRequired",
                table: "InventDimGroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ConfigurationRequired",
                table: "InventDimGroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "InventDimGroup",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "SerialNumberRequired",
                table: "InventDimGroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SizeRequired",
                table: "InventDimGroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StyleRequired",
                table: "InventDimGroup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "InventDim",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "InventDim",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "InventItemId",
                table: "InventDim",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SizeId",
                table: "InventDim",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "Color",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "InventItemId",
                table: "Color",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "Brand",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "EmployeeDiscounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DiscountPercentage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventItemStoreConfigurations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ERPRecId = table.Column<long>(nullable: false),
                    AllowToSell = table.Column<bool>(nullable: false),
                    InventItemId = table.Column<long>(nullable: false),
                    StoreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventItemStoreConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventItemStoreConfigurations_InventItem_InventItemId",
                        column: x => x.InventItemId,
                        principalTable: "InventItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventItemStoreConfigurations_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventModelGroups",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ERPRecId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventModelGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemHierarchies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemHierarchies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ERPRecId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Size_InventItemId",
                table: "Size",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_BrandId",
                table: "InventItem",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_EmployeeDiscountId",
                table: "InventItem",
                column: "EmployeeDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_InventItemGroupId",
                table: "InventItem",
                column: "InventItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_InventModelGroupId",
                table: "InventItem",
                column: "InventModelGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_ItemHierarchyId",
                table: "InventItem",
                column: "ItemHierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_VendorId",
                table: "InventItem",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_InventDim_ColorId",
                table: "InventDim",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_InventDim_InventItemId",
                table: "InventDim",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventDim_SizeId",
                table: "InventDim",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_InventItemId",
                table: "Color",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemStoreConfigurations_InventItemId",
                table: "InventItemStoreConfigurations",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemStoreConfigurations_StoreId",
                table: "InventItemStoreConfigurations",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_InventItem_InventItemId",
                table: "Color",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventDim_Color_ColorId",
                table: "InventDim",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventDim_InventItem_InventItemId",
                table: "InventDim",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventDim_Size_SizeId",
                table: "InventDim",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_Brand_BrandId",
                table: "InventItem",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_EmployeeDiscounts_EmployeeDiscountId",
                table: "InventItem",
                column: "EmployeeDiscountId",
                principalTable: "EmployeeDiscounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_InventItemGroup_InventItemGroupId",
                table: "InventItem",
                column: "InventItemGroupId",
                principalTable: "InventItemGroup",
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
                name: "FK_Size_InventItem_InventItemId",
                table: "Size",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_InventItem_InventItemId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_InventDim_Color_ColorId",
                table: "InventDim");

            migrationBuilder.DropForeignKey(
                name: "FK_InventDim_InventItem_InventItemId",
                table: "InventDim");

            migrationBuilder.DropForeignKey(
                name: "FK_InventDim_Size_SizeId",
                table: "InventDim");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_Brand_BrandId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_EmployeeDiscounts_EmployeeDiscountId",
                table: "InventItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_InventItemGroup_InventItemGroupId",
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
                name: "FK_Size_InventItem_InventItemId",
                table: "Size");

            migrationBuilder.DropTable(
                name: "EmployeeDiscounts");

            migrationBuilder.DropTable(
                name: "InventItemStoreConfigurations");

            migrationBuilder.DropTable(
                name: "InventModelGroups");

            migrationBuilder.DropTable(
                name: "ItemHierarchies");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Size_InventItemId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_BrandId",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_EmployeeDiscountId",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_InventItemGroupId",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_InventModelGroupId",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_ItemHierarchyId",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_VendorId",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventDim_ColorId",
                table: "InventDim");

            migrationBuilder.DropIndex(
                name: "IX_InventDim_InventItemId",
                table: "InventDim");

            migrationBuilder.DropIndex(
                name: "IX_InventDim_SizeId",
                table: "InventDim");

            migrationBuilder.DropIndex(
                name: "IX_Color_InventItemId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "InventItemId",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "InventItemGroup");

            migrationBuilder.DropColumn(
                name: "AllowDiscount",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "EmployeeDiscountId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "GrossDepth",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "GrossHeight",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "GrossWidth",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "InventItemGroupId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "InventModelGroupId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "ItemHierarchyId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "ColorRequired",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "ConfigurationRequired",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "SerialNumberRequired",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "SizeRequired",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "StyleRequired",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "InventDim");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "InventDim");

            migrationBuilder.DropColumn(
                name: "InventItemId",
                table: "InventDim");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "InventDim");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "InventItemId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "Brand");

            migrationBuilder.AddColumn<string>(
                name: "ItemId",
                table: "InventItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "InventItem",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
