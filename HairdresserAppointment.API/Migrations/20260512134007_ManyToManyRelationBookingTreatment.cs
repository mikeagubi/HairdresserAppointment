using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdresserAppointment.API.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationBookingTreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Bookings_BookingId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_BookingId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Treatments");

            migrationBuilder.CreateTable(
                name: "BookingTreatment",
                columns: table => new
                {
                    BookingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreatmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTreatment", x => new { x.BookingsId, x.TreatmentsId });
                    table.ForeignKey(
                        name: "FK_BookingTreatment_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingTreatment_Treatments_TreatmentsId",
                        column: x => x.TreatmentsId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingTreatment_TreatmentsId",
                table: "BookingTreatment",
                column: "TreatmentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTreatment");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "Treatments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_BookingId",
                table: "Treatments",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Bookings_BookingId",
                table: "Treatments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
