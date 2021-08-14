using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class TaxItemGroupHeadingIdinTaxOnItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TaxItemGroupHeadingId",
                table: "TaxOnItem",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TaxOnItem_TaxItemGroupHeadingId",
                table: "TaxOnItem",
                column: "TaxItemGroupHeadingId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxOnItem_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "TaxOnItem",
                column: "TaxItemGroupHeadingId",
                principalTable: "TaxItemGroupHeading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxOnItem_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "TaxOnItem");

            migrationBuilder.DropIndex(
                name: "IX_TaxOnItem_TaxItemGroupHeadingId",
                table: "TaxOnItem");

            migrationBuilder.DropColumn(
                name: "TaxItemGroupHeadingId",
                table: "TaxOnItem");
        }
    }
}
