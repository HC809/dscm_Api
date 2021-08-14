using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class FreeTimeDatesInContainers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FreeTimeBoxLimitDate",
                table: "ShipmentContainer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FreeTimeChassisLimitDate",
                table: "ShipmentContainer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeTimeBoxLimitDate",
                table: "ShipmentContainer");

            migrationBuilder.DropColumn(
                name: "FreeTimeChassisLimitDate",
                table: "ShipmentContainer");
        }
    }
}
