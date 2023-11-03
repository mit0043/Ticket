using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_Web.Migrations
{
    public partial class AddTicketBookModal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketBooks",
                columns: table => new
                {
                    iBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iUserId = table.Column<int>(type: "int", nullable: false),
                    iTicketId = table.Column<int>(type: "int", nullable: false),
                    iCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketBooks", x => x.iBookingId);
                    table.ForeignKey(
                        name: "FK_TicketBooks_Tickets_iTicketId",
                        column: x => x.iTicketId,
                        principalTable: "Tickets",
                        principalColumn: "iTicketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketBooks_Users_iUserId",
                        column: x => x.iUserId,
                        principalTable: "Users",
                        principalColumn: "iUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketBooks_iTicketId",
                table: "TicketBooks",
                column: "iTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBooks_iUserId",
                table: "TicketBooks",
                column: "iUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketBooks");
        }
    }
}
