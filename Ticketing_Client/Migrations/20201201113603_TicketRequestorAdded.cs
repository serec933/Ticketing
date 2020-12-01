﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketing_Client.Migrations
{
    public partial class TicketRequestorAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Requestor",
                table: "Tickets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Requestor",
                table: "Tickets");
        }
    }
}
