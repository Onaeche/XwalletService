using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletService.Migrations
{
    public partial class addedEmailandSMSNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emailNotifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messageSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tryNo = table.Column<int>(type: "int", nullable: false),
                    responseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    responseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailNotifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SMSNotifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messageSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tryNo = table.Column<int>(type: "int", nullable: false),
                    responseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    responseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSNotifications", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emailNotifications");

            migrationBuilder.DropTable(
                name: "SMSNotifications");
        }
    }
}
