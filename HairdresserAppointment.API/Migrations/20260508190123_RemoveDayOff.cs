using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdresserAppointment.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDayOff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayOffs");

            migrationBuilder.DropColumn(
                name: "HairdresserName",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HairdresserName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DayOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairdresserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayOffs_Hairdressers_HairdresserId",
                        column: x => x.HairdresserId,
                        principalTable: "Hairdressers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayOffs_HairdresserId",
                table: "DayOffs",
                column: "HairdresserId");
        }
    }
}
