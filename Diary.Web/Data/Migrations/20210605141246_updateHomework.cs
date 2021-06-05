using Microsoft.EntityFrameworkCore.Migrations;

namespace Diary.Web.Data.Migrations
{
    public partial class updateHomework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_TeacherId",
                table: "Homeworks",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Teachers_TeacherId",
                table: "Homeworks",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Teachers_TeacherId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_TeacherId",
                table: "Homeworks");
        }
    }
}
