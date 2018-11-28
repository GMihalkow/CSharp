using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventures.Data.Migrations
{
    public partial class AddedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_EventureUserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventureUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventureUserId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderedOn = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<string>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    TicketsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => new { x.CustomerId, x.EventId });
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EventId",
                table: "Orders",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "EventureUserId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventureUserId",
                table: "Events",
                column: "EventureUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_EventureUserId",
                table: "Events",
                column: "EventureUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
