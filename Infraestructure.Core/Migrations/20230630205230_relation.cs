using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequirementQuestion_IdQuestion",
                table: "RequirementQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementQuestion_IdQuestion_IdRequest",
                table: "RequirementQuestion",
                columns: new[] { "IdQuestion", "IdRequest" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequirementQuestion_IdQuestion_IdRequest",
                table: "RequirementQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementQuestion_IdQuestion",
                table: "RequirementQuestion",
                column: "IdQuestion");
        }
    }
}
