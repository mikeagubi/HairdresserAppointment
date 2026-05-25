using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdresserAppointment.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedIconToTratmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Treatments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Treatments");
        }
    }
}
