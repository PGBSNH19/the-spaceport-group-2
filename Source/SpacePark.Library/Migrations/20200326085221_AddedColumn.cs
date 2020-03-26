using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Library.Migrations
{
    public partial class AddedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEntry",
                table: "VisitorParking",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingLots",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "DateOfEntry",
                table: "VisitorParking");

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingLots",
                type: "int",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
