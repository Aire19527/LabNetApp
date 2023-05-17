using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Core.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<AdressEntity> AdressEntity { get; set; }
        public DbSet<CertificationEntity> CertificationsEntity { get; set; }
        public DbSet<CityEntity> CitiesEntity { get; set; }
        public DbSet<ConfigEntity> ConfigsEntity { get; set; }
        public DbSet<CountryEntity> CountriesEntity { get; set; }
        public DbSet<DniTypeEntity> DniTypesEntity { get; set; }
        public DbSet<EducationEntity> EducationsEntity { get; set; }
        public DbSet<InstitutionTypeEntity> InstitutionsTypeEntity { get; set; }
        public DbSet<JobPositionEntity> JobPositionsEntity { get; set; }
        public DbSet<PermissionEntity> PermissionsEntity { get; set; }
        public DbSet<PermissionTypeEntity> PermissionsTypeEntity { get; set; }
        public DbSet<ProfileEntity> ProfilesEntity { get; set; }
        public DbSet<ProvinceEntity> ProvincesEntity { get; set; }
        public DbSet<RoleEntity> RolesEntity { get; set; }
        public DbSet<SkillEntity> SkillsEntity { get; set; }
        public DbSet<UserEntity> UsersEntity { get; set; }
        public DbSet<WorkEntity> WorksEntity { get; set; }
        public DbSet<RolePermissionEntity> RolePermissionsEntity { get; set; }
        public DbSet<StateEntity> StatesEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                   .HasIndex(b => b.Mail)
                   .IsUnique();

            modelBuilder.Entity<RolePermissionEntity>()
                .HasIndex(r => new { r.IdPermission, r.IdRol })
                .IsUnique();

            modelBuilder.Entity<ProfilesSkillsEntity>()
                .HasIndex(x => new
                {
                    x.IdProfile,
                    x.IdSkill
                })
                .IsUnique();

            modelBuilder.Entity<ProfileEducationEntity>()
                .HasIndex(x => new
                {
                    x.IdProfile,
                    x.IdEducation
                })
                .IsUnique();

            modelBuilder.Entity<ProfileWorkEntity>()
               .HasIndex(x => new
               {
                   x.IdProfile,
                   x.IdWork
               })
               .IsUnique();

            modelBuilder.Entity<ProfileCertificationEntity>()
               .HasIndex(x => new
               {
                   x.IdProfile,
                   x.IdCertification
               })
               .IsUnique();
        }
    }
}