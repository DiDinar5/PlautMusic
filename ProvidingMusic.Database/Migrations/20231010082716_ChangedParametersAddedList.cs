using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvidingMusic.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangedParametersAddedList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Performers",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "DateOfFoundation",
                table: "GroupsMusic");

            migrationBuilder.DropColumn(
                name: "WorldRating",
                table: "GroupsMusic");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "WorldRating",
                table: "Songs",
                newName: "SequenceNumber");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "GroupMembers",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GroupMembers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "WorldRating",
                table: "Albums",
                newName: "YearOfRelease");

            migrationBuilder.AlterColumn<int>(
                name: "SongDuration",
                table: "Songs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SequenceNumber",
                table: "Songs",
                newName: "WorldRating");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "GroupMembers",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "GroupMembers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "YearOfRelease",
                table: "Albums",
                newName: "WorldRating");

            migrationBuilder.AlterColumn<double>(
                name: "SongDuration",
                table: "Songs",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Performers",
                table: "Songs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfFoundation",
                table: "GroupsMusic",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WorldRating",
                table: "GroupsMusic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Albums",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
