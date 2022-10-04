using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_LitchiLearn.Migrations
{
    public partial class FixRelationshipQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Questions_QuestionID",
                schema: "Identity",
                table: "Quizzes");

            migrationBuilder.DropTable(
                name: "QuizTopics",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserSubject",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_QuestionID",
                schema: "Identity",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                schema: "Identity",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "QuizID",
                schema: "Identity",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                schema: "Identity",
                table: "Quizzes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuizID",
                schema: "Identity",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuizTopics",
                schema: "Identity",
                columns: table => new
                {
                    QuizID = table.Column<int>(type: "int", nullable: false),
                    TopicsTopicID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizTopics", x => new { x.QuizID, x.TopicsTopicID });
                    table.ForeignKey(
                        name: "FK_QuizTopics_Quizzes_QuizID",
                        column: x => x.QuizID,
                        principalSchema: "Identity",
                        principalTable: "Quizzes",
                        principalColumn: "QuizID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizTopics_Topics_TopicsTopicID",
                        column: x => x.TopicsTopicID,
                        principalSchema: "Identity",
                        principalTable: "Topics",
                        principalColumn: "TopicID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubject",
                schema: "Identity",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubject", x => new { x.UserID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_UserSubject_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalSchema: "Identity",
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSubject_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_QuestionID",
                schema: "Identity",
                table: "Quizzes",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTopics_TopicsTopicID",
                schema: "Identity",
                table: "QuizTopics",
                column: "TopicsTopicID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubject_SubjectID",
                schema: "Identity",
                table: "UserSubject",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Questions_QuestionID",
                schema: "Identity",
                table: "Quizzes",
                column: "QuestionID",
                principalSchema: "Identity",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
