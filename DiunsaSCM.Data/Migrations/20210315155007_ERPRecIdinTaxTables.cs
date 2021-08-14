using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class ERPRecIdinTaxTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InventItemId",
                table: "UnitConvert",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "TaxOnItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ERPRecId",
                table: "TaxItemGroupHeading",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UnitConvert_InventItemId",
                table: "UnitConvert",
                column: "InventItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConvert_InventItem_InventItemId",
                table: "UnitConvert",
                column: "InventItemId",
                principalTable: "InventItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitConvert_InventItem_InventItemId",
                table: "UnitConvert");

            migrationBuilder.DropIndex(
                name: "IX_UnitConvert_InventItemId",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "InventItemId",
                table: "UnitConvert");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "TaxOnItem");

            migrationBuilder.DropColumn(
                name: "ERPRecId",
                table: "TaxItemGroupHeading");
        }
    }
}
