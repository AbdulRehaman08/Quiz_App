using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizz.Repository.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
