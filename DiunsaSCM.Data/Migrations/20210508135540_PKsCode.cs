using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PKsCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UnitConvert_InventItemId",
                table: "UnitConvert");

            migrationBuilder.DropIndex(
                name: "IX_Size_InventItemId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentContainer_PurchOrderShipmentHeaderId",
                table: "ShipmentContainer");

            migrationBuilder.DropIndex(
                name: "IX_InventItemStoreConfiguration_InventItemId",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_Code",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventDim_InventItemId",
                table: "InventDim");

            migrationBuilder.DropIndex(
                name: "IX_Color_InventItemId",
                table: "Color");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Warehouse",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Vendor",
                nullable: true,
                defaultValueSql: "'P' + Format(NEXT VALUE FOR dbo.Vendors,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "'P' + Format(NEXT VALUE FOR dbo.Vendors,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserSettings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Unit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TaxOnItem",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TaxItemGroupHeading",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Store",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Size",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ShippingStepType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShippingRouteStatusPresentationSchema",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ShippingRoute",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShippingCompany",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShipmentTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BLNumber",
                table: "ShipmentImport",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShipmentContainerType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContainerNumber",
                table: "ShipmentContainer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SalesPriceDefinition",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotationApprovalRuleCondition",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotationApprovalRule",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotationApproval",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotation",
                nullable: true,
                defaultValueSql: "'RQ' + Format(NEXT VALUE FOR dbo.PurchQuotations,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "'RQ' + Format(NEXT VALUE FOR dbo.PurchQuotations,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchPaymentCondition",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchOrderShipmentHeader",
                nullable: true,
                defaultValueSql: "'EC' + Format(NEXT VALUE FOR dbo.PurchOrderShipments,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "'EC' + Format(NEXT VALUE FOR dbo.PurchOrderShipments,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchOrderHeader",
                nullable: true,
                defaultValueSql: "'OC' + Format(NEXT VALUE FOR dbo.PurchOrders,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "'OC' + Format(NEXT VALUE FOR dbo.PurchOrders,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Port",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ItemSeasonalCategory",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ItemHierarchy",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "ItemBarcode",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventModelGroup",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventItemGroup",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventDimGroup",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Incoterm",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "EmployeeDiscount",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CustomerPriceGroup",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Currency",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Country",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CommercialEvent",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Color",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Brand",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Barcode",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_Code",
                table: "Warehouse",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_Code",
                table: "Vendor",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_Username",
                table: "UserSettings",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConvert_InventItemId_FromUnitId_ToUnitId",
                table: "UnitConvert",
                columns: new[] { "InventItemId", "FromUnitId", "ToUnitId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_Code",
                table: "Unit",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaxOnItem_Code",
                table: "TaxOnItem",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaxItemGroupHeading_Code",
                table: "TaxItemGroupHeading",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Code",
                table: "Store",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Size_InventItemId_Code",
                table: "Size",
                columns: new[] { "InventItemId", "Code" },
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingStepType_Code",
                table: "ShippingStepType",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRouteStatusPresentationSchema_Description",
                table: "ShippingRouteStatusPresentationSchema",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRoute_Code",
                table: "ShippingRoute",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingCompany_Name",
                table: "ShippingCompany",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentTypes_Description",
                table: "ShipmentTypes",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentImport_BLNumber",
                table: "ShipmentImport",
                column: "BLNumber",
                unique: true,
                filter: "[BLNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentContainerType_Description",
                table: "ShipmentContainerType",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentContainer_PurchOrderShipmentHeaderId_ContainerNumber",
                table: "ShipmentContainer",
                columns: new[] { "PurchOrderShipmentHeaderId", "ContainerNumber" },
                unique: true,
                filter: "[ContainerNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPriceDefinition_Code",
                table: "SalesPriceDefinition",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRuleCondition_Code",
                table: "PurchQuotationApprovalRuleCondition",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRule_Code",
                table: "PurchQuotationApprovalRule",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApproval_Code",
                table: "PurchQuotationApproval",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotation_Code",
                table: "PurchQuotation",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchPaymentCondition_Code",
                table: "PurchPaymentCondition",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_Code",
                table: "PurchOrderShipmentHeader",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderHeader_Code",
                table: "PurchOrderHeader",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Port_Code",
                table: "Port",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSeasonalCategory_Code",
                table: "ItemSeasonalCategory",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHierarchy_Code",
                table: "ItemHierarchy",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBarcode_Barcode",
                table: "ItemBarcode",
                column: "Barcode",
                unique: true,
                filter: "[Barcode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventModelGroup_Code",
                table: "InventModelGroup",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemStoreConfiguration_InventItemId_StoreId",
                table: "InventItemStoreConfiguration",
                columns: new[] { "InventItemId", "StoreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventItemGroup_Code",
                table: "InventItemGroup",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_Code",
                table: "InventItem",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventDimGroup_Code",
                table: "InventDimGroup",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventDim_InventItemId_ColorId_SizeId",
                table: "InventDim",
                columns: new[] { "InventItemId", "ColorId", "SizeId" },
                unique: true,
                filter: "[ColorId] IS NOT NULL AND [SizeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Incoterm_Code",
                table: "Incoterm",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDiscount_Code",
                table: "EmployeeDiscount",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPriceGroup_Code",
                table: "CustomerPriceGroup",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_Code",
                table: "Currency",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Code",
                table: "Country",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialEvent_Description",
                table: "CommercialEvent",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Color_InventItemId_Code",
                table: "Color",
                columns: new[] { "InventItemId", "Code" },
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Code",
                table: "Brand",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Barcode_Code",
                table: "Barcode",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Warehouse_Code",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_Code",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_UserSettings_Username",
                table: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_UnitConvert_InventItemId_FromUnitId_ToUnitId",
                table: "UnitConvert");

            migrationBuilder.DropIndex(
                name: "IX_Unit_Code",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_TaxOnItem_Code",
                table: "TaxOnItem");

            migrationBuilder.DropIndex(
                name: "IX_TaxItemGroupHeading_Code",
                table: "TaxItemGroupHeading");

            migrationBuilder.DropIndex(
                name: "IX_Store_Code",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Size_InventItemId_Code",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_ShippingStepType_Code",
                table: "ShippingStepType");

            migrationBuilder.DropIndex(
                name: "IX_ShippingRouteStatusPresentationSchema_Description",
                table: "ShippingRouteStatusPresentationSchema");

            migrationBuilder.DropIndex(
                name: "IX_ShippingRoute_Code",
                table: "ShippingRoute");

            migrationBuilder.DropIndex(
                name: "IX_ShippingCompany_Name",
                table: "ShippingCompany");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentTypes_Description",
                table: "ShipmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentImport_BLNumber",
                table: "ShipmentImport");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentContainerType_Description",
                table: "ShipmentContainerType");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentContainer_PurchOrderShipmentHeaderId_ContainerNumber",
                table: "ShipmentContainer");

            migrationBuilder.DropIndex(
                name: "IX_SalesPriceDefinition_Code",
                table: "SalesPriceDefinition");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationApprovalRuleCondition_Code",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationApprovalRule_Code",
                table: "PurchQuotationApprovalRule");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationApproval_Code",
                table: "PurchQuotationApproval");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotation_Code",
                table: "PurchQuotation");

            migrationBuilder.DropIndex(
                name: "IX_PurchPaymentCondition_Code",
                table: "PurchPaymentCondition");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_Code",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderHeader_Code",
                table: "PurchOrderHeader");

            migrationBuilder.DropIndex(
                name: "IX_Port_Code",
                table: "Port");

            migrationBuilder.DropIndex(
                name: "IX_ItemSeasonalCategory_Code",
                table: "ItemSeasonalCategory");

            migrationBuilder.DropIndex(
                name: "IX_ItemHierarchy_Code",
                table: "ItemHierarchy");

            migrationBuilder.DropIndex(
                name: "IX_ItemBarcode_Barcode",
                table: "ItemBarcode");

            migrationBuilder.DropIndex(
                name: "IX_InventModelGroup_Code",
                table: "InventModelGroup");

            migrationBuilder.DropIndex(
                name: "IX_InventItemStoreConfiguration_InventItemId_StoreId",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_InventItemGroup_Code",
                table: "InventItemGroup");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_Code",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventDimGroup_Code",
                table: "InventDimGroup");

            migrationBuilder.DropIndex(
                name: "IX_InventDim_InventItemId_ColorId_SizeId",
                table: "InventDim");

            migrationBuilder.DropIndex(
                name: "IX_Incoterm_Code",
                table: "Incoterm");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDiscount_Code",
                table: "EmployeeDiscount");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPriceGroup_Code",
                table: "CustomerPriceGroup");

            migrationBuilder.DropIndex(
                name: "IX_Currency_Code",
                table: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Country_Code",
                table: "Country");

            migrationBuilder.DropIndex(
                name: "IX_CommercialEvent_Description",
                table: "CommercialEvent");

            migrationBuilder.DropIndex(
                name: "IX_Color_InventItemId_Code",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Brand_Code",
                table: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Barcode_Code",
                table: "Barcode");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "'P' + Format(NEXT VALUE FOR dbo.Vendors,'D8')",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "'P' + Format(NEXT VALUE FOR dbo.Vendors,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Unit",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TaxOnItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "TaxItemGroupHeading",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Store",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Size",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ShippingStepType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShippingRouteStatusPresentationSchema",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ShippingRoute",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShippingCompany",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShipmentTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BLNumber",
                table: "ShipmentImport",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShipmentContainerType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContainerNumber",
                table: "ShipmentContainer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SalesPriceDefinition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotationApprovalRuleCondition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotationApprovalRule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotationApproval",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotation",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "'RQ' + Format(NEXT VALUE FOR dbo.PurchQuotations,'D8')",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "'RQ' + Format(NEXT VALUE FOR dbo.PurchQuotations,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchPaymentCondition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchOrderShipmentHeader",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "'EC' + Format(NEXT VALUE FOR dbo.PurchOrderShipments,'D8')",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "'EC' + Format(NEXT VALUE FOR dbo.PurchOrderShipments,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchOrderHeader",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "'OC' + Format(NEXT VALUE FOR dbo.PurchOrders,'D8')",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "'OC' + Format(NEXT VALUE FOR dbo.PurchOrders,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Port",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ItemSeasonalCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ItemHierarchy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "ItemBarcode",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventModelGroup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventItemGroup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventDimGroup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Incoterm",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "EmployeeDiscount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CustomerPriceGroup",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CommercialEvent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Color",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Barcode",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitConvert_InventItemId",
                table: "UnitConvert",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_InventItemId",
                table: "Size",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentContainer_PurchOrderShipmentHeaderId",
                table: "ShipmentContainer",
                column: "PurchOrderShipmentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemStoreConfiguration_InventItemId",
                table: "InventItemStoreConfiguration",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_Code",
                table: "InventItem",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_InventDim_InventItemId",
                table: "InventDim",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_InventItemId",
                table: "Color",
                column: "InventItemId");
        }
    }
}
