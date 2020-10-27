using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManager.Infrastructure.Migrations
{
    public partial class InitialCTesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarHistory_Vehicles_VehicleId",
                table: "CarHistory");

            migrationBuilder.DropTable(
                name: "VehicleCarHistory");

            migrationBuilder.DropIndex(
                name: "IX_CarHistory_VehicleId",
                table: "CarHistory");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "KindOfFuelId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "CarHistory");

            migrationBuilder.AddColumn<int>(
                name: "CarHistoryId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KindOfFuelRef",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleBrandRef",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleModelRef",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleOwnerId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VehicleOwnerId1",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleServiceId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeRef",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KindOfFuel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfFuel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ServiceDescribe = table.Column<string>(maxLength: 500, nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    NextService = table.Column<int>(nullable: false),
                    ServiceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    EnginePower = table.Column<int>(nullable: false),
                    EngineCapacity = table.Column<int>(nullable: false),
                    PermissibleGrossWeight = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    OwnWeight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CarHistoryId",
                table: "Vehicles",
                column: "CarHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_KindOfFuelRef",
                table: "Vehicles",
                column: "KindOfFuelRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleBrandRef",
                table: "Vehicles",
                column: "VehicleBrandRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelRef",
                table: "Vehicles",
                column: "VehicleModelRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleOwnerId1",
                table: "Vehicles",
                column: "VehicleOwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleServiceId",
                table: "Vehicles",
                column: "VehicleServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeRef",
                table: "Vehicles",
                column: "VehicleTypeRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_CarHistory_CarHistoryId",
                table: "Vehicles",
                column: "CarHistoryId",
                principalTable: "CarHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_KindOfFuel_KindOfFuelRef",
                table: "Vehicles",
                column: "KindOfFuelRef",
                principalTable: "KindOfFuel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleBrand_VehicleBrandRef",
                table: "Vehicles",
                column: "VehicleBrandRef",
                principalTable: "VehicleBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModel_VehicleModelRef",
                table: "Vehicles",
                column: "VehicleModelRef",
                principalTable: "VehicleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_VehicleOwnerId1",
                table: "Vehicles",
                column: "VehicleOwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleService_VehicleServiceId",
                table: "Vehicles",
                column: "VehicleServiceId",
                principalTable: "VehicleService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleType_VehicleTypeRef",
                table: "Vehicles",
                column: "VehicleTypeRef",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_CarHistory_CarHistoryId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_KindOfFuel_KindOfFuelRef",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleBrand_VehicleBrandRef",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModel_VehicleModelRef",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_VehicleOwnerId1",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleService_VehicleServiceId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleType_VehicleTypeRef",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "KindOfFuel");

            migrationBuilder.DropTable(
                name: "VehicleBrand");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleService");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CarHistoryId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_KindOfFuelRef",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleBrandRef",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleModelRef",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleOwnerId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleServiceId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleTypeRef",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CarHistoryId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "KindOfFuelRef",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleBrandRef",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleModelRef",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleOwnerId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleOwnerId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleServiceId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleTypeRef",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KindOfFuelId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "CarHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VehicleCarHistory",
                columns: table => new
                {
                    CarHistoryId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCarHistory", x => new { x.CarHistoryId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_VehicleCarHistory_CarHistory_CarHistoryId",
                        column: x => x.CarHistoryId,
                        principalTable: "CarHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleCarHistory_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarHistory_VehicleId",
                table: "CarHistory",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCarHistory_VehicleId",
                table: "VehicleCarHistory",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarHistory_Vehicles_VehicleId",
                table: "CarHistory",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
