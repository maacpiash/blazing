﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazing.Migrations
{
    /// <inheritdoc />
    public partial class AddCalendarEventUserConstraint : Migration
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_UserId",
                table: "CalendarEvent",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
