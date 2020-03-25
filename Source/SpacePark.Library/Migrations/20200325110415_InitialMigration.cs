using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Library.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceCredit = table.Column<int>(nullable: false),
                    TimestampDateOfPayment = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptID);
                });

            migrationBuilder.CreateTable(
                name: "SpacePorts",
                columns: table => new
                {
                    SpacePortID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingSpace = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpacePorts", x => x.SpacePortID);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorID);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    ParkingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingOccupied = table.Column<bool>(nullable: false),
                    SpacePortID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.ParkingID);
                    table.ForeignKey(
                        name: "FK_Parkings_SpacePorts_SpacePortID",
                        column: x => x.SpacePortID,
                        principalTable: "SpacePorts",
                        principalColumn: "SpacePortID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitorParking",
                columns: table => new
                {
                    VisitorParkingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingID = table.Column<int>(nullable: false),
                    VisitorID = table.Column<int>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    ReceiptID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorParking", x => x.VisitorParkingID);
                    table.ForeignKey(
                        name: "FK_VisitorParking_Parkings_ParkingID",
                        column: x => x.ParkingID,
                        principalTable: "Parkings",
                        principalColumn: "ParkingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorParking_Receipts_ReceiptID",
                        column: x => x.ReceiptID,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorParking_Visitors_VisitorID",
                        column: x => x.VisitorID,
                        principalTable: "Visitors",
                        principalColumn: "VisitorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_SpacePortID",
                table: "Parkings",
                column: "SpacePortID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorParking_ParkingID",
                table: "VisitorParking",
                column: "ParkingID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorParking_ReceiptID",
                table: "VisitorParking",
                column: "ReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorParking_VisitorID",
                table: "VisitorParking",
                column: "VisitorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitorParking");

            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "SpacePorts");
        }
    }
}
