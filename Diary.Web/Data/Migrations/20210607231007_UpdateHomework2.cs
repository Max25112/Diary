using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Web.Data.Migrations
{
    public partial class UpdateHomework2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_SubjectId",
                table: "Homeworks",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId",
                table: "Homeworks",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkResults_Homeworks_HomeworkId",
                table: "HomeworkResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Subjects_SubjectId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_SubjectId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Homeworks");
        }
    }
}
