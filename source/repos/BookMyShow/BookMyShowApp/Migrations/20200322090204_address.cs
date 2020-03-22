using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyShowApp.Migrations
{
    public partial class address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Theatre_TheatreId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_TheatreId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "TheatreId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Address",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Address",
                newName: "city");

            migrationBuilder.AddColumn<int>(
                name: "TheatreId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Address_TheatreId",
                table: "Address",
                column: "TheatreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Theatre_TheatreId",
                table: "Address",
                column: "TheatreId",
                principalTable: "Theatre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
