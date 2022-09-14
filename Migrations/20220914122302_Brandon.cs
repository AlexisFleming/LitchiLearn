using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_LitchiLearn.Migrations
{
    public partial class Brandon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attachments",
                schema: "Identity",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    attachment = table.Column<byte[]>(type: "varbinary(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EnrolTable",
                schema: "Identity",
                columns: table => new
                {
                    EnrolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolTable", x => x.EnrolID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "Identity",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuizID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "Identity",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "TimeTable",
                schema: "Identity",
                columns: table => new
                {
                    SubjectID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTable", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                schema: "Identity",
                columns: table => new
                {
                    TopicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicID);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                schema: "Identity",
                columns: table => new
                {
                    QuizID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false),
                    TopicsID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizID);
                    table.ForeignKey(
                        name: "FK_Quizzes_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalSchema: "Identity",
                        principalTable: "Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_QuizTopics_TopicsTopicID",
                schema: "Identity",
                table: "QuizTopics",
                column: "TopicsTopicID");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_QuestionID",
                schema: "Identity",
                table: "Quizzes",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubject_SubjectID",
                schema: "Identity",
                table: "UserSubject",
                column: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attachments",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "EnrolTable",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "QuizTopics",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TimeTable",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserSubject",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Quizzes",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Topics",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "Identity");
        }
    }
}
