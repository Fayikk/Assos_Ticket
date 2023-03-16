using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class ForExpedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusId",
                table: "Expeditions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaneId",
                table: "Expeditions",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusId",
                table: "Expeditions");

            migrationBuilder.DropColumn(
                name: "PlaneId",
                table: "Expeditions");
        }
    }
}
