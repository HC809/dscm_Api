using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class PreparingForDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShippingStepType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShippingStepType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ShippingStepType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ShippingStepType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShippingRouteStep",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShippingRouteStep",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ShippingRouteStep",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ShippingRouteStep",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ShippingRoute",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShippingRoute",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ShippingRoute",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ShippingRoute",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Port",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Port",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Port",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Port",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Port",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Country",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShippingStepType");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShippingStepType");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ShippingStepType");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ShippingStepType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ShippingRouteStep");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ShippingRoute");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Port");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Country");
        }
    }
}
