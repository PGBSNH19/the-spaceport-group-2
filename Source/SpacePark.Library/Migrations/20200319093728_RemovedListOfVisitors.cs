using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Library.Migrations
{
    public partial class RemovedListOfVisitors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_PlarkingLots_ParkingLotID",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_ParkingLotID",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "ParkingLotID",
                table: "Visitors");

            migrationBuilder.CreateIndex(
                name: "IX_PlarkingLots_VisitorID",
                table: "PlarkingLots",
                column: "VisitorID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlarkingLots_Visitors_VisitorID",
                table: "PlarkingLots",
                column: "VisitorID",
                principalTable: "Visitors",
                principalColumn: "VisitorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlarkingLots_Visitors_VisitorID",
                table: "PlarkingLots");

            migrationBuilder.DropIndex(
                name: "IX_PlarkingLots_VisitorID",
                table: "PlarkingLots");

            migrationBuilder.AddColumn<int>(
                name: "ParkingLotID",
                table: "Visitors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_ParkingLotID",
                table: "Visitors",
                column: "ParkingLotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_PlarkingLots_ParkingLotID",
                table: "Visitors",
                column: "ParkingLotID",
                principalTable: "PlarkingLots",
                principalColumn: "ParkingLotID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
