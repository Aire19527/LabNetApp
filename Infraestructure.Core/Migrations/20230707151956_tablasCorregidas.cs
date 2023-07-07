using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class tablasCorregidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isCorrect",
                table: "QuestionsAnswers",
                newName: "IsCorrect");

            migrationBuilder.AlterColumn<decimal>(
                name: "Points",
                table: "AssessmentQuestionAnswer",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCorrect",
                table: "QuestionsAnswers",
                newName: "isCorrect");

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "AssessmentQuestionAnswer",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
