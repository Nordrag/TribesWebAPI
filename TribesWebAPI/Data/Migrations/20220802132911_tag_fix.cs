using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace TribesWebAPI.Data.Migrations
{
    public partial class tag_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtags_Events_EventModelId",
                table: "Subtags");

            migrationBuilder.DropIndex(
                name: "IX_Subtags_EventModelId",
                table: "Subtags");

            migrationBuilder.DropColumn(
                name: "EventModelId",
                table: "Subtags");

            migrationBuilder.CreateTable(
                name: "TagsUsed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagIdId = table.Column<int>(type: "int", nullable: false),
                    EventIdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsUsed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagsUsed_Events_EventIdId",
                        column: x => x.EventIdId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagsUsed_Subtags_TagIdId",
                        column: x => x.TagIdId,
                        principalTable: "Subtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagsUsed_EventIdId",
                table: "TagsUsed",
                column: "EventIdId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsUsed_TagIdId",
                table: "TagsUsed",
                column: "TagIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagsUsed");

            migrationBuilder.AddColumn<int>(
                name: "EventModelId",
                table: "Subtags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subtags_EventModelId",
                table: "Subtags",
                column: "EventModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtags_Events_EventModelId",
                table: "Subtags",
                column: "EventModelId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
