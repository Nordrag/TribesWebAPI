using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TribesWebAPI.Data.Migrations
{
    public partial class tag_apply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsUsed_Events_EventIdId",
                table: "TagsUsed");

            migrationBuilder.DropForeignKey(
                name: "FK_TagsUsed_Subtags_TagIdId",
                table: "TagsUsed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagsUsed",
                table: "TagsUsed");

            migrationBuilder.RenameTable(
                name: "TagsUsed",
                newName: "UsedTags");

            migrationBuilder.RenameIndex(
                name: "IX_TagsUsed_TagIdId",
                table: "UsedTags",
                newName: "IX_UsedTags_TagIdId");

            migrationBuilder.RenameIndex(
                name: "IX_TagsUsed_EventIdId",
                table: "UsedTags",
                newName: "IX_UsedTags_EventIdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsedTags",
                table: "UsedTags",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Events_EventIdId",
                table: "UsedTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Subtags_TagIdId",
                table: "UsedTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsedTags",
                table: "UsedTags");

            migrationBuilder.RenameTable(
                name: "UsedTags",
                newName: "TagsUsed");

            migrationBuilder.RenameIndex(
                name: "IX_UsedTags_TagIdId",
                table: "TagsUsed",
                newName: "IX_TagsUsed_TagIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UsedTags_EventIdId",
                table: "TagsUsed",
                newName: "IX_TagsUsed_EventIdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagsUsed",
                table: "TagsUsed",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagsUsed_Events_EventIdId",
                table: "TagsUsed",
                column: "EventIdId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagsUsed_Subtags_TagIdId",
                table: "TagsUsed",
                column: "TagIdId",
                principalTable: "Subtags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
