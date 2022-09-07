using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TribesWebAPI.Data.Migrations
{
    public partial class delete2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
