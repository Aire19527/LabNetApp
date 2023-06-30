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
        public DbSet<UbicationEntity> UbicationEntity { get; set; }
        public DbSet<SectorEntity> SectorEntity { get; set; }
        public DbSet<WorkTypeEntity> WorkTypeEntity { get; set; }
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
        public DbSet<QuestionEntity> QuestionsEntity { get; set; }
        public DbSet<AnswerEntity> AnswersEntity { get; set; }
        public DbSet<FileEntity> FilesEntities { get; set; }
        public DbSet<DifficultyEntity> DifficultyEntity { get; set; }

        public DbSet<RequestEntity> RequestEntity { get; set; }

        public DbSet<AssessmentUserEntity> AssessmentUserEntity { get; set; }
        public DbSet<AssessmentQuestionEntity> AssessmentQuestionEntity { get; set; }
        public DbSet<AssessmentQuestionAnswerEntity> AssessmentQuestionAnswerEntity { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                   .HasOne(u => u.ProfileEntity)
                   .WithOne(p => p.UserEntity)
                   .HasForeignKey<ProfileEntity>(p => p.IdUser);


            modelBuilder.Entity<FileEntity>()
                   .HasOne(q => q.QuestionEntity)
                   .WithOne(f => f.FileEntity)
                   .HasForeignKey<QuestionEntity>(q => q.IdFile);

            modelBuilder.Entity<FileEntity>()
                   .HasOne(a => a.AnswerEntity)
                   .WithOne(f => f.FileEntity)
                   .HasForeignKey<AnswerEntity>(a => a.IdFile);

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

            modelBuilder.Entity<RequirementQuestionEntity>()
               .HasIndex(x => new
               {
                   x.IdQuestion,
                   x.IdRequest
               })
               .IsUnique();
            modelBuilder.Entity<ProfileCertificationEntity>()
               .HasIndex(x => new
               {
                   x.IdProfile,
                   x.IdCertification
               })
               .IsUnique();

              

            modelBuilder.Entity<CountryEntity>().Property(c => c.Id).ValueGeneratedNever();
            modelBuilder.Entity<ProvinceEntity>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<CityEntity>().Property(c => c.Id).ValueGeneratedNever();
            modelBuilder.Entity<RoleEntity>().Property(r => r.Id).ValueGeneratedNever();
        }
    }
}