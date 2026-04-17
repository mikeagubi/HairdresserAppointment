using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdresserAppointment.API.Migrations
{
    /// <inheritdoc />
    public partial class AddHairdresserIdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HairdresserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HairdresserName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HairdresserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HairdresserName",
                table: "AspNetUsers");
        }
    }
}
