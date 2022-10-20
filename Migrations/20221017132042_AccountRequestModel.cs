using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_LitchiLearn.Migrations
{
    public partial class AccountRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDateTime",
                schema: "Identity",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                schema: "Identity",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "TopicsID",
                schema: "Identity",
                table: "Quizzes",
                newName: "TopicID");

            migrationBuilder.RenameColumn(
                name: "QuestionName",
                schema: "Identity",
                table: "Questions",
                newName: "QuesDesc");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                schema: "Identity",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                schema: "Identity",
                table: "Quizzes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                schema: "Identity",
                table: "Quizzes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                schema: "Identity",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option1",
                schema: "Identity",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option2",
                schema: "Identity",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option3",
                schema: "Identity",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Option4",
                schema: "Identity",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectID",
                schema: "Identity",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                schema: "Identity",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                schema: "Identity",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Answer",
                schema: "Identity",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Option1",
                schema: "Identity",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Option2",
                schema: "Identity",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Option3",
                schema: "Identity",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Option4",
                schema: "Identity",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "TopicID",
                schema: "Identity",
                table: "Quizzes",
                newName: "TopicsID");

            migrationBuilder.RenameColumn(
                name: "QuesDesc",
                schema: "Identity",
                table: "Questions",
                newName: "QuestionName");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                schema: "Identity",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                schema: "Identity",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
