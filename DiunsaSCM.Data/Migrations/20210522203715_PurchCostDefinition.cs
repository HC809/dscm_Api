using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PurchCostDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "PurchCostDefinitions",
                startValue: 1000000L);

            migrationBuilder.CreateSequence(
                name: "SalesPriceDefinitions",
                startValue: 1000000L);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SalesPriceDefinition",
                nullable: true,
                defaultValueSql: "'DP' + Format(NEXT VALUE FOR dbo.SalesPriceDefinitions,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ERPVariantCode",
                table: "ItemBarcode",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchCostDefinition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true, defaultValueSql: "'DC' + Format(NEXT VALUE FOR dbo.PurchCostDefinitions,'D8')"),
                    Description = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    VendorCode = table.Column<string>(nullable: true),
                    VendorDescription = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    AgentCode = table.Column<string>(nullable: true),
                    ImportPolicyCode = table.Column<string>(nullable: true),
                    ShipmentImportCode = table.Column<string>(nullable: true),
                    ShippingCompanyCode = table.Column<string>(nullable: true),
                    ExchangeRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchCostDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchCostDefinitionLine",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineNumber = table.Column<int>(nullable: false),
                    QtyOrdered = table.Column<decimal>(nullable: false),
                    UnitCode = table.Column<string>(nullable: true),
                    LineDescription = table.Column<string>(nullable: true),
                    CustomsTariffCode = table.Column<string>(nullable: true),
                    CustomsTariffPosition = table.Column<string>(nullable: true),
                    CBM = table.Column<string>(nullable: true),
                    EmptyField = table.Column<string>(nullable: true),
                    ItemNumber = table.Column<string>(nullable: true),
                    ItemBarcode = table.Column<string>(nullable: true),
                    InventItemCode = table.Column<string>(nullable: true),
                    PurchPrice = table.Column<decimal>(nullable: false),
                    PurchLineAmount = table.Column<decimal>(nullable: false),
                    CIFMarkupAmount = table.Column<decimal>(nullable: false),
                    CostWithCIF = table.Column<decimal>(nullable: false),
                    CostWithCIFLocalCurrency = table.Column<decimal>(nullable: false),
                    CustomsFee = table.Column<decimal>(nullable: false),
                    CustomsSelectiveFeeAmount = table.Column<decimal>(nullable: false),
                    LocalExpensesMarkupAmount = table.Column<decimal>(nullable: false),
                    CostWithLocalExpensesLocalCurrency = table.Column<decimal>(nullable: false),
                    CostWithLocalExpenses = table.Column<decimal>(nullable: false),
                    SuggestedSalesPriceStore = table.Column<decimal>(nullable: false),
                    SuggestedSalesPriceWholesaleCredit = table.Column<decimal>(nullable: false),
                    SuggestedSalesPriceWholesaleCash = table.Column<decimal>(nullable: false),
                    PurchCostDefinitionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchCostDefinitionLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchCostDefinitionLine_PurchCostDefinition_PurchCostDefinitionId",
                        column: x => x.PurchCostDefinitionId,
                        principalTable: "PurchCostDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchCostDefinition_Code",
                table: "PurchCostDefinition",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchCostDefinitionLine_PurchCostDefinitionId",
                table: "PurchCostDefinitionLine",
                column: "PurchCostDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchCostDefinitionLine");

            migrationBuilder.DropTable(
                name: "PurchCostDefinition");

            migrationBuilder.DropSequence(
                name: "PurchCostDefinitions");

            migrationBuilder.DropSequence(
                name: "SalesPriceDefinitions");

            migrationBuilder.DropColumn(
                name: "ERPVariantCode",
                table: "ItemBarcode");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "SalesPriceDefinition",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "'DP' + Format(NEXT VALUE FOR dbo.SalesPriceDefinitions,'D8')");
        }
    }
}
