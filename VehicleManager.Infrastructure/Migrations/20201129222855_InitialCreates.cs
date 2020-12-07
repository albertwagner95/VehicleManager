using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManager.Infrastructure.Migrations
{
    public partial class InitialCreates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Refulings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Refulings");
        }
    }
}
