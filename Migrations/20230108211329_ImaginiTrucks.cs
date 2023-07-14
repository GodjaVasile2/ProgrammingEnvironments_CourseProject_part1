using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckAplication.Migrations
{
    public partial class ImaginiTrucks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Truck",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Truck");
        }
    }
}
