using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationGrpc.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_games",
                table: "games");

            migrationBuilder.RenameTable(
                name: "games",
                newName: "users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "games");

            migrationBuilder.AddPrimaryKey(
                name: "PK_games",
                table: "games",
                column: "Id");
        }
    }
}
