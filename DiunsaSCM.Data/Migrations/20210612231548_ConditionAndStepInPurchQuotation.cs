using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class ConditionAndStepInPurchQuotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotationApprovalLog",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalLog_PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotationApprovalLog",
                column: "PurchQuotationApprovalRuleConditionStepId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotation_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotation",
                column: "PurchQuotationApprovalRuleConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotation_PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotation",
                column: "PurchQuotationApprovalRuleConditionStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotation_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotation",
                column: "PurchQuotationApprovalRuleConditionId",
                principalTable: "PurchQuotationApprovalRuleCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotation_PurchQuotationApprovalRuleConditionStep_PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotation",
                column: "PurchQuotationApprovalRuleConditionStepId",
                principalTable: "PurchQuotationApprovalRuleConditionStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalLog_PurchQuotationApprovalRuleConditionStep_PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotationApprovalLog",
                column: "PurchQuotationApprovalRuleConditionStepId",
                principalTable: "PurchQuotationApprovalRuleConditionStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotation_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotation_PurchQuotationApprovalRuleConditionStep_PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotation");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalLog_PurchQuotationApprovalRuleConditionStep_PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationApprovalLog_PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotation_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotation");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotation_PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropColumn(
                name: "PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "PurchQuotationApprovalRuleConditionStepId",
                table: "PurchQuotation");
        }
    }
}
