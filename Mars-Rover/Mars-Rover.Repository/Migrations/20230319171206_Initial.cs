using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mars_Rover.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rovers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rovers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoverPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoverId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserInput = table.Column<string>(type: "text", nullable: false),
                    ScreenshotIds = table.Column<string>(type: "text", nullable: false),
                    OutputResult = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoverPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoverPositions_Rovers_RoverId",
                        column: x => x.RoverId,
                        principalTable: "Rovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoverPositions_RoverId",
                table: "RoverPositions",
                column: "RoverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoverPositions");

            migrationBuilder.DropTable(
                name: "Rovers");
        }
    }
}
