using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class Incoterms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "Incoterm",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.AddColumn<long>(
                name: "IncotermId",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Incoterm",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incoterm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_IncotermId",
                table: "PurchOrderShipmentHeader",
                column: "IncotermId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_Incoterm_IncotermId",
                table: "PurchOrderShipmentHeader",
                column: "IncotermId",
                principalTable: "Incoterm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_Incoterm_IncotermId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropTable(
                name: "Incoterm");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_IncotermId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "IncotermId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.AddColumn<long>(
                name: "CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Incoterm",
                table: "PurchOrderShipmentHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                column: "CurrentShippingRouteStepId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                column: "PreparationCurrentShippingRouteStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                column: "CurrentShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShippingRouteStep_PreparationCurrentShippingRouteStepId",
                table: "PurchOrderShipmentHeader",
                column: "PreparationCurrentShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
