using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Library.Migrations
{
    public partial class addedstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "ParkingNO",
                table: "VisitorParking");

            migrationBuilder.DropColumn(
                name: "ParkingLotNO",
                table: "ParkingLots");

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

            migrationBuilder.AddColumn<int>(
                name: "ParkingNO",
                table: "VisitorParking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingLots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParkingLotNO",
                table: "ParkingLots",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
