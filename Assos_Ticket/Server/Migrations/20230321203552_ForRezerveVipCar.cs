using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class ForRezerveVipCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RezerveVipCars",
                columns: table => new
                {
                    RezerveVipCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HowManyDays = table.Column<int>(type: "int", nullable: false),
                    Deposit = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    PickupPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropOfLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezerveVipCars", x => x.RezerveVipCarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezerveVipCars");
        }
    }
}
