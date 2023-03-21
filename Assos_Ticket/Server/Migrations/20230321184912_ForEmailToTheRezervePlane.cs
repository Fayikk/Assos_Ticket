using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class ForEmailToTheRezervePlane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "RezervePlanes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "RezervePlanes");
        }
    }
}
