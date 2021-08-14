using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameAlias",
                table: "InventItem",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventItem",
                nullable: true,
                defaultValueSql: "Format(NEXT VALUE FOR dbo.InventItems,'D8')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "Format(NEXT VALUE FOR dbo.InventItems,'D8')");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_Code",
                table: "InventItem",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_InventItem_NameAlias",
                table: "InventItem",
                column: "NameAlias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventItem_Code",
                table: "InventItem");

            migrationBuilder.DropIndex(
                name: "IX_InventItem_NameAlias",
                table: "InventItem");

            migrationBuilder.AlterColumn<string>(
                name: "NameAlias",
                table: "InventItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "InventItem",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "Format(NEXT VALUE FOR dbo.InventItems,'D8')",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "Format(NEXT VALUE FOR dbo.InventItems,'D8')");
        }
    }
}
