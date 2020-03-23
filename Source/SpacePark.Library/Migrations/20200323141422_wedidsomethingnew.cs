using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Library.Migrations
{
    public partial class wedidsomethingnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlarkingLots_SpacePorts_SpacePortID",
                table: "PlarkingLots");

            migrationBuilder.DropForeignKey(
                name: "FK_PlarkingLots_Visitors_VisitorID",
                table: "PlarkingLots");

            migrationBuilder.DropIndex(
                name: "IX_PlarkingLots_VisitorID",
                table: "PlarkingLots");

            migrationBuilder.DropColumn(
                name: "VisitorID",
                table: "PlarkingLots");

            migrationBuilder.AddColumn<int>(
                name: "ParkingLotID",
                table: "Visitors",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "PlarkingLots",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_ParkingLotID",
                table: "Visitors",
                column: "ParkingLotID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlarkingLots_SpacePorts_SpacePortID",
                table: "PlarkingLots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_PlarkingLots_ParkingLotID",
                table: "Visitors",
                column: "ParkingLotID",
                principalTable: "PlarkingLots",
                principalColumn: "ParkingLotID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlarkingLots_SpacePorts_SpacePortID",
                table: "PlarkingLots");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_PlarkingLots_ParkingLotID",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_ParkingLotID",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "ParkingLotID",
                table: "Visitors");

            migrationBuilder.AlterColumn<int>(
                name: "SpacePortID",
                table: "PlarkingLots",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitorID",
                table: "PlarkingLots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlarkingLots_VisitorID",
                table: "PlarkingLots",
                column: "VisitorID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlarkingLots_SpacePorts_SpacePortID",
                table: "PlarkingLots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlarkingLots_Visitors_VisitorID",
                table: "PlarkingLots",
                column: "VisitorID",
                principalTable: "Visitors",
                principalColumn: "VisitorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
