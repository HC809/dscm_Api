using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class DatesOnShipmentContainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EquipmentPickupDate",
                table: "ShipmentContainer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedGateUnloadDate",
                table: "ShipmentContainer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RealGateUnloadDate",
                table: "ShipmentContainer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToShippingCompanyNotificationDate",
                table: "ShipmentContainer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentPickupDate",
                table: "ShipmentContainer");

            migrationBuilder.DropColumn(
                name: "EstimatedGateUnloadDate",
                table: "ShipmentContainer");

            migrationBuilder.DropColumn(
                name: "RealGateUnloadDate",
                table: "ShipmentContainer");

            migrationBuilder.DropColumn(
                name: "ToShippingCompanyNotificationDate",
                table: "ShipmentContainer");
        }
    }
}
