using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TribesWebAPI.Data.Migrations
{
    public partial class casadeRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestedPeople_Events_HostEventId",
                table: "RequestedPeople");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedPeople_Events_HostEventId",
                table: "RequestedPeople",
                column: "HostEventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestedPeople_Events_HostEventId",
                table: "RequestedPeople");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedPeople_Events_HostEventId",
                table: "RequestedPeople",
                column: "HostEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
