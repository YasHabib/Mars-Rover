using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mars_Rover.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationToRoverPositionTableRemovedScreenshotURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenshotIds",
                table: "RoverPositions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScreenshotIds",
                table: "RoverPositions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
