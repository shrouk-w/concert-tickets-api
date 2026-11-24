using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolosB.Migrations
{
    /// <inheritdoc />
    public partial class addeddbsets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchased_Ticket_Customer_CustomerId",
                table: "Purchased_Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchased_Ticket_Ticket_Concert_TicketConcertId",
                table: "Purchased_Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Concert_Concert_ConcertId",
                table: "Ticket_Concert");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Concert_Ticket_TicketId",
                table: "Ticket_Concert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket_Concert",
                table: "Ticket_Concert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchased_Ticket",
                table: "Purchased_Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concert",
                table: "Concert");

            migrationBuilder.RenameTable(
                name: "Ticket_Concert",
                newName: "Ticket_Concerts");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "Purchased_Ticket",
                newName: "Purchased_Tickets");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Concert",
                newName: "Concerts");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Concert_TicketId",
                table: "Ticket_Concerts",
                newName: "IX_Ticket_Concerts_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Concert_ConcertId",
                table: "Ticket_Concerts",
                newName: "IX_Ticket_Concerts_ConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchased_Ticket_TicketConcertId",
                table: "Purchased_Tickets",
                newName: "IX_Purchased_Tickets_TicketConcertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket_Concerts",
                table: "Ticket_Concerts",
                column: "TicketConcertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchased_Tickets",
                table: "Purchased_Tickets",
                columns: new[] { "CustomerId", "TicketConcertId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concerts",
                table: "Concerts",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchased_Tickets_Customers_CustomerId",
                table: "Purchased_Tickets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchased_Tickets_Ticket_Concerts_TicketConcertId",
                table: "Purchased_Tickets",
                column: "TicketConcertId",
                principalTable: "Ticket_Concerts",
                principalColumn: "TicketConcertId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Concerts_Concerts_ConcertId",
                table: "Ticket_Concerts",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "ConcertId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Concerts_Tickets_TicketId",
                table: "Ticket_Concerts",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchased_Tickets_Customers_CustomerId",
                table: "Purchased_Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchased_Tickets_Ticket_Concerts_TicketConcertId",
                table: "Purchased_Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Concerts_Concerts_ConcertId",
                table: "Ticket_Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Concerts_Tickets_TicketId",
                table: "Ticket_Concerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket_Concerts",
                table: "Ticket_Concerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchased_Tickets",
                table: "Purchased_Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concerts",
                table: "Concerts");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket_Concerts",
                newName: "Ticket_Concert");

            migrationBuilder.RenameTable(
                name: "Purchased_Tickets",
                newName: "Purchased_Ticket");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Concerts",
                newName: "Concert");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Concerts_TicketId",
                table: "Ticket_Concert",
                newName: "IX_Ticket_Concert_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Concerts_ConcertId",
                table: "Ticket_Concert",
                newName: "IX_Ticket_Concert_ConcertId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchased_Tickets_TicketConcertId",
                table: "Purchased_Ticket",
                newName: "IX_Purchased_Ticket_TicketConcertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket_Concert",
                table: "Ticket_Concert",
                column: "TicketConcertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchased_Ticket",
                table: "Purchased_Ticket",
                columns: new[] { "CustomerId", "TicketConcertId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concert",
                table: "Concert",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchased_Ticket_Customer_CustomerId",
                table: "Purchased_Ticket",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchased_Ticket_Ticket_Concert_TicketConcertId",
                table: "Purchased_Ticket",
                column: "TicketConcertId",
                principalTable: "Ticket_Concert",
                principalColumn: "TicketConcertId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Concert_Concert_ConcertId",
                table: "Ticket_Concert",
                column: "ConcertId",
                principalTable: "Concert",
                principalColumn: "ConcertId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Concert_Ticket_TicketId",
                table: "Ticket_Concert",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
