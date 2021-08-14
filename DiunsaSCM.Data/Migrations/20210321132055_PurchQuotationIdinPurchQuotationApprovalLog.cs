using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PurchQuotationIdinPurchQuotationApprovalLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ShippingStepType");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ShippingStepType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Country");

            migrationBuilder.AlterColumn<long>(
                name: "PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PurchQuotationId",
                table: "PurchQuotationApprovalLog",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalLog_PurchQuotationId",
                table: "PurchQuotationApprovalLog",
                column: "PurchQuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalLog_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationApprovalLog",
                column: "PurchQuotationId",
                principalTable: "PurchQuotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition",
                column: "PurchQuotationApprovalRuleId",
                principalTable: "PurchQuotationApprovalRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm",
                column: "PurchQuotationApprovalRuleConditionId",
                principalTable: "PurchQuotationApprovalRuleCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalLog_PurchQuotation_PurchQuotationId",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotationApprovalLog_PurchQuotationId",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.DropColumn(
                name: "PurchQuotationId",
                table: "PurchQuotationApprovalLog");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ShippingStepType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ShippingStepType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ShippingRouteStep",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ShippingRouteStep",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ShippingRoute",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ShippingRoute",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Port",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Port",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Country",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition",
                column: "PurchQuotationApprovalRuleId",
                principalTable: "PurchQuotationApprovalRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm",
                column: "PurchQuotationApprovalRuleConditionId",
                principalTable: "PurchQuotationApprovalRuleCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
