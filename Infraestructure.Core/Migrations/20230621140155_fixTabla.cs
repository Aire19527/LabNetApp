using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class fixTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Answer_AnswerEntityId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_AnswerEntityId",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_QuestionEntityId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "AnswerEntityId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "QuestionEntityId",
                table: "Answer");

            migrationBuilder.CreateTable(
                name: "AnswerEntityQuestionEntity",
                columns: table => new
                {
                    AnswerEntitiesId = table.Column<int>(type: "int", nullable: false),
                    QuestionEntitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerEntityQuestionEntity", x => new { x.AnswerEntitiesId, x.QuestionEntitiesId });
                    table.ForeignKey(
                        name: "FK_AnswerEntityQuestionEntity_Answer_AnswerEntitiesId",
                        column: x => x.AnswerEntitiesId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerEntityQuestionEntity_Question_QuestionEntitiesId",
                        column: x => x.QuestionEntitiesId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerEntityQuestionEntity_QuestionEntitiesId",
                table: "AnswerEntityQuestionEntity",
                column: "QuestionEntitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerEntityQuestionEntity");

            migrationBuilder.AddColumn<int>(
                name: "AnswerEntityId",
                table: "Answer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionEntityId",
                table: "Answer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answer_AnswerEntityId",
                table: "Answer",
                column: "AnswerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionEntityId",
                table: "Answer",
                column: "QuestionEntityId");

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
    }
}
