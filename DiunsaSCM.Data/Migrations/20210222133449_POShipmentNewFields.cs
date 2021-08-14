using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class POShipmentNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedContainerQty",
                table: "PurchOrderShipmentHeader",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "PurchOrderHeader",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedContainerQty",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "PurchOrderHeader");
        }
    }
}
