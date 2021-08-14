using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class ModifiyingShipmentImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentImport_ShippingRouteStep_CurrentShippingRouteStepId",
                table: "ShipmentImport");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentImport_ShippingCompany_ShippingCompanyId",
                table: "ShipmentImport");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentImport_ShippingRoute_ShippingRouteId",
                table: "ShipmentImport");

            migrationBuilder.AlterColumn<long>(
                name: "ShippingRouteId",
                table: "ShipmentImport",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ShippingCompanyId",
                table: "ShipmentImport",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CurrentShippingRouteStepId",
                table: "ShipmentImport",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentImport_ShippingRouteStep_CurrentShippingRouteStepId",
                table: "ShipmentImport",
                column: "CurrentShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentImport_ShippingCompany_ShippingCompanyId",
                table: "ShipmentImport",
                column: "ShippingCompanyId",
                principalTable: "ShippingCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentImport_ShippingRoute_ShippingRouteId",
                table: "ShipmentImport",
                column: "ShippingRouteId",
                principalTable: "ShippingRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentImport_ShippingRouteStep_CurrentShippingRouteStepId",
                table: "ShipmentImport");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentImport_ShippingCompany_ShippingCompanyId",
                table: "ShipmentImport");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentImport_ShippingRoute_ShippingRouteId",
                table: "ShipmentImport");

            migrationBuilder.AlterColumn<long>(
                name: "ShippingRouteId",
                table: "ShipmentImport",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ShippingCompanyId",
                table: "ShipmentImport",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CurrentShippingRouteStepId",
                table: "ShipmentImport",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentImport_ShippingRouteStep_CurrentShippingRouteStepId",
                table: "ShipmentImport",
                column: "CurrentShippingRouteStepId",
                principalTable: "ShippingRouteStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentImport_ShippingCompany_ShippingCompanyId",
                table: "ShipmentImport",
                column: "ShippingCompanyId",
                principalTable: "ShippingCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentImport_ShippingRoute_ShippingRouteId",
                table: "ShipmentImport",
                column: "ShippingRouteId",
                principalTable: "ShippingRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
