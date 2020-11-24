using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManager.Infrastructure.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityType",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Community",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voivodeship",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CityType",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Community",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Voivodeship",
                table: "Addresses");
        }
    }
}
