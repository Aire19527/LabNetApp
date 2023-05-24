using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class relacionQuitada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Adress_IdAdress",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_DniType_IdDniType",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_JobPosition_IdJobPosition",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_User_State_IdState",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdState",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdState",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StateEntityId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdJobPosition",
                table: "Profile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdDniType",
                table: "Profile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAdress",
                table: "Profile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_User_StateEntityId",
                table: "User",
                column: "StateEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Adress_IdAdress",
                table: "Profile",
                column: "IdAdress",
                principalTable: "Adress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_DniType_IdDniType",
                table: "Profile",
                column: "IdDniType",
                principalTable: "DniType",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_JobPosition_IdJobPosition",
                table: "Profile",
                column: "IdJobPosition",
                principalTable: "JobPosition",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_State_StateEntityId",
                table: "User",
                column: "StateEntityId",
                principalTable: "State",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Adress_IdAdress",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_DniType_IdDniType",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_JobPosition_IdJobPosition",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_User_State_StateEntityId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_StateEntityId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StateEntityId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "IdState",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdJobPosition",
                table: "Profile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDniType",
                table: "Profile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdAdress",
                table: "Profile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdState",
                table: "User",
                column: "IdState");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Adress_IdAdress",
                table: "Profile",
                column: "IdAdress",
                principalTable: "Adress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_DniType_IdDniType",
                table: "Profile",
                column: "IdDniType",
                principalTable: "DniType",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_JobPosition_IdJobPosition",
                table: "Profile",
                column: "IdJobPosition",
                principalTable: "JobPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_State_IdState",
                table: "User",
                column: "IdState",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
