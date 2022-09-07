using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TribesWebAPI.Data.Migrations
{
    public partial class requestlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestedPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    HostEventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestedPeople_Events_HostEventId",
                        column: x => x.HostEventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestedPeople_HostEventId",
                table: "RequestedPeople",
                column: "HostEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestedPeople");
        }
    }
}
