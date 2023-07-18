using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletService.Migrations
{
    public partial class additionOfTransactionLog_15072023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLockedOut",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "users");

            migrationBuilder.DropColumn(
                name: "lastLogOutDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "lastLoginDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsLockedOut",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "password",
                table: "customers");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lastLogOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: true),
                    IsLockedOut = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transactionLogs",
                columns: table => new
                {
                    transId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    requestid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromAcctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToAcctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    walletAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    referenceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    responseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    responseMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    naration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    balanceBeforeTransaction = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    balanceAfterTransaction = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    transactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paymentResponseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentResponseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false),
                    approvedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    approvedBy = table.Column<int>(type: "int", nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactionLogs", x => x.transId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.DropTable(
                name: "transactionLogs");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "customers");

            migrationBuilder.AddColumn<bool>(
                name: "IsLockedOut",
                table: "users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastLogOutDate",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastLoginDate",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLockedOut",
                table: "customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "customers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
