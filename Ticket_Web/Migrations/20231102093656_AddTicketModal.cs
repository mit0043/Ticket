using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Web.Migrations
{
    public partial class AddTicketModal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    iTicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vTicketName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iCount = table.Column<int>(type: "int", nullable: false),
                    vImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.iTicketId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
