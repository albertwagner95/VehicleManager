using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManager.Infrastructure.Migrations
{
    public partial class newrelationbetweenuserandcarhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "CarHistories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarHistories_ApplicationUserID",
                table: "CarHistories",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHistories_AspNetUsers_ApplicationUserID",
                table: "CarHistories",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHistories_AspNetUsers_ApplicationUserID",
                table: "CarHistories");

            migrationBuilder.DropIndex(
                name: "IX_CarHistories_ApplicationUserID",
                table: "CarHistories");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "CarHistories");
        }
    }
}
