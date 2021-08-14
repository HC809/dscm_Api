using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PurchApprovalEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PurchCommercialDepartmentId",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InventItemPrepackBarcode",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<decimal>(nullable: false),
                    InventItemId = table.Column<long>(nullable: false),
                    ItemBarcodeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventItemPrepackBarcode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventItemPrepackBarcode_InventItem_InventItemId",
                        column: x => x.InventItemId,
                        principalTable: "InventItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventItemPrepackBarcode_ItemBarcode_ItemBarcodeId",
                        column: x => x.ItemBarcodeId,
                        principalTable: "ItemBarcode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchCommercialDepartment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchCommercialDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchOrderShipmentCrossDocking",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<decimal>(nullable: false),
                    PurchOrderShipmentDetailId = table.Column<long>(nullable: false),
                    WarehouseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchOrderShipmentCrossDocking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentCrossDocking_PurchOrderShipmentDetail_PurchOrderShipmentDetailId",
                        column: x => x.PurchOrderShipmentDetailId,
                        principalTable: "PurchOrderShipmentDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentCrossDocking_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationApprovalRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    PurchQuotationApprovalId = table.Column<long>(nullable: false),
                    PurchRoleId = table.Column<long>(nullable: false),
                    PurchCommercialDepartmentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationApprovalRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchQuotationApprovalRole_PurchCommercialDepartment_PurchCommercialDepartmentId",
                        column: x => x.PurchCommercialDepartmentId,
                        principalTable: "PurchCommercialDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchQuotationApprovalRole_PurchQuotationApproval_PurchQuotationApprovalId",
                        column: x => x.PurchQuotationApprovalId,
                        principalTable: "PurchQuotationApproval",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchQuotationApprovalRole_PurchRole_PurchRoleId",
                        column: x => x.PurchRoleId,
                        principalTable: "PurchRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationApprovalRuleConditionStep",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    PurchQuotationApprovalRuleConditionId = table.Column<long>(nullable: false),
                    PurchRoleId = table.Column<long>(nullable: false),
                    Order = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationApprovalRuleConditionStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchQuotationApprovalRuleConditionStep_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                        column: x => x.PurchQuotationApprovalRuleConditionId,
                        principalTable: "PurchQuotationApprovalRuleCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchQuotationApprovalRuleConditionStep_PurchRole_PurchRoleId",
                        column: x => x.PurchRoleId,
                        principalTable: "PurchRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotation_PurchCommercialDepartmentId",
                table: "PurchQuotation",
                column: "PurchCommercialDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemPrepackBarcode_InventItemId",
                table: "InventItemPrepackBarcode",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemPrepackBarcode_ItemBarcodeId",
                table: "InventItemPrepackBarcode",
                column: "ItemBarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentCrossDocking_PurchOrderShipmentDetailId",
                table: "PurchOrderShipmentCrossDocking",
                column: "PurchOrderShipmentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentCrossDocking_WarehouseId",
                table: "PurchOrderShipmentCrossDocking",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRole_PurchCommercialDepartmentId",
                table: "PurchQuotationApprovalRole",
                column: "PurchCommercialDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRole_PurchQuotationApprovalId",
                table: "PurchQuotationApprovalRole",
                column: "PurchQuotationApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRole_PurchRoleId",
                table: "PurchQuotationApprovalRole",
                column: "PurchRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRuleConditionStep_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionStep",
                column: "PurchQuotationApprovalRuleConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRuleConditionStep_PurchRoleId",
                table: "PurchQuotationApprovalRuleConditionStep",
                column: "PurchRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotation_PurchCommercialDepartment_PurchCommercialDepartmentId",
                table: "PurchQuotation",
                column: "PurchCommercialDepartmentId",
                principalTable: "PurchCommercialDepartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotation_PurchCommercialDepartment_PurchCommercialDepartmentId",
                table: "PurchQuotation");

            migrationBuilder.DropTable(
                name: "InventItemPrepackBarcode");

            migrationBuilder.DropTable(
                name: "PurchOrderShipmentCrossDocking");

            migrationBuilder.DropTable(
                name: "PurchQuotationApprovalRole");

            migrationBuilder.DropTable(
                name: "PurchQuotationApprovalRuleConditionStep");

            migrationBuilder.DropTable(
                name: "PurchCommercialDepartment");

            migrationBuilder.DropTable(
                name: "PurchRole");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotation_PurchCommercialDepartmentId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "PurchCommercialDepartmentId",
                table: "PurchQuotation");
        }
    }
}
