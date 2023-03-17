using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class ForCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Customers_CustomerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Expeditions_ExpeditionId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ExpeditionId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ExpeditionId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "SeatNo",
                table: "Tickets",
                newName: "UserId");

            migrationBuilder.CreateTable(
                name: "VipCars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deposit = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfReturn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalKm = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    CarStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VipCars", x => x.CarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VipCars");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "SeatNo");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpeditionId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ExpeditionId",
                table: "Tickets",
                column: "ExpeditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Customers_CustomerId",
                table: "Tickets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Expeditions_ExpeditionId",
                table: "Tickets",
                column: "ExpeditionId",
                principalTable: "Expeditions",
                principalColumn: "ExpeditionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
