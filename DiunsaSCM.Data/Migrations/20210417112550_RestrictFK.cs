using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class RestrictFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barcode_BarcodeBatch_BarcodeBatchId",
                table: "Barcode");

            migrationBuilder.DropForeignKey(
                name: "FK_Barcode_BarcodeSource_BarcodeSourceId",
                table: "Barcode");

            migrationBuilder.DropForeignKey(
                name: "FK_Color_InventItem_InventItemId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_InventDim_InventItem_InventItemId",
                table: "InventDim");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItemStoreConfiguration_InventItem_InventItemId",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItemStoreConfiguration_Store_StoreId",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentRouteStepSuscription");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentRouteStepSuscription_ShippingRouteStep_ShippingRouteStepId",
                table: "PurchOrderShipmentRouteStepSuscription");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalLog_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLine_InventItem_InventItemId",
                table: "PurchQuotationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLine_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPrice_CustomerPriceGroup_CustomerPriceGroupId",
                table: "SalesPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPrice_InventItem_InventItemId",
                table: "SalesPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainer_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "ShipmentContainer");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainer_ShipmentContainerType_ShipmentContainerTypeId",
                table: "ShipmentContainer");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainerDetail_ShipmentContainer_ShipmentContainerId",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLogEntry_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "ShipmentLogEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLogEntry_ShippingRouteStep_ShippingRouteStepId",
                table: "ShipmentLogEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingRouteStep_ShippingRoute_ShippingRouteId",
                table: "ShippingRouteStep");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingRouteStep_ShippingStepType_ShippingStepTypeId",
                table: "ShippingRouteStep");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_InventItem_InventItemId",
                table: "Size");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxOnItem_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "TaxOnItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitConvert_Unit_FromUnitId",
                table: "UnitConvert");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitConvert_InventItem_InventItemId",
                table: "UnitConvert");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitConvert_Unit_ToUnitId",
                table: "UnitConvert");

            migrationBuilder.AddForeignKey(
                name: "FK_Barcode_BarcodeBatch_BarcodeBatchId",
                table: "Barcode",
                column: "BarcodeBatchId",
                principalTable: "BarcodeBatch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Barcode_BarcodeSource_BarcodeSourceId",
                table: "Barcode",
                column: "BarcodeSourceId",
                principalTable: "BarcodeSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Color_InventItem_InventItemId",
                table: "Color",
                column: "InventItemId",
                principalTable: "InventItem",
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
                name: "FK_InventItemStoreConfiguration_InventItem_InventItemId",
                table: "InventItemStoreConfiguration",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventItemStoreConfiguration_Store_StoreId",
                table: "InventItemStoreConfiguration",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderDetail",
                column: "PurchOrderHeaderId",
                principalTable: "PurchOrderHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "PurchOrderShipmentDetail",
                column: "PurchOrderDetailId",
                principalTable: "PurchOrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentDetail",
                column: "PurchOrderShipmentHeaderId",
                principalTable: "PurchOrderShipmentHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderShipmentHeader",
                column: "PurchOrderHeaderId",
                principalTable: "PurchOrderHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentRouteStepSuscription",
                column: "PurchOrderShipmentHeaderId",
                principalTable: "PurchOrderShipmentHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentRouteStepSuscription_ShippingRouteStep_ShippingRouteStepId",
                table: "PurchOrderShipmentRouteStepSuscription",
                column: "ShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalLog_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationApprovalLog",
                column: "PurchQuotationId",
                principalTable: "PurchQuotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition",
                column: "PurchQuotationApprovalId",
                principalTable: "PurchQuotationApproval",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition",
                column: "PurchQuotationApprovalRuleId",
                principalTable: "PurchQuotationApprovalRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm",
                column: "PurchQuotationApprovalRuleConditionId",
                principalTable: "PurchQuotationApprovalRuleCondition",
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
                name: "FK_PurchQuotationLine_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationLine",
                column: "PurchQuotationId",
                principalTable: "PurchQuotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPrice_CustomerPriceGroup_CustomerPriceGroupId",
                table: "SalesPrice",
                column: "CustomerPriceGroupId",
                principalTable: "CustomerPriceGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPrice_InventItem_InventItemId",
                table: "SalesPrice",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine",
                column: "SalesPriceDefinitionId",
                principalTable: "SalesPriceDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainer_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "ShipmentContainer",
                column: "PurchOrderShipmentHeaderId",
                principalTable: "PurchOrderShipmentHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainer_ShipmentContainerType_ShipmentContainerTypeId",
                table: "ShipmentContainer",
                column: "ShipmentContainerTypeId",
                principalTable: "ShipmentContainerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "ShipmentContainerDetail",
                column: "PurchOrderDetailId",
                principalTable: "PurchOrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainerDetail_ShipmentContainer_ShipmentContainerId",
                table: "ShipmentContainerDetail",
                column: "ShipmentContainerId",
                principalTable: "ShipmentContainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLogEntry_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "ShipmentLogEntry",
                column: "PurchOrderShipmentHeaderId",
                principalTable: "PurchOrderShipmentHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLogEntry_ShippingRouteStep_ShippingRouteStepId",
                table: "ShipmentLogEntry",
                column: "ShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingRouteStep_ShippingRoute_ShippingRouteId",
                table: "ShippingRouteStep",
                column: "ShippingRouteId",
                principalTable: "ShippingRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingRouteStep_ShippingStepType_ShippingStepTypeId",
                table: "ShippingRouteStep",
                column: "ShippingStepTypeId",
                principalTable: "ShippingStepType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Size_InventItem_InventItemId",
                table: "Size",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxOnItem_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "TaxOnItem",
                column: "TaxItemGroupHeadingId",
                principalTable: "TaxItemGroupHeading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConvert_Unit_FromUnitId",
                table: "UnitConvert",
                column: "FromUnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConvert_InventItem_InventItemId",
                table: "UnitConvert",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConvert_Unit_ToUnitId",
                table: "UnitConvert",
                column: "ToUnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barcode_BarcodeBatch_BarcodeBatchId",
                table: "Barcode");

            migrationBuilder.DropForeignKey(
                name: "FK_Barcode_BarcodeSource_BarcodeSourceId",
                table: "Barcode");

            migrationBuilder.DropForeignKey(
                name: "FK_Color_InventItem_InventItemId",
                table: "Color");

            migrationBuilder.DropForeignKey(
                name: "FK_InventDim_InventItem_InventItemId",
                table: "InventDim");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItemStoreConfiguration_InventItem_InventItemId",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_InventItemStoreConfiguration_Store_StoreId",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentRouteStepSuscription");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentRouteStepSuscription_ShippingRouteStep_ShippingRouteStepId",
                table: "PurchOrderShipmentRouteStepSuscription");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalLog_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLine_InventItem_InventItemId",
                table: "PurchQuotationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationLine_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPrice_CustomerPriceGroup_CustomerPriceGroupId",
                table: "SalesPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPrice_InventItem_InventItemId",
                table: "SalesPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainer_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "ShipmentContainer");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainer_ShipmentContainerType_ShipmentContainerTypeId",
                table: "ShipmentContainer");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentContainerDetail_ShipmentContainer_ShipmentContainerId",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLogEntry_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "ShipmentLogEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLogEntry_ShippingRouteStep_ShippingRouteStepId",
                table: "ShipmentLogEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingRouteStep_ShippingRoute_ShippingRouteId",
                table: "ShippingRouteStep");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingRouteStep_ShippingStepType_ShippingStepTypeId",
                table: "ShippingRouteStep");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_InventItem_InventItemId",
                table: "Size");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxOnItem_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "TaxOnItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitConvert_Unit_FromUnitId",
                table: "UnitConvert");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitConvert_InventItem_InventItemId",
                table: "UnitConvert");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitConvert_Unit_ToUnitId",
                table: "UnitConvert");

            migrationBuilder.AddForeignKey(
                name: "FK_Barcode_BarcodeBatch_BarcodeBatchId",
                table: "Barcode",
                column: "BarcodeBatchId",
                principalTable: "BarcodeBatch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Barcode_BarcodeSource_BarcodeSourceId",
                table: "Barcode",
                column: "BarcodeSourceId",
                principalTable: "BarcodeSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Color_InventItem_InventItemId",
                table: "Color",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventDim_InventItem_InventItemId",
                table: "InventDim",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderDetail",
                column: "PurchOrderHeaderId",
                principalTable: "PurchOrderHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "PurchOrderShipmentDetail",
                column: "PurchOrderDetailId",
                principalTable: "PurchOrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentDetail_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentDetail",
                column: "PurchOrderShipmentHeaderId",
                principalTable: "PurchOrderShipmentHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchOrderShipmentHeader",
                column: "PurchOrderHeaderId",
                principalTable: "PurchOrderHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentRouteStepSuscription",
                column: "PurchOrderShipmentHeaderId",
                principalTable: "PurchOrderShipmentHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentRouteStepSuscription_ShippingRouteStep_ShippingRouteStepId",
                table: "PurchOrderShipmentRouteStepSuscription",
                column: "ShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalLog_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationApprovalLog",
                column: "PurchQuotationId",
                principalTable: "PurchQuotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition",
                column: "PurchQuotationApprovalId",
                principalTable: "PurchQuotationApproval",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition",
                column: "PurchQuotationApprovalRuleId",
                principalTable: "PurchQuotationApprovalRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm",
                column: "PurchQuotationApprovalRuleConditionId",
                principalTable: "PurchQuotationApprovalRuleCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLine_InventItem_InventItemId",
                table: "PurchQuotationLine",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationLine_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationLine",
                column: "PurchQuotationId",
                principalTable: "PurchQuotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPrice_CustomerPriceGroup_CustomerPriceGroupId",
                table: "SalesPrice",
                column: "CustomerPriceGroupId",
                principalTable: "CustomerPriceGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPrice_InventItem_InventItemId",
                table: "SalesPrice",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine",
                column: "SalesPriceDefinitionId",
                principalTable: "SalesPriceDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainer_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "ShipmentContainer",
                column: "PurchOrderShipmentHeaderId",
                principalTable: "PurchOrderShipmentHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainer_ShipmentContainerType_ShipmentContainerTypeId",
                table: "ShipmentContainer",
                column: "ShipmentContainerTypeId",
                principalTable: "ShipmentContainerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId",
                table: "ShipmentContainerDetail",
                column: "PurchOrderDetailId",
                principalTable: "PurchOrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentContainerDetail_ShipmentContainer_ShipmentContainerId",
                table: "ShipmentContainerDetail",
                column: "ShipmentContainerId",
                principalTable: "ShipmentContainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLogEntry_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                table: "ShipmentLogEntry",
                column: "PurchOrderShipmentHeaderId",
                principalTable: "PurchOrderShipmentHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLogEntry_ShippingRouteStep_ShippingRouteStepId",
                table: "ShipmentLogEntry",
                column: "ShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingRouteStep_ShippingRoute_ShippingRouteId",
                table: "ShippingRouteStep",
                column: "ShippingRouteId",
                principalTable: "ShippingRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingRouteStep_ShippingStepType_ShippingStepTypeId",
                table: "ShippingRouteStep",
                column: "ShippingStepTypeId",
                principalTable: "ShippingStepType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Size_InventItem_InventItemId",
                table: "Size",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxOnItem_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "TaxOnItem",
                column: "TaxItemGroupHeadingId",
                principalTable: "TaxItemGroupHeading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConvert_Unit_FromUnitId",
                table: "UnitConvert",
                column: "FromUnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConvert_InventItem_InventItemId",
                table: "UnitConvert",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConvert_Unit_ToUnitId",
                table: "UnitConvert",
                column: "ToUnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
