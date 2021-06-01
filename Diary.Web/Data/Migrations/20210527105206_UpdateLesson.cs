using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Web.Data.Migrations
{
    public partial class UpdateLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ClassId",
                table: "Lessons",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SubjectId",
                table: "Lessons",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Subjects_SubjectId",
                table: "Lessons",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Classes_ClassId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Subjects_SubjectId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_ClassId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_SubjectId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Lessons");
        }
    }
}
