using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTRS.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admains",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admains", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "buses",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaptinName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfSeets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buses", x => x.BusID);
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    PassengerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.PassengerID);
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusNumber = table.Column<int>(type: "int", nullable: false),
                    TripDis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.TripID);
                    table.ForeignKey(
                        name: "FK_trips_buses_BusID",
                        column: x => x.BusID,
                        principalTable: "buses",
                        principalColumn: "BusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripID = table.Column<int>(type: "int", nullable: false),
                    PassengerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookings_passengers_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "passengers",
                        principalColumn: "PassengerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_trips_TripID",
                        column: x => x.TripID,
                        principalTable: "trips",
                        principalColumn: "TripID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_admains_UserName",
                table: "admains",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_PassengerID",
                table: "bookings",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_TripID",
                table: "bookings",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_buses_CaptinName",
                table: "buses",
                column: "CaptinName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_passengers_UserName",
                table: "passengers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trips_BusID",
                table: "trips",
                column: "BusID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trips_BusNumber",
                table: "trips",
                column: "BusNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admains");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "buses");
        }
    }
}
