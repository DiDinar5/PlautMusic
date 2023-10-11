using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvidingMusic.Database.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupMusicId",
                table: "GroupMembers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupMusicId",
                table: "Albums",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupMusicId",
                table: "GroupMembers",
                column: "GroupMusicId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GroupMusicId",
                table: "Albums",
                column: "GroupMusicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_GroupsMusic_GroupMusicId",
                table: "Albums",
                column: "GroupMusicId",
                principalTable: "GroupsMusic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_GroupsMusic_GroupMusicId",
                table: "GroupMembers",
                column: "GroupMusicId",
                principalTable: "GroupsMusic",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_GroupsMusic_GroupMusicId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_GroupsMusic_GroupMusicId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_GroupMembers_GroupMusicId",
                table: "GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_Albums_GroupMusicId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "GroupMusicId",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "GroupMusicId",
                table: "Albums");
        }
    }
}
