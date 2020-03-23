using Microsoft.EntityFrameworkCore.Migrations;



namespace SpacePark.Library.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlarkingLots",
                table: "PlarkingLots");

            migrationBuilder.DropColumn(
                name: "ParkingLotID",
                table: "Visitors");

            migrationBuilder.RenameTable(
                name: "PlarkingLots",
                newName: "ParkingLots");

            migrationBuilder.RenameIndex(
                name: "IX_PlarkingLots_SpacePortID",
                table: "ParkingLots",
                newName: "IX_ParkingLots_SpacePortID");

            migrationBuilder.AddColumn<int>(
                name: "VisitorParkingID",
                table: "Visitors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParkingLotNO",
                table: "ParkingLots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingLots",
                table: "ParkingLots",
                column: "ParkingLotID");

            migrationBuilder.CreateTable(
                name: "VisitorParking",
                columns: table => new
                {
                    VisitorParkingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLotID = table.Column<int>(nullable: false),
                    VisitorID = table.Column<int>(nullable: false),
                    ParkingNO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorParking", x => x.VisitorParkingID);
                    table.ForeignKey(
                        name: "FK_VisitorParking_ParkingLots_ParkingLotID",
                        column: x => x.ParkingLotID,
                        principalTable: "ParkingLots",
                        principalColumn: "ParkingLotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_VisitorParkingID",
                table: "Visitors",
                column: "VisitorParkingID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorParking_ParkingLotID",
                table: "VisitorParking",
                column: "ParkingLotID");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots",
                column: "SpacePortID",
                principalTable: "SpacePorts",
                principalColumn: "SpacePortID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_VisitorParking_VisitorParkingID",
                table: "Visitors",
                column: "VisitorParkingID",
                principalTable: "VisitorParking",
                principalColumn: "VisitorParkingID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_SpacePorts_SpacePortID",
                table: "ParkingLots");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_VisitorParking_VisitorParkingID",
                table: "Visitors");

            migrationBuilder.DropTable(
                name: "VisitorParking");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_VisitorParkingID",
                table: "Visitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingLots",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "VisitorParkingID",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "ParkingLotNO",
                table: "ParkingLots");

            migrationBuilder.RenameTable(
                name: "ParkingLots",
                newName: "PlarkingLots");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingLots_SpacePortID",
                table: "PlarkingLots",
                newName: "IX_PlarkingLots_SpacePortID");

            migrationBuilder.AddColumn<int>(
                name: "ParkingLotID",
                table: "Visitors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlarkingLots",
                table: "PlarkingLots",
                column: "ParkingLotID");

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
    }
}
