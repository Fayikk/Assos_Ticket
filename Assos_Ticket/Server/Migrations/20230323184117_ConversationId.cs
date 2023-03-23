using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class ConversationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "RezerveVipCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "RezervePlanes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "OrderBusses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "RezerveVipCars");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "RezervePlanes");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "OrderBusses");
        }
    }
}
