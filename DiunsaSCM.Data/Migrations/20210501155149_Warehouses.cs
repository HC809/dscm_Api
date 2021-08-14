using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class Warehouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "PurchQuotation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentDateConfirmed",
                table: "PurchQuotation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentDateRequested",
                table: "PurchQuotation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                table: "PurchQuotation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "PurchOrderHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentDateConfirmed",
                table: "PurchOrderHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipmentDateRequested",
                table: "PurchOrderHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WarehouseCode",
                table: "PurchOrderHeader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseDescription",
                table: "PurchOrderHeader",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UME",
                table: "InventItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchQuotation_WarehouseId",
                table: "PurchQuotation",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchQuotation_Warehouse_WarehouseId",
                table: "PurchQuotation",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchQuotation_Warehouse_WarehouseId",
                table: "PurchQuotation");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_PurchQuotation_WarehouseId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "ShipmentDateConfirmed",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "ShipmentDateRequested",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "PurchQuotation");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "ShipmentDateConfirmed",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "ShipmentDateRequested",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "WarehouseCode",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "WarehouseDescription",
                table: "PurchOrderHeader");

            migrationBuilder.DropColumn(
                name: "UME",
                table: "InventItem");
        }
    }
}
