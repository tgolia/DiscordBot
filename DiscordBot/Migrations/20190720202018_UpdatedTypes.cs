using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscordBot.Migrations
{
    public partial class UpdatedTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscriminatorValue",
                table: "Guilds");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Guilds");

            migrationBuilder.AlterColumn<decimal>(
                name: "OwnerId",
                table: "Guilds",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "GuildId",
                table: "Guilds",
                nullable: false,
                oldClrType: typeof(long));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "Guilds",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<long>(
                name: "GuildId",
                table: "Guilds",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "DiscriminatorValue",
                table: "Guilds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Guilds",
                nullable: true);
        }
    }
}
