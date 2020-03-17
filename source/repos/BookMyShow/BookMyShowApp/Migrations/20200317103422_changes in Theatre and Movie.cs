using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShowApp.Migrations
{
    public partial class changesinTheatreandMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theatre_Movie_MovieID",
                table: "Theatre");

            migrationBuilder.DropIndex(
                name: "IX_Theatre_MovieID",
                table: "Theatre");

            migrationBuilder.DropIndex(
                name: "IX_Address_TheatreId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Theatre");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "Movie");

            migrationBuilder.CreateTable(
                name: "Movie_Theatre_Info",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    TheatreId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Address_TheatreId",
                table: "Address",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Theatre_Info_MovieId",
                table: "Movie_Theatre_Info",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Theatre_Info_TheatreId",
                table: "Movie_Theatre_Info",
                column: "TheatreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie_Theatre_Info");

            migrationBuilder.DropIndex(
                name: "IX_Address_TheatreId",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Theatre",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Theatre_MovieID",
                table: "Theatre",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_TheatreId",
                table: "Address",
                column: "TheatreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Theatre_Movie_MovieID",
                table: "Theatre",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
