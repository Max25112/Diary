using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Web.Data.Migrations
{
    public partial class UpdateHomework3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkResults_SubjectId",
                table: "HomeworkResults",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkResults_Subjects_SubjectId",
                table: "HomeworkResults",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkResults_Subjects_SubjectId",
                table: "HomeworkResults");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkResults_SubjectId",
                table: "HomeworkResults");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "HomeworkResults");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "HomeworkResults");
        }
    }
}
