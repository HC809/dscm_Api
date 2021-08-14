using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PurchQuotationFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PurchOrderHeaderId",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PurchPaymentConditionId",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchPaymentConditionCode",
                table: "PurchOrderHeader",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchPaymentCondition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchPaymentCondition", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotation_CurrencyId",
                table: "PurchQuotation",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotation_PurchOrderHeaderId",
                table: "PurchQuotation",
                column: "PurchOrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotation_PurchPaymentConditionId",
                table: "PurchQuotation",
                column: "PurchPaymentConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotation_Currency_CurrencyId",
                table: "PurchQuotation",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotation_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchQuotation",
                column: "PurchOrderHeaderId",
                principalTable: "PurchOrderHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotation_PurchPaymentCondition_PurchPaymentConditionId",
                table: "PurchQuotation",
                column: "PurchPaymentConditionId",
                principalTable: "PurchPaymentCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotation_Currency_CurrencyId",
                table: "PurchQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotation_PurchOrderHeader_PurchOrderHeaderId",
                table: "PurchQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotation_PurchPaymentCondition_PurchPaymentConditionId",
                table: "PurchQuotation");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "PurchPaymentCondition");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotation_CurrencyId",
                table: "PurchQuotation");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotation_PurchOrderHeaderId",
                table: "PurchQuotation");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotation_PurchPaymentConditionId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "PurchOrderHeaderId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "PurchPaymentConditionId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "PurchPaymentConditionCode",
                table: "PurchOrderHeader");
        }
    }
}
