using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class mockFinished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEntity",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCountryEntity",
                table: "Province",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPermissionTypeEntity",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdInstitutionType",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDProvinceEntity",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCityEntity",
                table: "Adress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdEntity",
                table: "User",
                column: "IdEntity");

            migrationBuilder.CreateIndex(
                name: "IX_Province_IdCountryEntity",
                table: "Province",
                column: "IdCountryEntity");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_IdPermissionTypeEntity",
                table: "Permission",
                column: "IdPermissionTypeEntity");

            migrationBuilder.CreateIndex(
                name: "IX_Education_IdInstitutionType",
                table: "Education",
                column: "IdInstitutionType");

            migrationBuilder.CreateIndex(
                name: "IX_City_IDProvinceEntity",
                table: "City",
                column: "IDProvinceEntity");

            migrationBuilder.CreateIndex(
                name: "IX_Adress_IdCityEntity",
                table: "Adress",
                column: "IdCityEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_City_IdCityEntity",
                table: "Adress",
                column: "IdCityEntity",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Province_IDProvinceEntity",
                table: "City",
                column: "IDProvinceEntity",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_InstitutionType_IdInstitutionType",
                table: "Education",
                column: "IdInstitutionType",
                principalTable: "InstitutionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_PermissionType_IdPermissionTypeEntity",
                table: "Permission",
                column: "IdPermissionTypeEntity",
                principalTable: "PermissionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Province_Country_IdCountryEntity",
                table: "Province",
                column: "IdCountryEntity",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_IdEntity",
                table: "User",
                column: "IdEntity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_City_IdCityEntity",
                table: "Adress");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Province_IDProvinceEntity",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_InstitutionType_IdInstitutionType",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_PermissionType_IdPermissionTypeEntity",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Province_Country_IdCountryEntity",
                table: "Province");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_IdEntity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdEntity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Province_IdCountryEntity",
                table: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Permission_IdPermissionTypeEntity",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Education_IdInstitutionType",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_City_IDProvinceEntity",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_Adress_IdCityEntity",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "IdEntity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdCountryEntity",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "IdPermissionTypeEntity",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "IdInstitutionType",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "IDProvinceEntity",
                table: "City");

            migrationBuilder.DropColumn(
                name: "IdCityEntity",
                table: "Adress");
        }
    }
}
