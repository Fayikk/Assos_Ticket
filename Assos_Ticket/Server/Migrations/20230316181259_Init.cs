using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Expeditions",
                columns: table => new
                {
                    ExpeditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expeditions", x => x.ExpeditionId);
                });

            migrationBuilder.CreateTable(
                name: "Busses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacitiy = table.Column<int>(type: "int", nullable: false),
                    BeginingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinisingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Begining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ExpeditionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busses", x => x.BusId);
                    table.ForeignKey(
                        name: "FK_Busses_Expeditions_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expeditions",
                        principalColumn: "ExpeditionId");
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    BeginingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinisingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Begining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ExpeditionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.PlaneId);
                    table.ForeignKey(
                        name: "FK_Planes_Expeditions_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expeditions",
                        principalColumn: "ExpeditionId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoughtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpeditionId = table.Column<int>(type: "int", nullable: false),
                    SeatNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Expeditions_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expeditions",
                        principalColumn: "ExpeditionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Busses_ExpeditionId",
                table: "Busses",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_ExpeditionId",
                table: "Planes",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ExpeditionId",
                table: "Tickets",
                column: "ExpeditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Busses");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Expeditions");
        }
    }
}
