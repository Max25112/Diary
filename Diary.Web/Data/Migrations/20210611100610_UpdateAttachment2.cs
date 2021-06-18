using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Web.Data.Migrations
{
    public partial class UpdateAttachment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_HomeworkResults_HomeworkResultId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "HomeworkResulttId",
                table: "Attachments");

            migrationBuilder.AlterColumn<int>(
                name: "HomeworkResultId",
                table: "Attachments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_HomeworkResults_HomeworkResultId",
                table: "Attachments",
                column: "HomeworkResultId",
                principalTable: "HomeworkResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_HomeworkResults_HomeworkResultId",
                table: "Attachments");

            migrationBuilder.AlterColumn<int>(
                name: "HomeworkResultId",
                table: "Attachments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HomeworkResulttId",
                table: "Attachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_HomeworkResults_HomeworkResultId",
                table: "Attachments",
                column: "HomeworkResultId",
                principalTable: "HomeworkResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
