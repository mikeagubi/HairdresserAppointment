using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdresserAppointment.API.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingNumberAndSoftDeleteToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Bookings");
        }
    }
}
