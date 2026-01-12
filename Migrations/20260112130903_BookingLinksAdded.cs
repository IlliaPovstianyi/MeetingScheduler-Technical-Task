using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingSchedulerTechnicalTask.Migrations
{
    /// <inheritdoc />
    public partial class BookingLinksAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_GuestId",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "GuestId",
                table: "Meetings",
                newName: "GuestID");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_GuestId",
                table: "Meetings",
                newName: "IX_Meetings_GuestID");

            migrationBuilder.AlterColumn<Guid>(
                name: "GuestID",
                table: "Meetings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BookingLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingLinks", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Users_GuestID",
                table: "Meetings",
                column: "GuestID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Users_GuestID",
                table: "Meetings");

            migrationBuilder.DropTable(
                name: "BookingLinks");

            migrationBuilder.RenameColumn(
                name: "GuestID",
                table: "Meetings",
                newName: "GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_GuestID",
                table: "Meetings",
                newName: "IX_Meetings_GuestId");

            migrationBuilder.AlterColumn<Guid>(
                name: "GuestId",
                table: "Meetings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Users_GuestId",
                table: "Meetings",
                column: "GuestId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
