using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TikTakToeGame.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayersPropToField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Players",
                table: "Fields",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Players",
                table: "Fields");
        }
    }
}
