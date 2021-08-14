using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class SetAuditFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Warehouse",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Warehouse",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Warehouse",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SalesPriceDefinitionLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SalesPriceDefinitionLine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SalesPriceDefinitionLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SalesPriceDefinitionLine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchPaymentCondition",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchPaymentCondition",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchPaymentCondition",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchPaymentCondition",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchCostDefinitionLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchCostDefinitionLine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchCostDefinitionLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchCostDefinitionLine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchCostDefinition",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchCostDefinition",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PurchCostDefinition",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PurchCostDefinition",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ItemSeasonalCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ItemSeasonalCategory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ItemSeasonalCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ItemSeasonalCategory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ItemBarcode",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ItemBarcode",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ItemBarcode",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ItemBarcode",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CustomerPriceGroup",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomerPriceGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CustomerPriceGroup",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CustomerPriceGroup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Currency",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Currency",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Currency",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BarcodeSource",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BarcodeSource",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BarcodeSource",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BarcodeSource",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BarcodeBatch",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BarcodeBatch",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BarcodeBatch",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BarcodeBatch",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Barcode",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Barcode",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Barcode",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Barcode",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SalesPriceDefinitionLine");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SalesPriceDefinitionLine");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SalesPriceDefinitionLine");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SalesPriceDefinitionLine");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchPaymentCondition");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchPaymentCondition");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchPaymentCondition");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchPaymentCondition");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchCostDefinitionLine");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchCostDefinitionLine");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchCostDefinitionLine");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchCostDefinitionLine");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchCostDefinition");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchCostDefinition");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PurchCostDefinition");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PurchCostDefinition");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ItemSeasonalCategory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ItemSeasonalCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ItemSeasonalCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ItemSeasonalCategory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ItemBarcode");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CustomerPriceGroup");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CustomerPriceGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CustomerPriceGroup");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CustomerPriceGroup");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BarcodeSource");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BarcodeSource");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BarcodeSource");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BarcodeSource");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BarcodeBatch");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BarcodeBatch");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BarcodeBatch");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BarcodeBatch");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Barcode");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Barcode");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Barcode");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Barcode");
        }
    }
}
