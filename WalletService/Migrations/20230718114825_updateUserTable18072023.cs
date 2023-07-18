using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletService.Migrations
{
    public partial class updateUserTable18072023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "logins",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "logins");
        }
    }
}
