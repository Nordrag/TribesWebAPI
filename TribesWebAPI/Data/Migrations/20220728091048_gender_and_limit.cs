using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TribesWebAPI.Data.Migrations
{
    public partial class gender_and_limit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxAllowed",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MaxAllowed",
                table: "Events");
        }
    }
}
