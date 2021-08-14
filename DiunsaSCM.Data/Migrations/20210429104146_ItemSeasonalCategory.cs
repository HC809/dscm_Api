using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class ItemSeasonalCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ItemSeasonalCategoryId",
                table: "InventItem",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemSeasonalCategory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSeasonalCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_ItemSeasonalCategoryId",
                table: "InventItem",
                column: "ItemSeasonalCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventItem_ItemSeasonalCategory_ItemSeasonalCategoryId",
                table: "InventItem",
                column: "ItemSeasonalCategoryId",
                principalTable: "ItemSeasonalCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventItem_ItemSeasonalCategory_ItemSeasonalCategoryId",
                table: "InventItem");

            migrationBuilder.DropTable(
                name: "ItemSeasonalCategory");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_ItemSeasonalCategoryId",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "ItemSeasonalCategoryId",
                table: "InventItem");
        }
    }
}
