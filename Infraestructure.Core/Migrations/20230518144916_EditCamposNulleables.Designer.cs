﻿// <auto-generated />
using System;
using Infraestructure.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230518144916_EditCamposNulleables")]
    partial class EditCamposNulleables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Infraestructure.Entity.Models.AdressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IdCityEntity")
                        .HasColumnType("int");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdCityEntity");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.CertificationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ExpeditionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Certification");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("IDProvinceEntity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IDProvinceEntity");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.DniTypeEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("id");

                    b.ToTable("DniType");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.EducationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ExpeditionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdInstitutionType")
                        .HasColumnType("int");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdInstitutionType");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.InstitutionTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("InstitutionType");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.JobPositionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobPosition");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPermissionTypeEntity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPermissionTypeEntity");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("PermissionType");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfileCertificationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdCertification")
                        .HasColumnType("int");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCertification");

                    b.HasIndex("IdProfile", "IdCertification")
                        .IsUnique();

                    b.ToTable("ProfileCertification");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfileEducationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdEducation")
                        .HasColumnType("int");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEducation");

                    b.HasIndex("IdProfile", "IdEducation")
                        .IsUnique();

                    b.ToTable("ProfileEducation");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("CV")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("DNI")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAdress")
                        .HasColumnType("int");

                    b.Property<int>("IdDniType")
                        .HasColumnType("int");

                    b.Property<int>("IdJobPosition")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAdress");

                    b.HasIndex("IdDniType");

                    b.HasIndex("IdJobPosition");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfilesSkillsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.Property<int>("IdSkill")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdSkill");

                    b.HasIndex("IdProfile", "IdSkill")
                        .IsUnique();

                    b.ToTable("ProfilesSkills");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfileWorkEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdProfile")
                        .HasColumnType("int");

                    b.Property<int>("IdWork")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdWork");

                    b.HasIndex("IdProfile", "IdWork")
                        .IsUnique();

                    b.ToTable("ProfileWork");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProvinceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("IdCountryEntity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCountryEntity");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RolePermissionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPermission")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdRol");

                    b.HasIndex("IdPermission", "IdRol")
                        .IsUnique();

                    b.ToTable("RolesPermissions");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.SkillEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.StateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ambit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.HasIndex("IdState");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.WorkEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BossContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BossName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BossRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("DetailFuntion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Work");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.AdressEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.CityEntity", "CityEntity")
                        .WithMany()
                        .HasForeignKey("IdCityEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.CityEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.ProvinceEntity", "ProvinceEntity")
                        .WithMany("CityEntities")
                        .HasForeignKey("IDProvinceEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProvinceEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.EducationEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.InstitutionTypeEntity", "InstitutionTypeEntity")
                        .WithMany("EducationEntities")
                        .HasForeignKey("IdInstitutionType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InstitutionTypeEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.PermissionTypeEntity", "PermissionTypeEntity")
                        .WithMany("PermissionEntity")
                        .HasForeignKey("IdPermissionTypeEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionTypeEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfileCertificationEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.CertificationEntity", "CertificationEntity")
                        .WithMany("ProfileCertificationEntity")
                        .HasForeignKey("IdCertification")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.ProfileEntity", "ProfileEntity")
                        .WithMany("ProfileCertificationEntity")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CertificationEntity");

                    b.Navigation("ProfileEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfileEducationEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.EducationEntity", "EducationEntity")
                        .WithMany("ProfileEducationEntity")
                        .HasForeignKey("IdEducation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.ProfileEntity", "ProfileEntity")
                        .WithMany("ProfileEducationEntity")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EducationEntity");

                    b.Navigation("ProfileEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfileEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.AdressEntity", "AdressEntity")
                        .WithMany("ProfileEntity")
                        .HasForeignKey("IdAdress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.DniTypeEntity", "DniTypeEntity")
                        .WithMany("ProfileEntity")
                        .HasForeignKey("IdDniType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.JobPositionEntity", "JobPositionEntity")
                        .WithMany("ProfileEntity")
                        .HasForeignKey("IdJobPosition")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.UserEntity", "UserEntity")
                        .WithOne("ProfileEntity")
                        .HasForeignKey("Infraestructure.Entity.Models.ProfileEntity", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdressEntity");

                    b.Navigation("DniTypeEntity");

                    b.Navigation("JobPositionEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfilesSkillsEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.ProfileEntity", "ProfileEntity")
                        .WithMany("ProfilesSkillsEntity")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.SkillEntity", "SkillEntity")
                        .WithMany("ProfilesSkillsEntity")
                        .HasForeignKey("IdSkill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileEntity");

                    b.Navigation("SkillEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfileWorkEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.ProfileEntity", "ProfileEntity")
                        .WithMany("ProfileWorkEntity")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.WorkEntity", "WorkEntity")
                        .WithMany("ProfileWorkEntity")
                        .HasForeignKey("IdWork")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileEntity");

                    b.Navigation("WorkEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProvinceEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.CountryEntity", "CountryEntity")
                        .WithMany()
                        .HasForeignKey("IdCountryEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RolePermissionEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.PermissionEntity", "PermissionEntity")
                        .WithMany("RolePermissionEntities")
                        .HasForeignKey("IdPermission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.RoleEntity", "RoleEntity")
                        .WithMany("RolePermissionEntities")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionEntity");

                    b.Navigation("RoleEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.UserEntity", b =>
                {
                    b.HasOne("Infraestructure.Entity.Models.RoleEntity", "RoleEntity")
                        .WithMany("UsersEntities")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infraestructure.Entity.Models.StateEntity", "StateEntity")
                        .WithMany("UserEntities")
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleEntity");

                    b.Navigation("StateEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.AdressEntity", b =>
                {
                    b.Navigation("ProfileEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.CertificationEntity", b =>
                {
                    b.Navigation("ProfileCertificationEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.DniTypeEntity", b =>
                {
                    b.Navigation("ProfileEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.EducationEntity", b =>
                {
                    b.Navigation("ProfileEducationEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.InstitutionTypeEntity", b =>
                {
                    b.Navigation("EducationEntities");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.JobPositionEntity", b =>
                {
                    b.Navigation("ProfileEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionEntity", b =>
                {
                    b.Navigation("RolePermissionEntities");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.PermissionTypeEntity", b =>
                {
                    b.Navigation("PermissionEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProfileEntity", b =>
                {
                    b.Navigation("ProfileCertificationEntity");

                    b.Navigation("ProfileEducationEntity");

                    b.Navigation("ProfileWorkEntity");

                    b.Navigation("ProfilesSkillsEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.ProvinceEntity", b =>
                {
                    b.Navigation("CityEntities");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.RoleEntity", b =>
                {
                    b.Navigation("RolePermissionEntities");

                    b.Navigation("UsersEntities");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.SkillEntity", b =>
                {
                    b.Navigation("ProfilesSkillsEntity");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.StateEntity", b =>
                {
                    b.Navigation("UserEntities");
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.UserEntity", b =>
                {
                    b.Navigation("ProfileEntity")
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestructure.Entity.Models.WorkEntity", b =>
                {
                    b.Navigation("ProfileWorkEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
