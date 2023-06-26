using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class tablaIntermediaQuestionSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Skill_SkillId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_SkillId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Question");

            migrationBuilder.CreateTable(
                name: "QuestionSkillEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdQuestion = table.Column<int>(type: "int", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSkillEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionSkillEntity_Question_IdQuestion",
                        column: x => x.IdQuestion,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionSkillEntity_Skill_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSkillEntity_IdQuestion",
                table: "QuestionSkillEntity",
                column: "IdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSkillEntity_IdSkill",
                table: "QuestionSkillEntity",
                column: "IdSkill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionSkillEntity");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_SkillId",
                table: "Question",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Skill_SkillId",
                table: "Question",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id");
        }
    }
}
