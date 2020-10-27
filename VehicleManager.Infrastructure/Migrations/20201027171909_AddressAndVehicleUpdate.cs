using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleManager.Infrastructure.Migrations
{
    public partial class AddressAndVehicleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_VehicleOwnerId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleOwnerId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleOwnerId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Event",
                table: "CarHistory");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "VehicleType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "VehicleType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "VehicleType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "VehicleType",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceDescribe",
                table: "VehicleService",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "VehicleService",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "VehicleService",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "VehicleService",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "VehicleService",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleUserId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "VehicleModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "VehicleModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "VehicleModel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "VehicleModel",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleBrand",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "VehicleBrand",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "VehicleBrand",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "VehicleBrand",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "VehicleBrand",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "KindOfFuel",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "KindOfFuel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "KindOfFuel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "KindOfFuel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "KindOfFuel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "CarHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "CarHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "CarHistory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "CarHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CarHistory",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "AddressTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "AddressTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "AddressTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "AddressTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityRef",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryRef",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Addresses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCodeRef",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleOwner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    Pesel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    Pesel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZipCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCode", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleOwnerId",
                table: "Vehicles",
                column: "VehicleOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleUserId",
                table: "Vehicles",
                column: "VehicleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityRef",
                table: "Addresses",
                column: "CityRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryRef",
                table: "Addresses",
                column: "CountryRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ZipCodeRef",
                table: "Addresses",
                column: "ZipCodeRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_City_CityRef",
                table: "Addresses",
                column: "CityRef",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Country_CountryRef",
                table: "Addresses",
                column: "CountryRef",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_ZipCode_ZipCodeRef",
                table: "Addresses",
                column: "ZipCodeRef",
                principalTable: "ZipCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleOwner_VehicleOwnerId",
                table: "Vehicles",
                column: "VehicleOwnerId",
                principalTable: "VehicleOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleUser_VehicleUserId",
                table: "Vehicles",
                column: "VehicleUserId",
                principalTable: "VehicleUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_City_CityRef",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Country_CountryRef",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_ZipCode_ZipCodeRef",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleOwner_VehicleOwnerId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleUser_VehicleUserId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "VehicleOwner");

            migrationBuilder.DropTable(
                name: "VehicleUser");

            migrationBuilder.DropTable(
                name: "ZipCode");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleOwnerId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleUserId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CityRef",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CountryRef",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ZipCodeRef",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "VehicleType");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "VehicleType");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "VehicleType");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "VehicleType");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "VehicleService");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "VehicleService");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "VehicleService");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "VehicleService");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleUserId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "VehicleBrand");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "VehicleBrand");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "VehicleBrand");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "VehicleBrand");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "KindOfFuel");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "KindOfFuel");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "KindOfFuel");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "KindOfFuel");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CarHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "CarHistory");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "CarHistory");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "CarHistory");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CarHistory");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AddressTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AddressTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "AddressTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "AddressTypes");

            migrationBuilder.DropColumn(
                name: "CityRef",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CountryRef",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ZipCodeRef",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceDescribe",
                table: "VehicleService",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleOwnerId1",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleBrand",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "KindOfFuel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Event",
                table: "CarHistory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleOwnerId1",
                table: "Vehicles",
                column: "VehicleOwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_VehicleOwnerId1",
                table: "Vehicles",
                column: "VehicleOwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
