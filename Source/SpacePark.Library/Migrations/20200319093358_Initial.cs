using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark.Library.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PlarkingLots",
                columns: table => new
                {
                    ParkingLotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLotOccupied = table.Column<bool>(nullable: false),
                    VisitorID = table.Column<int>(nullable: false),
                    SpacePortID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlarkingLots", x => x.ParkingLotID);
                    table.ForeignKey(
                        name: "FK_PlarkingLots_SpacePorts_SpacePortID",
                        column: x => x.SpacePortID,
                        principalTable: "SpacePorts",
                        principalColumn: "SpacePortID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlarkingLots_SpacePortID",
                table: "PlarkingLots",
                column: "SpacePortID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlarkingLots");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "SpacePorts");
        }
    }
}
