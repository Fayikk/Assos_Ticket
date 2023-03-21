using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class StringForTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TravelTime",
                table: "RezervePlanes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TravelTime",
                table: "RezervePlanes",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
