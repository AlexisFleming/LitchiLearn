using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_LitchiLearn.Migrations
{
    public partial class Lexi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoleID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Grade",
                schema: "Identity",
                table: "TimeTable");

            migrationBuilder.RenameColumn(
                name: "email",
                schema: "Identity",
                table: "User",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "TimeTableData",
                schema: "Identity",
                table: "TimeTable",
                newName: "SubjectID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Identity",
                table: "User",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Day",
                schema: "Identity",
                table: "TimeTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                schema: "Identity",
                table: "TimeTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                schema: "Identity",
                table: "TimeTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                schema: "Identity",
                table: "TimeTable",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "EnrolTable",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "QuizTopics",
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

            migrationBuilder.DropColumn(
                name: "Day",
                schema: "Identity",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "Subject",
                schema: "Identity",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "Time",
                schema: "Identity",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "Venue",
                schema: "Identity",
                table: "TimeTable");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "Identity",
                table: "User",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "SubjectID",
                schema: "Identity",
                table: "TimeTable",
                newName: "TimeTableData");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Identity",
                table: "User",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                schema: "Identity",
                table: "TimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
