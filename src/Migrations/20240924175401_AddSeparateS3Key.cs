using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazing.Migrations
{
    /// <inheritdoc />
    public partial class AddSeparateS3Key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "S3Key",
                table: "MusicFiles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "S3Key",
                table: "MusicFiles");
        }
    }
}
