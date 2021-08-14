using Microsoft.EntityFrameworkCore.Migrations;

namespace DiunsaSCM.Data.Migrations
{
    public partial class UserSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_CommercialEvent_CommercialEventId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShipmentType_ShipmentTypeId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipmentType",
                table: "ShipmentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommercialEvent",
                table: "CommercialEvent");

            migrationBuilder.RenameTable(
                name: "ShipmentType",
                newName: "ShipmentTypes");

            migrationBuilder.RenameTable(
                name: "CommercialEvent",
                newName: "CommercialEvents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipmentTypes",
                table: "ShipmentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommercialEvents",
                table: "CommercialEvents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_CommercialEvents_CommercialEventId",
                table: "PurchOrderShipmentHeader",
                column: "CommercialEventId",
                principalTable: "CommercialEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShipmentTypes_ShipmentTypeId",
                table: "PurchOrderShipmentHeader",
                column: "ShipmentTypeId",
                principalTable: "ShipmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_CommercialEvents_CommercialEventId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchOrderShipmentHeader_ShipmentTypes_ShipmentTypeId",
                table: "PurchOrderShipmentHeader");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipmentTypes",
                table: "ShipmentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommercialEvents",
                table: "CommercialEvents");

            migrationBuilder.RenameTable(
                name: "ShipmentTypes",
                newName: "ShipmentType");

            migrationBuilder.RenameTable(
                name: "CommercialEvents",
                newName: "CommercialEvent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipmentType",
                table: "ShipmentType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommercialEvent",
                table: "CommercialEvent",
                column: "Id");

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
    }
}
