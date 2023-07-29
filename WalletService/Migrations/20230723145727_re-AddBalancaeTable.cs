using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletService.Migrations
{
    public partial class reAddBalancaeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "balance",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    serviceProvider = table.Column<int>(type: "int", nullable: false),
                    walletAccount = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    airtimeBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_balance", x => new { x.userId, x.walletAccount, x.serviceProvider });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "balance");
        }
    }
}
