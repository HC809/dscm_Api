using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class InventItem_Sequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "InventItems",
                startValue: 1000000L);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchOrderShipmentHeader",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "replicate('0' , 8-len(convert(varchar(8), [id] ))) + convert(varchar(8), [id] )");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventItem",
                nullable: true,
                defaultValueSql: "Format(NEXT VALUE FOR dbo.InventItems,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "InventItems");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "Format(NEXT VALUE FOR dbo.InventItems,'D8')");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "PurchOrderShipmentHeader",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "replicate('0' , 8-len(convert(varchar(8), [id] ))) + convert(varchar(8), [id] )",
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
