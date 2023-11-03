using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Web.Migrations
{
    public partial class Addticketmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    iDepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vDepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.iDepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    iRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vRoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.iRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    iUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dRegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dRefreshDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    iDepartmentId = table.Column<int>(type: "int", nullable: false),
                    iRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.iUserId);
                    table.ForeignKey(
                        name: "FK_Users_Departments_iDepartmentId",
                        column: x => x.iDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "iDepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_iRoleId",
                        column: x => x.iRoleId,
                        principalTable: "Roles",
                        principalColumn: "iRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_iDepartmentId",
                table: "Users",
                column: "iDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_iRoleId",
                table: "Users",
                column: "iRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
