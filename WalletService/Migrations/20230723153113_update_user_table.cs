using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletService.Migrations
{
    public partial class update_user_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token1",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "token2",
                table: "users",
                newName: "userToken");

            migrationBuilder.AddColumn<string>(
                name: "SuperSimToken",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "superSimEmailAddress",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuperSimToken",
                table: "users");

            migrationBuilder.DropColumn(
                name: "superSimEmailAddress",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "userToken",
                table: "users",
                newName: "token2");

            migrationBuilder.AddColumn<string>(
                name: "token1",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
