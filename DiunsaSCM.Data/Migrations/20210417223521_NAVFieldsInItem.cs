using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class NAVFieldsInItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BlckedForSale",
                table: "InventItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "InventItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WebSiteDescription",
                table: "InventItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "WebSiteStatus",
                table: "InventItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlckedForSale",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "WebSiteDescription",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "WebSiteStatus",
                table: "InventItem");
        }
    }
}
