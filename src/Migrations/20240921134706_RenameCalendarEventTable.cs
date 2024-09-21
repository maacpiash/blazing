using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazing.Migrations
{
    /// <inheritdoc />
    public partial class RenameCalendarEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_UserId",
                table: "CalendarEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarEvent",
                table: "CalendarEvent");

            migrationBuilder.RenameTable(
                name: "CalendarEvent",
                newName: "CalendarEvents");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarEvent_UserId",
                table: "CalendarEvents",
                newName: "IX_CalendarEvents_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CalendarEvents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarEvents",
                table: "CalendarEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvents_AspNetUsers_UserId",
                table: "CalendarEvents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvents_AspNetUsers_UserId",
                table: "CalendarEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarEvents",
                table: "CalendarEvents");

            migrationBuilder.RenameTable(
                name: "CalendarEvents",
                newName: "CalendarEvent");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarEvents_UserId",
                table: "CalendarEvent",
                newName: "IX_CalendarEvent_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CalendarEvent",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarEvent",
                table: "CalendarEvent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_UserId",
                table: "CalendarEvent",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
