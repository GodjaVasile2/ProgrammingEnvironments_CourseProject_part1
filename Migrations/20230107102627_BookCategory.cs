using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckAplication.Migrations
{
    public partial class TruckCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TruckCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TruckCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TruckCategory_Truck_TruckID",
                        column: x => x.TruckID,
                        principalTable: "Truck",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckCategory_CategoryID",
                table: "TruckCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TruckCategory_TruckID",
                table: "TruckCategory",
                column: "TruckID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
