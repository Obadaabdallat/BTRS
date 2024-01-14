using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTRS.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trips_buses_BusID",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_BusID",
                table: "trips");

            migrationBuilder.AlterColumn<int>(
                name: "BusID",
                table: "trips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_trips_BusID",
                table: "trips",
                column: "BusID",
                unique: true,
                filter: "[BusID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_trips_buses_BusID",
                table: "trips",
                column: "BusID",
                principalTable: "buses",
                principalColumn: "BusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trips_buses_BusID",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_BusID",
                table: "trips");

            migrationBuilder.AlterColumn<int>(
                name: "BusID",
                table: "trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_trips_BusID",
                table: "trips",
                column: "BusID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_buses_BusID",
                table: "trips",
                column: "BusID",
                principalTable: "buses",
                principalColumn: "BusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
