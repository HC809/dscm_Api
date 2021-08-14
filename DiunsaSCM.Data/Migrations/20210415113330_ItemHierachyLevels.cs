using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class ItemHierachyLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemHierarchyLevel",
                table: "ItemHierarchy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "ItemHierarchy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemHierarchy_ParentId",
                table: "ItemHierarchy",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemHierarchy_ItemHierarchy_ParentId",
                table: "ItemHierarchy",
                column: "ParentId",
                principalTable: "ItemHierarchy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemHierarchy_ItemHierarchy_ParentId",
                table: "ItemHierarchy");

            migrationBuilder.DropIndex(
                name: "IX_ItemHierarchy_ParentId",
                table: "ItemHierarchy");

            migrationBuilder.DropColumn(
                name: "ItemHierarchyLevel",
                table: "ItemHierarchy");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ItemHierarchy");
        }
    }
}
