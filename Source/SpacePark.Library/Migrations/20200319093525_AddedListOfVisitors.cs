using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Library.Migrations
{
    public partial class AddedListOfVisitors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingLotID",
                table: "Visitors",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
