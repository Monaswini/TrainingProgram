using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShowApp.Migrations
{
    public partial class SeatTypetableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie_Theatre_Info");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropColumn(
                name: "SeatType",
                table: "TheatreSeatInfo");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "SeatTypeID",
                table: "TheatreSeatInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBookedSeat",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalBookingPrice",
                table: "Booking",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "BookedSeatDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedSeatDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookedSeatDetail_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTheatreInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    TheatreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheatreInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieTheatreInfo_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTheatreInfo_Theatre_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheatreSeatInfo_SeatTypeID",
                table: "TheatreSeatInfo",
                column: "SeatTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BookedSeatDetail_BookingId",
                table: "BookedSeatDetail",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheatreInfo_MovieId",
                table: "MovieTheatreInfo",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheatreInfo_TheatreId",
                table: "MovieTheatreInfo",
                column: "TheatreId");

            migrationBuilder.AddForeignKey(
                name: "FK_TheatreSeatInfo_SeatType_SeatTypeID",
                table: "TheatreSeatInfo",
                column: "SeatTypeID",
                principalTable: "SeatType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheatreSeatInfo_SeatType_SeatTypeID",
                table: "TheatreSeatInfo");

            migrationBuilder.DropTable(
                name: "BookedSeatDetail");

            migrationBuilder.DropTable(
                name: "MovieTheatreInfo");

            migrationBuilder.DropTable(
                name: "SeatType");

            migrationBuilder.DropIndex(
                name: "IX_TheatreSeatInfo_SeatTypeID",
                table: "TheatreSeatInfo");

            migrationBuilder.DropColumn(
                name: "SeatTypeID",
                table: "TheatreSeatInfo");

            migrationBuilder.DropColumn(
                name: "NumberOfBookedSeat",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "TotalBookingPrice",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "SeatType",
                table: "TheatreSeatInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "Booking",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Movie_Theatre_Info",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Theatre_Info", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movie_Theatre_Info_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Theatre_Info_Theatre_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatType = table.Column<int>(type: "int", nullable: false),
                    TheatreID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seat_Theatre_TheatreID",
                        column: x => x.TheatreID,
                        principalTable: "Theatre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Theatre_Info_MovieId",
                table: "Movie_Theatre_Info",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Theatre_Info_TheatreId",
                table: "Movie_Theatre_Info",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_TheatreID",
                table: "Seat",
                column: "TheatreID");
        }
    }
}
