using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PurchCodeInPurchCostDefLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchOrderCode",
                table: "PurchCostDefinitionLine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchOrderCode",
                table: "PurchCostDefinitionLine");
        }
    }
}
