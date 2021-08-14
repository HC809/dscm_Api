using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PurchOrderShipmentHeaderCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BLNumber",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PurchOrderShipmentHeader",
                nullable: true,
                computedColumnSql: "replicate('0' , 8-len(convert(varchar(8), [id] ))) + convert(varchar(8), [id] )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.AddColumn<string>(
                name: "BLNumber",
                table: "PurchOrderShipmentHeader",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
