using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class RevizationForCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DropOfLocation",
                table: "VipCars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropOfLocation",
                table: "VipCars");
        }
    }
}
