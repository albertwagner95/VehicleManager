using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManager.Infrastructure.Migrations
{
    public partial class AddressReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleOwnerRef",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleUserRef",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_VehicleOwnerRef",
                table: "Addresses",
                column: "VehicleOwnerRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_VehicleUserRef",
                table: "Addresses",
                column: "VehicleUserRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_VehicleOwner_VehicleOwnerRef",
                table: "Addresses",
                column: "VehicleOwnerRef",
                principalTable: "VehicleOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_VehicleUser_VehicleUserRef",
                table: "Addresses",
                column: "VehicleUserRef",
                principalTable: "VehicleUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_VehicleOwner_VehicleOwnerRef",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_VehicleUser_VehicleUserRef",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_VehicleOwnerRef",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_VehicleUserRef",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "VehicleOwnerRef",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "VehicleUserRef",
                table: "Addresses");
        }
    }
}
