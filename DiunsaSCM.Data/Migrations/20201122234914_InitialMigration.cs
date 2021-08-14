using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    NameAlias = table.Column<string>(nullable: true),
                    ItemGroupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemBarcode",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(nullable: true),
                    ItemId = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    NameAlias = table.Column<string>(nullable: true),
                    InventColorId = table.Column<string>(nullable: true),
                    InventSizeId = table.Column<string>(nullable: true),
                    BarcodeSetupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBarcode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Port",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Route = table.Column<string>(nullable: true),
                    TransitTime = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchOrderHeader",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PurchId = table.Column<string>(nullable: true),
                    VendorAccount = table.Column<string>(nullable: true),
                    PurchStatus = table.Column<int>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    CreatedDatetime = table.Column<DateTime>(nullable: false),
                    PurchName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchOrderHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentContainerType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CubicCapacity = table.Column<decimal>(nullable: false),
                    LoadCapacity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentContainerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingCompany",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    VendorAccount = table.Column<string>(nullable: true),
                    FreeTimeBoxDays = table.Column<decimal>(nullable: false),
                    FreeTimeBoxHours = table.Column<decimal>(nullable: false),
                    FreeTimeChassisDays = table.Column<decimal>(nullable: false),
                    FreeTimeChassisHours = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchOrderDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PurchOrderHeaderId = table.Column<long>(nullable: false),
                    PurchId = table.Column<string>(nullable: true),
                    ItemId = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    NameAlias = table.Column<string>(nullable: true),
                    QtyOrdered = table.Column<decimal>(nullable: false),
                    PurchUnit = table.Column<string>(nullable: true),
                    PurchPrice = table.Column<decimal>(nullable: false),
                    LineAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId",
                        column: x => x.PurchOrderHeaderId,
                        principalTable: "PurchOrderHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchOrderShipmentHeader",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchOrderHeaderId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ShipmentDateRequested = table.Column<DateTime>(nullable: false),
                    ShipmentDateConfirmed = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    ReceiptDateConfirmed = table.Column<DateTime>(nullable: false),
                    ShippingCompanyId = table.Column<long>(nullable: true),
                    BLNumber = table.Column<string>(nullable: true),
                    PortOfOriginId = table.Column<long>(nullable: true),
                    PortOfDestinationId = table.Column<long>(nullable: true),
                    EstimatedVolume = table.Column<decimal>(nullable: false),
                    EstimatedWeight = table.Column<decimal>(nullable: false),
                    Incoterm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchOrderShipmentHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentHeader_Port_PortOfDestinationId",
                        column: x => x.PortOfDestinationId,
                        principalTable: "Port",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentHeader_Port_PortOfOriginId",
                        column: x => x.PortOfOriginId,
                        principalTable: "Port",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId",
                        column: x => x.PurchOrderHeaderId,
                        principalTable: "PurchOrderHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentHeader_ShippingCompany_ShippingCompanyId",
                        column: x => x.ShippingCompanyId,
                        principalTable: "ShippingCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchOrderShipmentDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchOrderShipmentHeaderId = table.Column<long>(nullable: false),
                    PurchOrderDetailId = table.Column<long>(nullable: false),
                    QtyOnShipment = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchOrderShipmentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId",
                        column: x => x.PurchOrderDetailId,
                        principalTable: "PurchOrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentDetail_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                        column: x => x.PurchOrderShipmentHeaderId,
                        principalTable: "PurchOrderShipmentHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentContainer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchOrderShipmentHeaderId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ShipmentContainerTypeId = table.Column<long>(nullable: false),
                    ContainerNumber = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentContainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentContainer_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                        column: x => x.PurchOrderShipmentHeaderId,
                        principalTable: "PurchOrderShipmentHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentContainer_ShipmentContainerType_ShipmentContainerTypeId",
                        column: x => x.ShipmentContainerTypeId,
                        principalTable: "ShipmentContainerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentContainerDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentContainerId = table.Column<long>(nullable: false),
                    PurchOrderDetailId = table.Column<long>(nullable: false),
                    QtyOnContainer = table.Column<decimal>(nullable: false),
                    PurchOrderShipmentDetailId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentContainerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId",
                        column: x => x.PurchOrderDetailId,
                        principalTable: "PurchOrderDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ShipmentContainerDetail_PurchOrderShipmentDetail_PurchOrderShipmentDetailId",
                        column: x => x.PurchOrderShipmentDetailId,
                        principalTable: "PurchOrderShipmentDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ShipmentContainerDetail_ShipmentContainer_ShipmentContainerId",
                        column: x => x.ShipmentContainerId,
                        principalTable: "ShipmentContainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderDetail_PurchOrderHeaderId",
                table: "PurchOrderDetail",
                column: "PurchOrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentDetail_PurchOrderDetailId",
                table: "PurchOrderShipmentDetail",
                column: "PurchOrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentDetail_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentDetail",
                column: "PurchOrderShipmentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_PortOfDestinationId",
                table: "PurchOrderShipmentHeader",
                column: "PortOfDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_PortOfOriginId",
                table: "PurchOrderShipmentHeader",
                column: "PortOfOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_PurchOrderHeaderId",
                table: "PurchOrderShipmentHeader",
                column: "PurchOrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_ShippingCompanyId",
                table: "PurchOrderShipmentHeader",
                column: "ShippingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentContainer_PurchOrderShipmentHeaderId",
                table: "ShipmentContainer",
                column: "PurchOrderShipmentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentContainer_ShipmentContainerTypeId",
                table: "ShipmentContainer",
                column: "ShipmentContainerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentContainerDetail_PurchOrderDetailId",
                table: "ShipmentContainerDetail",
                column: "PurchOrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentContainerDetail_PurchOrderShipmentDetailId",
                table: "ShipmentContainerDetail",
                column: "PurchOrderShipmentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentContainerDetail_ShipmentContainerId",
                table: "ShipmentContainerDetail",
                column: "ShipmentContainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventItem");

            migrationBuilder.DropTable(
                name: "ItemBarcode");

            migrationBuilder.DropTable(
                name: "ShipmentContainerDetail");

            migrationBuilder.DropTable(
                name: "PurchOrderShipmentDetail");

            migrationBuilder.DropTable(
                name: "ShipmentContainer");

            migrationBuilder.DropTable(
                name: "PurchOrderDetail");

            migrationBuilder.DropTable(
                name: "PurchOrderShipmentHeader");

            migrationBuilder.DropTable(
                name: "ShipmentContainerType");

            migrationBuilder.DropTable(
                name: "Port");

            migrationBuilder.DropTable(
                name: "PurchOrderHeader");

            migrationBuilder.DropTable(
                name: "ShippingCompany");
        }
    }
}
