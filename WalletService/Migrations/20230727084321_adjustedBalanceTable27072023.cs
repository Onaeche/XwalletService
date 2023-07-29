using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletService.Migrations
{
    public partial class adjustedBalanceTable27072023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_balance",
                table: "balance");

            migrationBuilder.RenameTable(
                name: "balance",
                newName: "balanceInfo");

            migrationBuilder.AddColumn<string>(
                name: "telcoWalletAccount",
                table: "balanceInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_balanceInfo",
                table: "balanceInfo",
                columns: new[] { "userId", "walletAccount", "serviceProvider" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_balanceInfo",
                table: "balanceInfo");

            migrationBuilder.DropColumn(
                name: "telcoWalletAccount",
                table: "balanceInfo");

            migrationBuilder.RenameTable(
                name: "balanceInfo",
                newName: "balance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_balance",
                table: "balance",
                columns: new[] { "userId", "walletAccount", "serviceProvider" });
        }
    }
}
