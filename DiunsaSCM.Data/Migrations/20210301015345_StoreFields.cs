using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class StoreFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackStoreLocationCode",
                table: "Store",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IncludedInSKUAnalysis",
                table: "Store",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Store",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StoreLocationCode",
                table: "Store",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackStoreLocationCode",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "IncludedInSKUAnalysis",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StoreLocationCode",
                table: "Store");
        }
    }
}
