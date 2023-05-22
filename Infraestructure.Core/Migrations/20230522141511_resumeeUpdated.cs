using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class resumeeUpdated : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "CV",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<byte[]>(
                name: "CV",
                table: "Profile",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
