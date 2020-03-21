using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShowApp.Migrations
{
    public partial class ShowTimeenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_ShowTime_ShowTimeID",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "ShowTime");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ShowTimeID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ShowTimeID",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "ShowTime",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TheatreSeatInfo",
                keyColumn: "ID",
                keyValue: 7,
                column: "NumberOfSeats",
                value: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowTime",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "ShowTimeID",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShowTime",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheatreID = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTime", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShowTime_Theatre_TheatreID",
                        column: x => x.TheatreID,
                        principalTable: "Theatre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ShowTime",
                columns: new[] { "ID", "TheatreID", "Time" },
                values: new object[,]
                {
                    { 1, null, "morning" },
                    { 2, null, "afternoon" },
                    { 3, null, "evening" },
                    { 4, null, "night" }
                });

            migrationBuilder.UpdateData(
                table: "TheatreSeatInfo",
                keyColumn: "ID",
                keyValue: 7,
                column: "NumberOfSeats",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ShowTimeID",
                table: "Booking",
                column: "ShowTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_TheatreID",
                table: "ShowTime",
                column: "TheatreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_ShowTime_ShowTimeID",
                table: "Booking",
                column: "ShowTimeID",
                principalTable: "ShowTime",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
