using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_LitchiLearn.Migrations
{
    public partial class lexidb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminSubjectModels",
                schema: "Identity",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectGrade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectGradeHead = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSubjectModels", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountModels",
                schema: "Identity",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usertype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountModels", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminSubjectModels",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserAccountModels",
                schema: "Identity");
        }
    }
}
