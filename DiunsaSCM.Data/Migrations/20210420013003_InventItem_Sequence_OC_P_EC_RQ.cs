using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class InventItem_Sequence_OC_P_EC_RQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchId",
                table: "PurchOrderHeader");

            migrationBuilder.CreateSequence(
                name: "PurchOrders",
                startValue: 1000000L);

            migrationBuilder.CreateSequence(
                name: "PurchOrderShipments",
                startValue: 1000000L);

            migrationBuilder.CreateSequence(
                name: "PurchQuotations");

            migrationBuilder.CreateSequence(
                name: "Vendors",
                startValue: 1000000L);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Vendor",
                nullable: true,
                defaultValueSql: "'P' + Format(NEXT VALUE FOR dbo.Vendors,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotation",
                nullable: true,
                defaultValueSql: "'RQ' + Format(NEXT VALUE FOR dbo.PurchQuotations,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchOrderShipmentHeader",
                nullable: true,
                defaultValueSql: "'EC' + Format(NEXT VALUE FOR dbo.PurchOrderShipments,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PurchOrderHeader",
                nullable: true,
                defaultValueSql: "'OC' + Format(NEXT VALUE FOR dbo.PurchOrders,'D8')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "PurchOrders");

            migrationBuilder.DropSequence(
                name: "PurchOrderShipments");

            migrationBuilder.DropSequence(
                name: "PurchQuotations");

            migrationBuilder.DropSequence(
                name: "Vendors");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PurchOrderHeader");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Vendor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "'P' + Format(NEXT VALUE FOR dbo.Vendors,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchQuotation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "'RQ' + Format(NEXT VALUE FOR dbo.PurchQuotations,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchOrderShipmentHeader",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "'EC' + Format(NEXT VALUE FOR dbo.PurchOrderShipments,'D8')");

            migrationBuilder.AddColumn<string>(
                name: "PurchId",
                table: "PurchOrderHeader",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
