using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class FixApprovalCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropColumn(
                name: "PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.AddColumn<decimal>(
                name: "IsActive",
                table: "PurchQuotationApprovalRuleCondition",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.AddColumn<long>(
                name: "PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition",
                column: "PurchQuotationApprovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition",
                column: "PurchQuotationApprovalId",
                principalTable: "PurchQuotationApproval",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
