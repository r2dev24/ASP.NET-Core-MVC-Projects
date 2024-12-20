using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Account_ID);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Admin_ID);
                    table.ForeignKey(
                        name: "FK_Admins_Accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Post_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Post_ID);
                    table.ForeignKey(
                        name: "FK_Notifications_Accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personal_Info",
                columns: table => new
                {
                    Personal_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personal_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personal_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personal_Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal_Info", x => x.Personal_Id);
                    table.ForeignKey(
                        name: "FK_Personal_Info_Accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "Accounts",
                        principalColumn: "Account_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Account_ID",
                table: "Admins",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Account_ID",
                table: "Notifications",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Info_Account_ID",
                table: "Personal_Info",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Account_ID",
                table: "Users",
                column: "Account_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Personal_Info");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
