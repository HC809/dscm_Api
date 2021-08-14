using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class AddInventItemEnrolment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "InventItemEnrolments");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CellphoneNumer",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrencyId",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FiscalCode",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IncotermId",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAlias",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PurchCommercialDepartmentId",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PurchPaymentConditionId",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SinglePurchOrderShipment",
                table: "Vendor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "TaxItemGroupHeadingId",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelephoneNumber",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                table: "Vendor",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InventItemId",
                table: "InventItemPurchPriceLog",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "BlckedForInventory",
                table: "InventItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BlckedForPurch",
                table: "InventItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "InventItemEnrolment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true, defaultValueSql: "'MA' + Format(NEXT VALUE FOR dbo.InventItemEnrolments,'D8')"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventItemEnrolment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventItemEnrolmentDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    InventItemEnrolmentId = table.Column<long>(nullable: false),
                    InventItemId = table.Column<long>(nullable: false),
                    InventDimId = table.Column<long>(nullable: true),
                    ItemBarcodeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventItemEnrolmentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventItemEnrolmentDetail_InventDim_InventDimId",
                        column: x => x.InventDimId,
                        principalTable: "InventDim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventItemEnrolmentDetail_InventItemEnrolment_InventItemEnrolmentId",
                        column: x => x.InventItemEnrolmentId,
                        principalTable: "InventItemEnrolment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventItemEnrolmentDetail_InventItem_InventItemId",
                        column: x => x.InventItemId,
                        principalTable: "InventItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventItemEnrolmentDetail_ItemBarcode_ItemBarcodeId",
                        column: x => x.ItemBarcodeId,
                        principalTable: "ItemBarcode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_CountryId",
                table: "Vendor",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_CurrencyId",
                table: "Vendor",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_IncotermId",
                table: "Vendor",
                column: "IncotermId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_PurchCommercialDepartmentId",
                table: "Vendor",
                column: "PurchCommercialDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_PurchPaymentConditionId",
                table: "Vendor",
                column: "PurchPaymentConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_TaxItemGroupHeadingId",
                table: "Vendor",
                column: "TaxItemGroupHeadingId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_WarehouseId",
                table: "Vendor",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemEnrolment_Code",
                table: "InventItemEnrolment",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemEnrolmentDetail_InventDimId",
                table: "InventItemEnrolmentDetail",
                column: "InventDimId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemEnrolmentDetail_InventItemEnrolmentId",
                table: "InventItemEnrolmentDetail",
                column: "InventItemEnrolmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemEnrolmentDetail_InventItemId",
                table: "InventItemEnrolmentDetail",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventItemEnrolmentDetail_ItemBarcodeId",
                table: "InventItemEnrolmentDetail",
                column: "ItemBarcodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_Country_CountryId",
                table: "Vendor",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_Currency_CurrencyId",
                table: "Vendor",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_Incoterm_IncotermId",
                table: "Vendor",
                column: "IncotermId",
                principalTable: "Incoterm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_PurchCommercialDepartment_PurchCommercialDepartmentId",
                table: "Vendor",
                column: "PurchCommercialDepartmentId",
                principalTable: "PurchCommercialDepartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_PurchPaymentCondition_PurchPaymentConditionId",
                table: "Vendor",
                column: "PurchPaymentConditionId",
                principalTable: "PurchPaymentCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "Vendor",
                column: "TaxItemGroupHeadingId",
                principalTable: "TaxItemGroupHeading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendor_Warehouse_WarehouseId",
                table: "Vendor",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_Country_CountryId",
                table: "Vendor");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_Currency_CurrencyId",
                table: "Vendor");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_Incoterm_IncotermId",
                table: "Vendor");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_PurchCommercialDepartment_PurchCommercialDepartmentId",
                table: "Vendor");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_PurchPaymentCondition_PurchPaymentConditionId",
                table: "Vendor");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_TaxItemGroupHeading_TaxItemGroupHeadingId",
                table: "Vendor");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendor_Warehouse_WarehouseId",
                table: "Vendor");

            migrationBuilder.DropTable(
                name: "InventItemEnrolmentDetail");

            migrationBuilder.DropTable(
                name: "InventItemEnrolment");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_CountryId",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_CurrencyId",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_IncotermId",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_PurchCommercialDepartmentId",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_PurchPaymentConditionId",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_TaxItemGroupHeadingId",
                table: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Vendor_WarehouseId",
                table: "Vendor");

            migrationBuilder.DropSequence(
                name: "InventItemEnrolments");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "CellphoneNumer",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "FiscalCode",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "IncotermId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "NameAlias",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "PurchCommercialDepartmentId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "PurchPaymentConditionId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "SinglePurchOrderShipment",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "TaxItemGroupHeadingId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "TelephoneNumber",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "InventItemId",
                table: "InventItemPurchPriceLog");

            migrationBuilder.DropColumn(
                name: "BlckedForInventory",
                table: "InventItem");

            migrationBuilder.DropColumn(
                name: "BlckedForPurch",
                table: "InventItem");
        }
    }
}
