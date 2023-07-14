using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckAplication.Migrations
{
    public partial class Driver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverID",
                table: "Truck",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Truck_DriverID",
                table: "Truck",
                column: "DriverID");

            migrationBuilder.AddForeignKey(
                name: "FK_Truck_Driver_DriverID",
                table: "Truck",
                column: "DriverID",
                principalTable: "Driver",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Truck_Driver_DriverID",
                table: "Truck");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_Truck_DriverID",
                table: "Truck");

            migrationBuilder.DropColumn(
                name: "DriverID",
                table: "Truck");
        }
    }
}
