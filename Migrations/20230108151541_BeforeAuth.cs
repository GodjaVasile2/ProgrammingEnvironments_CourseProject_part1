using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckAplication.Migrations
{
    public partial class BeforeAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    TruckID = table.Column<int>(type: "int", nullable: true),
                    RentedDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Request_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Request_Truck_TruckID",
                        column: x => x.TruckID,
                        principalTable: "Truck",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_ClientID",
                table: "Request",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_TruckID",
                table: "Request",
                column: "TruckID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
