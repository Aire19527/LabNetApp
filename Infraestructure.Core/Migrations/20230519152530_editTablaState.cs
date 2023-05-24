using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class editTablaState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_State_StateEntityId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_StateEntityId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StateEntityId",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateEntityId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_StateEntityId",
                table: "User",
                column: "StateEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_State_StateEntityId",
                table: "User",
                column: "StateEntityId",
                principalTable: "State",
                principalColumn: "Id");
        }
    }
}
