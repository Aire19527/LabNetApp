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
        public DbSet<CertificationEntity> CertificationEntity { get; set; }
        public DbSet<CityEntity> CityEntity { get; set; }
        public DbSet<ConfigEntity> ConfigEntity { get; set; }
        public DbSet<CountryEntity> CountryEntity { get; set; }
        public DbSet<DniTypeEntity> DniTypeEntity { get; set; }
        public DbSet<EducationEntity> EducationEntity { get; set; }
        public DbSet<InstitutionTypeEntity> InstitutionTypeEntity { get; set; }
        public DbSet<JobPositionEntity> JobPositionEntity { get; set; }
        public DbSet<PermissionEntity> PermissionEntity { get; set; }
        public DbSet<PermissionTypeEntity> PermissionTypeEntity { get; set; }
        public DbSet<ProfileEntity> ProfileEntity { get; set; }
        public DbSet<ProvinceEntity> ProvinceEntity { get; set; }
        public DbSet<RoleEntity> RoleEntity { get; set; }
        public DbSet<SkillEntity> SkillEntity { get; set; }
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<WorkEntity> WorkEntity { get; set; }
        public DbSet<RolePermissionEntity> RolePermissionEntity { get; set; }
        public DbSet<StateEntity> StateEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                   .HasIndex(b => b.Mail)
                   .IsUnique();

            modelBuilder.Entity<RolePermissionEntity>()
                .HasIndex(r => new { r.IdPermission, r.IdRol })
                .IsUnique();
        }
    }
}