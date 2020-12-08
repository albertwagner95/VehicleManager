using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManager.Infrastructure.Migrations
{
    public partial class newfieldinRefuelinBurningFuelPerOneHundredKilometers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BurningFuelPerOneHundredKilometers",
                table: "Refulings",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BurningFuelPerOneHundredKilometers",
                table: "Refulings");
        }
    }
}
