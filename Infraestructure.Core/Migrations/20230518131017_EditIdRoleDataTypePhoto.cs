using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class EditIdRoleDataTypePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_IdEntity",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "IdEntity",
                table: "User",
                newName: "IdRole");

            migrationBuilder.RenameIndex(
                name: "IX_User_IdEntity",
                table: "User",
                newName: "IX_User_IdRole");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_IdRole",
                table: "User",
                column: "IdRole",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_IdRole",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "User",
                newName: "IdEntity");

            migrationBuilder.RenameIndex(
                name: "IX_User_IdRole",
                table: "User",
                newName: "IX_User_IdEntity");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Profile",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_IdEntity",
                table: "User",
                column: "IdEntity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
