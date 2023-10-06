using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvidingMusic.Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteGroupMem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "GroupMembers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "GroupMembers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeath",
                table: "GroupMembers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "GroupMembers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "GroupMembers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
