using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class EstimatedCostinInventItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "ColorDescription",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "InventItemCode",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "InventItemDescription",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "ItemBarcodeCode",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "ItemBarcodeDescription",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "SizeCode",
                table: "PurchQuotationLine");

            migrationBuilder.DropColumn(
                name: "SizeDescription",
                table: "PurchQuotationLine");

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedCost",
                table: "SalesPriceDefinitionLine",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedCost",
                table: "InventItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedCostDate",
                table: "InventItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedCost",
                table: "SalesPriceDefinitionLine");

            migrationBuilder.DropColumn(
                name: "EstimatedCost",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "EstimatedCostDate",
                table: "InventItem");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorDescription",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventItemCode",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventItemDescription",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemBarcodeCode",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemBarcodeDescription",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeCode",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeDescription",
                table: "PurchQuotationLine",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
