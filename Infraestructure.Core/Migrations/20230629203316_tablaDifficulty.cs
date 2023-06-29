using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class tablaDifficulty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Question",
                newName: "IdIdDifficulty");

            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_IdIdDifficulty",
                table: "Question",
                column: "IdIdDifficulty");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Difficulty_IdIdDifficulty",
                table: "Question",
                column: "IdIdDifficulty",
                principalTable: "Difficulty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Difficulty_IdIdDifficulty",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropIndex(
                name: "IX_Question_IdIdDifficulty",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "IdIdDifficulty",
                table: "Question",
                newName: "Value");
        }
    }
}
