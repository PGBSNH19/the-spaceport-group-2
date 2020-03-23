using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Library.Migrations
{
    public partial class changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_VisitorParking_VisitorParkingID",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_VisitorParkingID",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "VisitorParkingID",
                table: "Visitors");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorParking_VisitorID",
                table: "VisitorParking",
                column: "VisitorID");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorParking_Visitors_VisitorID",
                table: "VisitorParking",
                column: "VisitorID",
                principalTable: "Visitors",
                principalColumn: "VisitorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitorParking_Visitors_VisitorID",
                table: "VisitorParking");

            migrationBuilder.DropIndex(
                name: "IX_VisitorParking_VisitorID",
                table: "VisitorParking");

            migrationBuilder.AddColumn<int>(
                name: "VisitorParkingID",
                table: "Visitors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_VisitorParkingID",
                table: "Visitors",
                column: "VisitorParkingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_VisitorParking_VisitorParkingID",
                table: "Visitors",
                column: "VisitorParkingID",
                principalTable: "VisitorParking",
                principalColumn: "VisitorParkingID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
