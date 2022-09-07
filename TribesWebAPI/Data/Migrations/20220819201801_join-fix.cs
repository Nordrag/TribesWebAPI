using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TribesWebAPI.Data.Migrations
{
    public partial class joinfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForEvents_Events_EventId",
                table: "RegisteredForEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForEvents_Users_UserId",
                table: "RegisteredForEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Events_EventIdId",
                table: "UsedTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Subtags_TagIdId",
                table: "UsedTags");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RegisteredForEvents",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "RegisteredForEvents",
                newName: "EventID");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredForEvents_UserId",
                table: "RegisteredForEvents",
                newName: "IX_RegisteredForEvents_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredForEvents_EventId",
                table: "RegisteredForEvents",
                newName: "IX_RegisteredForEvents_EventID");

            migrationBuilder.AlterColumn<int>(
                name: "TagIdId",
                table: "UsedTags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventIdId",
                table: "UsedTags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "RegisteredForEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "RegisteredForEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForEvents_Events_EventID",
                table: "RegisteredForEvents",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForEvents_Users_UserID",
                table: "RegisteredForEvents",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_RegisteredForEvents_Events_EventID",
                table: "RegisteredForEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredForEvents_Users_UserID",
                table: "RegisteredForEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Events_EventIdId",
                table: "UsedTags");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedTags_Subtags_TagIdId",
                table: "UsedTags");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "RegisteredForEvents",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "RegisteredForEvents",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredForEvents_UserID",
                table: "RegisteredForEvents",
                newName: "IX_RegisteredForEvents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RegisteredForEvents_EventID",
                table: "RegisteredForEvents",
                newName: "IX_RegisteredForEvents_EventId");

            migrationBuilder.AlterColumn<int>(
                name: "TagIdId",
                table: "UsedTags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventIdId",
                table: "UsedTags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RegisteredForEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "RegisteredForEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForEvents_Events_EventId",
                table: "RegisteredForEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredForEvents_Users_UserId",
                table: "RegisteredForEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

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
