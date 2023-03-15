using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expeditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedititonDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Begining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expeditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Busses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    ExpeditionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Busses_Expeditions_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expeditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    ExpeditionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planes_Expeditions_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expeditions",
                        principalColumn: "Id",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Busses");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Expeditions");
        }
    }
}
