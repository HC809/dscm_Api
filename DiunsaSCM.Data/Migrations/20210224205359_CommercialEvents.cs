using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class CommercialEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CommercialEventId",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShipmentTypeId",
                table: "PurchOrderShipmentHeader",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommercialEvent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_CommercialEventId",
                table: "PurchOrderShipmentHeader",
                column: "CommercialEventId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchOrderShipmentHeader_ShipmentTypeId",
                table: "PurchOrderShipmentHeader",
                column: "ShipmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_CommercialEvent_CommercialEventId",
                table: "PurchOrderShipmentHeader",
                column: "CommercialEventId",
                principalTable: "CommercialEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShipmentType_ShipmentTypeId",
                table: "PurchOrderShipmentHeader",
                column: "ShipmentTypeId",
                principalTable: "ShipmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_CommercialEvent_CommercialEventId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShipmentType_ShipmentTypeId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropTable(
                name: "CommercialEvent");

            migrationBuilder.DropTable(
                name: "ShipmentType");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_CommercialEventId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropIndex(
                name: "IX_PurchOrderShipmentHeader_ShipmentTypeId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "CommercialEventId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropColumn(
                name: "ShipmentTypeId",
                table: "PurchOrderShipmentHeader");
        }
    }
}
