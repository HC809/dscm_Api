using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class Indexes_Multiple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InventItem_Code_NameAlias",
                table: "InventItem",
                columns: new[] { "Code", "NameAlias" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventItem_Code_NameAlias",
                table: "InventItem");
        }
    }
}
