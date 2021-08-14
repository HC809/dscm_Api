using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class RemoveOldInPurchOrderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PurchOrderDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PurchOrderHeader",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PurchOrderDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
