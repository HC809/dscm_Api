using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class NewFieldsForAuditableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Vendor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Vendor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserSettings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserSettings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UserSettings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserSettings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UnitConvert",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UnitConvert",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UnitConvert",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "UnitConvert",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Unit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Unit",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Unit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Unit",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaxOnItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TaxOnItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TaxOnItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TaxOnItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaxItemGroupHeading",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TaxItemGroupHeading",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TaxItemGroupHeading",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TaxItemGroupHeading",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Store",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Store",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Store",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Store",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Size",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Size",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Size",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Size",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShippingStepType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingStepType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShippingRouteStep",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingRouteStep",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShippingRouteStatusPresentationSchema",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShippingRouteStatusPresentationSchema",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShippingRouteStatusPresentationSchema",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingRouteStatusPresentationSchema",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShippingRoute",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingRoute",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShippingCompany",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShippingCompany",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShippingCompany",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingCompany",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShipmentTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShipmentTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShipmentTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShipmentTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShipmentLogEntry",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShipmentLogEntry",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShipmentLogEntry",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShipmentLogEntry",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShipmentImport",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShipmentImport",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShipmentImport",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShipmentImport",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShipmentContainerType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShipmentContainerType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShipmentContainerType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShipmentContainerType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShipmentContainerDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShipmentContainerDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShipmentContainerDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShipmentContainerDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShipmentContainer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShipmentContainer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ShipmentContainer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShipmentContainer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchQuotationLine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchQuotationLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchQuotationLine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchQuotationApprovalRuleCondition",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchQuotationApprovalRuleCondition",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchQuotationApprovalRuleCondition",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchQuotationApprovalRuleCondition",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchQuotationApprovalRule",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchQuotationApprovalRule",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchQuotationApprovalRule",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchQuotationApprovalRule",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchQuotationApprovalLog",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchQuotationApprovalLog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchQuotationApprovalLog",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchQuotationApprovalLog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchQuotationApproval",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchQuotationApproval",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchQuotationApproval",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchQuotationApproval",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchQuotation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchQuotation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchOrderShipmentRouteStepSuscription",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchOrderShipmentRouteStepSuscription",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchOrderShipmentRouteStepSuscription",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchOrderShipmentRouteStepSuscription",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchOrderShipmentHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchOrderShipmentHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchOrderShipmentDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchOrderShipmentDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchOrderShipmentDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchOrderShipmentDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchOrderHeader",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchOrderHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchOrderHeader",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchOrderHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchOrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchOrderDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchOrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchOrderDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Port",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Port",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ItemHierarchy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ItemHierarchy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ItemHierarchy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ItemHierarchy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InventModelGroup",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "InventModelGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "InventModelGroup",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "InventModelGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InventItemStoreConfiguration",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "InventItemStoreConfiguration",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "InventItemStoreConfiguration",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "InventItemStoreConfiguration",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InventItemGroup",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "InventItemGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "InventItemGroup",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "InventItemGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "InventItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "InventItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "InventItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InventDimGroup",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "InventDimGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "InventDimGroup",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "InventDimGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InventDim",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "InventDim",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "InventDim",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "InventDim",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Incoterm",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Incoterm",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Incoterm",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Incoterm",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CommercialEvent",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CommercialEvent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CommercialEvent",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CommercialEvent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Color",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Color",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Color",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Color",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaxOnItem");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TaxOnItem");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TaxOnItem");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TaxOnItem");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaxItemGroupHeading");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TaxItemGroupHeading");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TaxItemGroupHeading");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TaxItemGroupHeading");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShippingStepType");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShippingStepType");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShippingRouteStatusPresentationSchema");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShippingRouteStatusPresentationSchema");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShippingRouteStatusPresentationSchema");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShippingRouteStatusPresentationSchema");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShippingCompany");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShippingCompany");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShippingCompany");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShippingCompany");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShipmentTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShipmentTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShipmentTypes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShipmentTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShipmentLogEntry");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShipmentLogEntry");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShipmentLogEntry");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShipmentLogEntry");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShipmentImport");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShipmentImport");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShipmentImport");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShipmentImport");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShipmentContainerType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShipmentContainerType");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShipmentContainerType");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShipmentContainerType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShipmentContainerDetail");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShipmentContainer");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShipmentContainer");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ShipmentContainer");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ShipmentContainer");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchQuotationApprovalRule");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchQuotationApprovalRule");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchQuotationApprovalRule");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchQuotationApprovalRule");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchQuotationApproval");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchQuotationApproval");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchQuotationApproval");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchQuotationApproval");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchOrderShipmentRouteStepSuscription");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchOrderShipmentRouteStepSuscription");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchOrderShipmentRouteStepSuscription");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchOrderShipmentRouteStepSuscription");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchOrderShipmentDetail");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchOrderDetail");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchOrderDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchOrderDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchOrderDetail");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ItemHierarchy");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ItemHierarchy");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ItemHierarchy");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ItemHierarchy");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InventModelGroup");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InventModelGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "InventModelGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "InventModelGroup");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "InventItemStoreConfiguration");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InventItemGroup");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InventItemGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "InventItemGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "InventItemGroup");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "InventDimGroup");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InventDim");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InventDim");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "InventDim");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "InventDim");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Incoterm");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Incoterm");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Incoterm");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Incoterm");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CommercialEvent");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CommercialEvent");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CommercialEvent");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CommercialEvent");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Color");
        }
    }
}
