using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class EmployeeDiscountInInventItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeDiscountType",
                table: "InventItem");

            migrationBuilder.AddColumn<long>(
                name: "EmployeeDiscountId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_EmployeeDiscountId",
                table: "InventItem",
                column: "EmployeeDiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_EmployeeDiscount_EmployeeDiscountId",
                table: "InventItem",
                column: "EmployeeDiscountId",
                principalTable: "EmployeeDiscount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_EmployeeDiscount_EmployeeDiscountId",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_EmployeeDiscountId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "EmployeeDiscountId",
                table: "InventItem");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDiscountType",
                table: "InventItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
