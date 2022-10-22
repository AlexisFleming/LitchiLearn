using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_LitchiLearn.Migrations
{
    public partial class QuizQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizID",
                schema: "Identity",
                table: "Questions",
                column: "QuizID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizID",
                schema: "Identity",
                table: "Questions",
                column: "QuizID",
                principalSchema: "Identity",
                principalTable: "Quizzes",
                principalColumn: "QuizID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizID",
                schema: "Identity",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuizID",
                schema: "Identity",
                table: "Questions");
        }
    }
}
