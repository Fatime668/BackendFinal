using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class createTabless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomPictures_Pictures_PictureId",
                table: "RoomPictures");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_RoomPictures_PictureId",
                table: "RoomPictures");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "RoomPictures");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "RoomPictures",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "RoomPictures",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "RoomPictures");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "RoomPictures");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "RoomPictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomPictures_PictureId",
                table: "RoomPictures",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPictures_Pictures_PictureId",
                table: "RoomPictures",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
