using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class RulesAndConditionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.AddColumn<string>(
                name: "ComparisonValue",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LowerBound",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PurchQuotationApprovalRuleConditionComparisonOperation",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchQuotationApprovalRuleConditionField",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UpperBound",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Priority",
                table: "PurchQuotationApprovalRuleCondition",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropColumn(
                name: "ComparisonValue",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "LowerBound",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "PurchQuotationApprovalRuleConditionComparisonOperation",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "PurchQuotationApprovalRuleConditionField",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "UpperBound",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropColumn(
                name: "PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PurchQuotationApprovalRuleConditionTerm",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
