using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvidingMusic.Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedParametersInSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "GroupsMusic",
                newName: "WorldRating");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Albums",
                newName: "WorldRating");

            migrationBuilder.AddColumn<string>(
                name: "Performers",
                table: "Songs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SongDuration",
                table: "Songs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "WorldRating",
                table: "Songs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfFoundation",
                table: "GroupsMusic",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Awards",
                table: "Albums",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Performers",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "SongDuration",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "WorldRating",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "DateOfFoundation",
                table: "GroupsMusic");

            migrationBuilder.DropColumn(
                name: "Awards",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "WorldRating",
                table: "GroupsMusic",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "WorldRating",
                table: "Albums",
                newName: "Rating");
        }
    }
}
