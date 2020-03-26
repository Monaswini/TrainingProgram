using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShow.Application.Migrations
{
    public partial class secondmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TheatreSeatInfo",
                columns: new[] { "ID", "NumberOfSeats", "Price", "SeatTypeId", "TheatreId" },
                values: new object[,]
                {
                    { 1, 20, 40, 1, 1 },
                    { 2, 30, 60, 2, 1 },
                    { 3, 50, 50, 1, 2 },
                    { 4, 50, 70, 2, 2 },
                    { 5, 60, 45, 1, 3 },
                    { 6, 70, 75, 2, 3 },
                    { 7, 100, 120, 2, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TheatreSeatInfo",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TheatreSeatInfo",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TheatreSeatInfo",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TheatreSeatInfo",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TheatreSeatInfo",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TheatreSeatInfo",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TheatreSeatInfo",
                keyColumn: "ID",
                keyValue: 7);
        }
    }
}
