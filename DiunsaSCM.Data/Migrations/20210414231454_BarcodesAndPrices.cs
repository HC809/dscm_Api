using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class BarcodesAndPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarcodeBatch",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    QtyRequested = table.Column<int>(nullable: false),
                    QtyGenerated = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeBatch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarcodeSource",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangeFirst = table.Column<long>(nullable: false),
                    RangeLast = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPriceGroup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPriceGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesPriceDefinition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SalesPriceDefinitionStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPriceDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barcode",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<long>(nullable: false),
                    ControlDigit = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    BarcodeBatchId = table.Column<long>(nullable: false),
                    BarcodeSourceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barcode_BarcodeBatch_BarcodeBatchId",
                        column: x => x.BarcodeBatchId,
                        principalTable: "BarcodeBatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Barcode_BarcodeSource_BarcodeSourceId",
                        column: x => x.BarcodeSourceId,
                        principalTable: "BarcodeSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPrice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false),
                    InventItemId = table.Column<long>(nullable: false),
                    CustomerPriceGroupId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPrice_CustomerPriceGroup_CustomerPriceGroupId",
                        column: x => x.CustomerPriceGroupId,
                        principalTable: "CustomerPriceGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesPrice_InventItem_InventItemId",
                        column: x => x.InventItemId,
                        principalTable: "InventItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPriceDefinitionLine",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventItemId = table.Column<long>(nullable: true),
                    InventItemCode = table.Column<string>(nullable: true),
                    CustomerPriceGroupId = table.Column<long>(nullable: true),
                    CustomerPriceGroupCode = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SalesPriceId = table.Column<long>(nullable: true),
                    SalesPriceDefinitionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPriceDefinitionLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPriceDefinitionLine_CustomerPriceGroup_CustomerPriceGroupId",
                        column: x => x.CustomerPriceGroupId,
                        principalTable: "CustomerPriceGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPriceDefinitionLine_InventItem_InventItemId",
                        column: x => x.InventItemId,
                        principalTable: "InventItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId",
                        column: x => x.SalesPriceDefinitionId,
                        principalTable: "SalesPriceDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPriceDefinitionLine_SalesPrice_SalesPriceId",
                        column: x => x.SalesPriceId,
                        principalTable: "SalesPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barcode_BarcodeBatchId",
                table: "Barcode",
                column: "BarcodeBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Barcode_BarcodeSourceId",
                table: "Barcode",
                column: "BarcodeSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPrice_CustomerPriceGroupId",
                table: "SalesPrice",
                column: "CustomerPriceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPrice_InventItemId",
                table: "SalesPrice",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPriceDefinitionLine_CustomerPriceGroupId",
                table: "SalesPriceDefinitionLine",
                column: "CustomerPriceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPriceDefinitionLine_InventItemId",
                table: "SalesPriceDefinitionLine",
                column: "InventItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPriceDefinitionLine_SalesPriceDefinitionId",
                table: "SalesPriceDefinitionLine",
                column: "SalesPriceDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPriceDefinitionLine_SalesPriceId",
                table: "SalesPriceDefinitionLine",
                column: "SalesPriceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barcode");

            migrationBuilder.DropTable(
                name: "SalesPriceDefinitionLine");

            migrationBuilder.DropTable(
                name: "BarcodeBatch");

            migrationBuilder.DropTable(
                name: "BarcodeSource");

            migrationBuilder.DropTable(
                name: "SalesPriceDefinition");

            migrationBuilder.DropTable(
                name: "SalesPrice");

            migrationBuilder.DropTable(
                name: "CustomerPriceGroup");
        }
    }
}
