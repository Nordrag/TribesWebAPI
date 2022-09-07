using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TribesWebAPI.Data.Migrations
{
    public partial class casadeRequestTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Events_EventIdId",
                table: "UsedTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Subtags_TagIdId",
                table: "UsedTags");

            migrationBuilder.AddForeignKey(
                name: "FK_UsedTags_Events_EventIdId",
                table: "UsedTags",
                column: "EventIdId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsedTags_Subtags_TagIdId",
                table: "UsedTags",
                column: "TagIdId",
                principalTable: "Subtags",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Events_EventIdId",
                table: "UsedTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Subtags_TagIdId",
                table: "UsedTags");

            migrationBuilder.AddForeignKey(
                name: "FK_UsedTags_Events_EventIdId",
                table: "UsedTags",
                column: "EventIdId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsedTags_Subtags_TagIdId",
                table: "UsedTags",
                column: "TagIdId",
                principalTable: "Subtags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
