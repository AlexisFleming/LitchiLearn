using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_LitchiLearn.Migrations
{
    public partial class CuriculumModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurriculumModel",
                schema: "Identity",
                columns: table => new
                {
                    CurrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PDFfile = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumModel", x => x.CurrID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculumModel",
                schema: "Identity");
        }
    }
}
