using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_LitchiLearn.Migrations
{
    public partial class TimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeTable",
                schema: "Identity",
                table: "TimeTable");

            migrationBuilder.AlterColumn<string>(
                name: "TimeTableData",
                schema: "Identity",
                table: "TimeTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "Identity",
                table: "TimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                schema: "Identity",
                table: "TimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeTable",
                schema: "Identity",
                table: "TimeTable",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeTable",
                schema: "Identity",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Identity",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                schema: "Identity",
                table: "TimeTable");

            migrationBuilder.AlterColumn<string>(
                name: "TimeTableData",
                schema: "Identity",
                table: "TimeTable",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeTable",
                schema: "Identity",
                table: "TimeTable",
                column: "TimeTableData");
        }
    }
}
