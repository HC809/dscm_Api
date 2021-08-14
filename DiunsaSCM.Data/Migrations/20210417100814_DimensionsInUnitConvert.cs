using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class DimensionsInUnitConvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine");

            migrationBuilder.AddColumn<decimal>(
                name: "GrossDepth",
                table: "UnitConvert",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossHeight",
                table: "UnitConvert",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossWeight",
                table: "UnitConvert",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossWidth",
                table: "UnitConvert",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<long>(
                name: "SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossWeight",
                table: "InventItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine",
                column: "SalesPriceDefinitionId",
                principalTable: "SalesPriceDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine");

            migrationBuilder.DropColumn(
                name: "GrossDepth",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "GrossHeight",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "GrossWeight",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "GrossWidth",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "GrossWeight",
                table: "InventItem");

            migrationBuilder.AlterColumn<long>(
                name: "SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine",
                column: "SalesPriceDefinitionId",
                principalTable: "SalesPriceDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
