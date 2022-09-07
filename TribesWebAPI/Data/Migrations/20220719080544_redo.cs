using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TribesWebAPI.Data.Migrations
{
    public partial class redo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Events_EventModelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EventModelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EventModelId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "RegisteredForEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredForEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredForEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegisteredForEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredForEvents_EventId",
                table: "RegisteredForEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredForEvents_UserId",
                table: "RegisteredForEvents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredForEvents");

            migrationBuilder.AddColumn<int>(
                name: "EventModelId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventModelId",
                table: "Users",
                column: "EventModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Events_EventModelId",
                table: "Users",
                column: "EventModelId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
