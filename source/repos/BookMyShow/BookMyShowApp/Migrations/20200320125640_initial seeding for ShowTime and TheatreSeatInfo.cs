using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShowApp.Migrations
{
    public partial class initialseedingforShowTimeandTheatreSeatInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheatreSeatInfo_SeatType_SeatTypeID",
                table: "TheatreSeatInfo");

            migrationBuilder.DropColumn(
                name: "ShowTime",
                table: "TheatreSeatInfo");

            migrationBuilder.DropColumn(
                name: "ShowTime",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "SeatTypeID",
                table: "TheatreSeatInfo",
                newName: "SeatTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TheatreSeatInfo_SeatTypeID",
                table: "TheatreSeatInfo",
                newName: "IX_TheatreSeatInfo_SeatTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "SeatTypeId",
                table: "TheatreSeatInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShowTimeID",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShowTime",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(nullable: true),
                    TheatreID = table.Column<int>(nullable: true)
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
                    { 7, 0, 120, 2, 4 }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_TheatreSeatInfo_SeatType_SeatTypeId",
                table: "TheatreSeatInfo",
                column: "SeatTypeId",
                principalTable: "SeatType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_ShowTime_ShowTimeID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_TheatreSeatInfo_SeatType_SeatTypeId",
                table: "TheatreSeatInfo");

            migrationBuilder.DropTable(
                name: "ShowTime");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ShowTimeID",
                table: "Booking");

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

            migrationBuilder.DropColumn(
                name: "ShowTimeID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "SeatTypeId",
                table: "TheatreSeatInfo",
                newName: "SeatTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_TheatreSeatInfo_SeatTypeId",
                table: "TheatreSeatInfo",
                newName: "IX_TheatreSeatInfo_SeatTypeID");

            migrationBuilder.AlterColumn<int>(
                name: "SeatTypeID",
                table: "TheatreSeatInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ShowTime",
                table: "TheatreSeatInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShowTime",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TheatreSeatInfo_SeatType_SeatTypeID",
                table: "TheatreSeatInfo",
                column: "SeatTypeID",
                principalTable: "SeatType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
