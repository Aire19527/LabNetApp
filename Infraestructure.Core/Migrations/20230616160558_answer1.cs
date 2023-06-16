using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class answer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "IdQuestion",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer",
                column: "QuestionEntityId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionEntityId",
                table: "Answer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdQuestion",
                table: "Answer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionEntityId",
                table: "Answer",
                column: "QuestionEntityId",
                principalTable: "Question",
                principalColumn: "Id");
        }
    }
}
