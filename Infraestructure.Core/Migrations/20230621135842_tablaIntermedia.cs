using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class tablaIntermedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answer");

            migrationBuilder.AddColumn<int>(
                name: "IdProfile",
                table: "File",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionEntityId",
                table: "Answer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AnswerEntityId",
                table: "Answer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionsAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    isCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsAnswers_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsAnswers_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_AnswerEntityId",
                table: "Answer",
                column: "AnswerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsAnswers_AnswerId",
                table: "QuestionsAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsAnswers_QuestionId_AnswerId",
                table: "QuestionsAnswers",
                columns: new[] { "QuestionId", "AnswerId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Answer_AnswerEntityId",
                table: "Answer",
                column: "AnswerEntityId",
                principalTable: "Answer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer",
                column: "QuestionEntityId",
                principalTable: "Question",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Answer_AnswerEntityId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer");

            migrationBuilder.DropTable(
                name: "QuestionsAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Answer_AnswerEntityId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "IdProfile",
                table: "File");

            migrationBuilder.DropColumn(
                name: "AnswerEntityId",
                table: "Answer");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionEntityId",
                table: "Answer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer",
                column: "QuestionEntityId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
