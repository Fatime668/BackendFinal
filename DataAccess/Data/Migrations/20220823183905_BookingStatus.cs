using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Data.Migrations
{
    public partial class BookingStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingStatus_BookingStatusId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingStatus",
                table: "BookingStatus");

            migrationBuilder.RenameTable(
                name: "BookingStatus",
                newName: "BookingStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingStatuses",
                table: "BookingStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingStatuses_BookingStatusId",
                table: "Bookings",
                column: "BookingStatusId",
                principalTable: "BookingStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingStatuses_BookingStatusId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingStatuses",
                table: "BookingStatuses");

            migrationBuilder.RenameTable(
                name: "BookingStatuses",
                newName: "BookingStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingStatus",
                table: "BookingStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingStatus_BookingStatusId",
                table: "Bookings",
                column: "BookingStatusId",
                principalTable: "BookingStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
