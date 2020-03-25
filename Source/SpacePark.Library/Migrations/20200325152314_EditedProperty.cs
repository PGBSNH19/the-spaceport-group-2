using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Library.Migrations
{
    public partial class EditedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots");

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingLots",
                nullable: true,
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

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "ParkingLots",
                type: "int",
                nullable: true,
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
