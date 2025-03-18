using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class edit_CarBookingProccess_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarBookingProccesses_Locations_LocationId",
                table: "CarBookingProccesses");

            migrationBuilder.DropIndex(
                name: "IX_CarBookingProccesses_LocationId",
                table: "CarBookingProccesses");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "CarBookingProccesses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "CarBookingProccesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarBookingProccesses_LocationId",
                table: "CarBookingProccesses",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarBookingProccesses_Locations_LocationId",
                table: "CarBookingProccesses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
