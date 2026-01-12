using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingSchedulerTechnicalTask.Migrations
{
    /// <inheritdoc />
    public partial class BookingOwnerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Meetings",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Meetings",
                newName: "DateTime");
        }
    }
}
