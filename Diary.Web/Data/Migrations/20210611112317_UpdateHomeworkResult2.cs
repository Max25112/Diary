using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Web.Data.Migrations
{
    public partial class UpdateHomeworkResult2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "HomeworkResults");

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "HomeworkResults",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Response",
                table: "HomeworkResults");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "HomeworkResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
