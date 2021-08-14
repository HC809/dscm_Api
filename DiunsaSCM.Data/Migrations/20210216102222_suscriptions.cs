using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class suscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ShippingRouteStatusPresentationSchemaId",
                table: "ShippingRoute",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchOrderShipmentRouteStepSuscription",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchOrderShipmentHeaderId = table.Column<long>(nullable: false),
                    ShippingRouteStepId = table.Column<long>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchOrderShipmentRouteStepSuscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId",
                        column: x => x.PurchOrderShipmentHeaderId,
                        principalTable: "PurchOrderShipmentHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchOrderShipmentRouteStepSuscription_ShippingRouteStep_ShippingRouteStepId",
                        column: x => x.ShippingRouteStepId,
                        principalTable: "ShippingRouteStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingRouteStatusPresentationSchema",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    NoRisk = table.Column<decimal>(nullable: false),
                    LowRisk = table.Column<decimal>(nullable: false),
                    HighRisk = table.Column<decimal>(nullable: false),
                    OnTime = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingRouteStatusPresentationSchema", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRoute_ShippingRouteStatusPresentationSchemaId",
                table: "ShippingRoute",
                column: "ShippingRouteStatusPresentationSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeaderId",
                table: "PurchOrderShipmentRouteStepSuscription",
                column: "PurchOrderShipmentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentRouteStepSuscription_ShippingRouteStepId",
                table: "PurchOrderShipmentRouteStepSuscription",
                column: "ShippingRouteStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingRoute_ShippingRouteStatusPresentationSchema_ShippingRouteStatusPresentationSchemaId",
                table: "ShippingRoute",
                column: "ShippingRouteStatusPresentationSchemaId",
                principalTable: "ShippingRouteStatusPresentationSchema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingRoute_ShippingRouteStatusPresentationSchema_ShippingRouteStatusPresentationSchemaId",
                table: "ShippingRoute");

            migrationBuilder.DropTable(
                name: "PurchOrderShipmentRouteStepSuscription");

            migrationBuilder.DropTable(
                name: "ShippingRouteStatusPresentationSchema");

            migrationBuilder.DropIndex(
                name: "IX_ShippingRoute_ShippingRouteStatusPresentationSchemaId",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "ShippingRouteStatusPresentationSchemaId",
                table: "ShippingRoute");
        }
    }
}
