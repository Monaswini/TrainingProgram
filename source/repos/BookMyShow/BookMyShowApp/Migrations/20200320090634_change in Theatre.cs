using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShowApp.Migrations
{
    public partial class changeinTheatre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheatreSeatInfo_Theatre_TheatreID",
                table: "TheatreSeatInfo");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "TheatreSeatInfo");

            migrationBuilder.RenameColumn(
                name: "TheatreID",
                table: "TheatreSeatInfo",
                newName: "TheatreId");

            migrationBuilder.RenameIndex(
                name: "IX_TheatreSeatInfo_TheatreID",
                table: "TheatreSeatInfo",
                newName: "IX_TheatreSeatInfo_TheatreId");

            migrationBuilder.AlterColumn<int>(
                name: "TheatreId",
                table: "TheatreSeatInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TheatreSeatInfo_Theatre_TheatreId",
                table: "TheatreSeatInfo",
                column: "TheatreId",
                principalTable: "Theatre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheatreSeatInfo_Theatre_TheatreId",
                table: "TheatreSeatInfo");

            migrationBuilder.RenameColumn(
                name: "TheatreId",
                table: "TheatreSeatInfo",
                newName: "TheatreID");

            migrationBuilder.RenameIndex(
                name: "IX_TheatreSeatInfo_TheatreId",
                table: "TheatreSeatInfo",
                newName: "IX_TheatreSeatInfo_TheatreID");

            migrationBuilder.AlterColumn<int>(
                name: "TheatreID",
                table: "TheatreSeatInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                table: "TheatreSeatInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TheatreSeatInfo_Theatre_TheatreID",
                table: "TheatreSeatInfo",
                column: "TheatreID",
                principalTable: "Theatre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
