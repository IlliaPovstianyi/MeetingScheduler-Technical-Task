using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingSchedulerTechnicalTask.Migrations
{
    /// <inheritdoc />
    public partial class BookingLinksUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "BookingLinks");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "BookingLinks",
                newName: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_BookingLinks_OwnerId",
                table: "BookingLinks",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingLinks_Users_OwnerId",
                table: "BookingLinks",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingLinks_Users_OwnerId",
                table: "BookingLinks");

            migrationBuilder.DropIndex(
                name: "IX_BookingLinks_OwnerId",
                table: "BookingLinks");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "BookingLinks",
                newName: "Date");

            migrationBuilder.AddColumn<Guid>(
                name: "Owner",
                table: "BookingLinks",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
