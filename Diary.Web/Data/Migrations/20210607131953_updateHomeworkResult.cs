using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Web.Data.Migrations
{
    public partial class updateHomeworkResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeworkResultId",
                table: "Attachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeworkResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    HomeworkID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkResults_Homeworks_HomeworkID",
                        column: x => x.HomeworkID,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeworkResults_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HomeworkResults_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_HomeworkResultId",
                table: "Attachments",
                column: "HomeworkResultId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkResults_HomeworkID",
                table: "HomeworkResults",
                column: "HomeworkID");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkResults_StudentId",
                table: "HomeworkResults",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkResults_TeacherId",
                table: "HomeworkResults",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_HomeworkResults_HomeworkResultId",
                table: "Attachments",
                column: "HomeworkResultId",
                principalTable: "HomeworkResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_HomeworkResults_HomeworkResultId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "HomeworkResults");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_HomeworkResultId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "HomeworkResultId",
                table: "Attachments");
        }
    }
}
