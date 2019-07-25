using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscordBot.Migrations
{
    public partial class UpdatedGuildModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guilds_Users_OwnerId1",
                table: "Guilds");

            migrationBuilder.DropIndex(
                name: "IX_Guilds_OwnerId1",
                table: "Guilds");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Guilds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId1",
                table: "Guilds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guilds_OwnerId1",
                table: "Guilds",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Guilds_Users_OwnerId1",
                table: "Guilds",
                column: "OwnerId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
