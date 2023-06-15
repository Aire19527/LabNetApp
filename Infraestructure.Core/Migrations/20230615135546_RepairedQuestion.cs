using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class RepairedQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer");

            migrationBuilder.RenameColumn(
                name: "QuestionEntityId",
                table: "Answer",
                newName: "IdQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_QuestionEntityId",
                table: "Answer",
                newName: "IX_Answer_IdQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_IdQuestion",
                table: "Answer",
                column: "IdQuestion",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_IdQuestion",
                table: "Answer");

            migrationBuilder.RenameColumn(
                name: "IdQuestion",
                table: "Answer",
                newName: "QuestionEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_IdQuestion",
                table: "Answer",
                newName: "IX_Answer_QuestionEntityId");

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
