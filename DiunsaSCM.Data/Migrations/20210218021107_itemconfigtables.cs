using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class itemconfigtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventDim",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventDim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventDimGroup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventDimGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventItemGroup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventItemGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationApprovalLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationApprovalLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationApprovalRule",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationApprovalRule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationApprovals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationApprovals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxItemGroupHeading",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxItemGroupHeading", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxOnItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxOnItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationLine",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PurchQuotationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchQuotationLine_PurchQuotation_PurchQuotationId",
                        column: x => x.PurchQuotationId,
                        principalTable: "PurchQuotation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationApprovalRuleCondition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PurchQuotationApprovalRuleId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationApprovalRuleCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId",
                        column: x => x.PurchQuotationApprovalRuleId,
                        principalTable: "PurchQuotationApprovalRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitConvert",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUnitId = table.Column<long>(nullable: false),
                    ToUnitId = table.Column<long>(nullable: false),
                    Factor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitConvert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitConvert_Unit_FromUnitId",
                        column: x => x.FromUnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitConvert_Unit_ToUnitId",
                        column: x => x.ToUnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationApprovalRuleConditionTerm",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PurchQuotationApprovalRuleConditionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationApprovalRuleConditionTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId",
                        column: x => x.PurchQuotationApprovalRuleConditionId,
                        principalTable: "PurchQuotationApprovalRuleCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleId",
                table: "PurchQuotationApprovalRuleCondition",
                column: "PurchQuotationApprovalRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleConditionId",
                table: "PurchQuotationApprovalRuleConditionTerm",
                column: "PurchQuotationApprovalRuleConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationLine_PurchQuotationId",
                table: "PurchQuotationLine",
                column: "PurchQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConvert_FromUnitId",
                table: "UnitConvert",
                column: "FromUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConvert_ToUnitId",
                table: "UnitConvert",
                column: "ToUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "InventDim");

            migrationBuilder.DropTable(
                name: "InventDimGroup");

            migrationBuilder.DropTable(
                name: "InventItemGroup");

            migrationBuilder.DropTable(
                name: "PurchQuotationApprovalLog");

            migrationBuilder.DropTable(
                name: "PurchQuotationApprovalRuleConditionTerm");

            migrationBuilder.DropTable(
                name: "PurchQuotationApprovals");

            migrationBuilder.DropTable(
                name: "PurchQuotationLine");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "TaxItemGroupHeading");

            migrationBuilder.DropTable(
                name: "TaxOnItem");

            migrationBuilder.DropTable(
                name: "UnitConvert");

            migrationBuilder.DropTable(
                name: "PurchQuotationApprovalRuleCondition");

            migrationBuilder.DropTable(
                name: "PurchQuotation");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "PurchQuotationApprovalRule");
        }
    }
}
