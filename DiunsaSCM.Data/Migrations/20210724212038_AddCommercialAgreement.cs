using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class AddCommercialAgreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommercialAgreement",
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
                    table.PrimaryKey("PK_CommercialAgreement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventItemPurchPriceLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    PurchPrice = table.Column<decimal>(nullable: false),
                    PurchQuotationLineId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventItemPurchPriceLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventItemPurchPriceLog_PurchQuotationLine_PurchQuotationLineId",
                        column: x => x.PurchQuotationLineId,
                        principalTable: "PurchQuotationLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationCreator",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationCreator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchRoleItemHierarchy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    PurchRoleId = table.Column<long>(nullable: false),
                    ItemHierarchyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchRoleItemHierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchRoleItemHierarchy_ItemHierarchy_ItemHierarchyId",
                        column: x => x.ItemHierarchyId,
                        principalTable: "ItemHierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchRoleItemHierarchy_PurchRole_PurchRoleId",
                        column: x => x.PurchRoleId,
                        principalTable: "PurchRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorItemHierarchy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    VendorId = table.Column<long>(nullable: false),
                    ItemHierarchyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorItemHierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorItemHierarchy_ItemHierarchy_ItemHierarchyId",
                        column: x => x.ItemHierarchyId,
                        principalTable: "ItemHierarchy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendorItemHierarchy_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchQuotationCreatorRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchQuotationCreatorId = table.Column<long>(nullable: false),
                    PurchRoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchQuotationCreatorRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchQuotationCreatorRole_PurchQuotationCreator_PurchQuotationCreatorId",
                        column: x => x.PurchQuotationCreatorId,
                        principalTable: "PurchQuotationCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchQuotationCreatorRole_PurchRole_PurchRoleId",
                        column: x => x.PurchRoleId,
                        principalTable: "PurchRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventItemPurchPriceLog_PurchQuotationLineId",
                table: "InventItemPurchPriceLog",
                column: "PurchQuotationLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationCreatorRole_PurchQuotationCreatorId",
                table: "PurchQuotationCreatorRole",
                column: "PurchQuotationCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotationCreatorRole_PurchRoleId",
                table: "PurchQuotationCreatorRole",
                column: "PurchRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchRoleItemHierarchy_ItemHierarchyId",
                table: "PurchRoleItemHierarchy",
                column: "ItemHierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchRoleItemHierarchy_PurchRoleId",
                table: "PurchRoleItemHierarchy",
                column: "PurchRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorItemHierarchy_ItemHierarchyId",
                table: "VendorItemHierarchy",
                column: "ItemHierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorItemHierarchy_VendorId",
                table: "VendorItemHierarchy",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommercialAgreement");

            migrationBuilder.DropTable(
                name: "InventItemPurchPriceLog");

            migrationBuilder.DropTable(
                name: "PurchQuotationCreatorRole");

            migrationBuilder.DropTable(
                name: "PurchRoleItemHierarchy");

            migrationBuilder.DropTable(
                name: "VendorItemHierarchy");

            migrationBuilder.DropTable(
                name: "PurchQuotationCreator");
        }
    }
}
