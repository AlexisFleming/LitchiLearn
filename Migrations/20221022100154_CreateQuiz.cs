using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_LitchiLearn.Migrations
{
    public partial class CreateQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicsTopicID",
                schema: "Identity",
                table: "Quizzes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_TopicsTopicID",
                schema: "Identity",
                table: "Quizzes",
                column: "TopicsTopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Topics_TopicsTopicID",
                schema: "Identity",
                table: "Quizzes",
                column: "TopicsTopicID",
                principalSchema: "Identity",
                principalTable: "Topics",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Topics_TopicsTopicID",
                schema: "Identity",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_TopicsTopicID",
                schema: "Identity",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "TopicsTopicID",
                schema: "Identity",
                table: "Quizzes");
        }
    }
}
