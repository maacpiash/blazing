using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazing.Migrations
{
    /// <inheritdoc />
    public partial class AddCalendarEventDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_UserId",
                table: "CalendarEvent");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CalendarEvent",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CalendarEvent",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CalendarEvent",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "CalendarEvent",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CalendarEvent",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_UserId",
                table: "CalendarEvent",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_UserId",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CalendarEvent");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CalendarEvent",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
