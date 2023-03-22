using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assos_Ticket.Server.Migrations
{
    public partial class ForVipCarIdToTheMoon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "RezerveVipCars");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "RezerveVipCars",
                type: "Decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Deposit",
                table: "RezerveVipCars",
                type: "Decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "VipCarId",
                table: "RezerveVipCars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VipCarId",
                table: "RezerveVipCars");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "RezerveVipCars",
                type: "Decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Deposit",
                table: "RezerveVipCars",
                type: "Decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "RezerveVipCars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
