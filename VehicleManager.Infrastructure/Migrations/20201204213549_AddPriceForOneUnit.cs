using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManager.Infrastructure.Migrations
{
    public partial class AddPriceForOneUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceForOneUnit",
                table: "Refulings",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceForOneUnit",
                table: "Refulings");
        }
    }
}
