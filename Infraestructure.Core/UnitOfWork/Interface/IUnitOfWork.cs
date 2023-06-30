using Infraestructure.Core.Repository.Inerface;
using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<SkillEntity> SkillRepository { get; }
        IRepository<RequestEntity> RequestRepository { get; }
        IRepository<UserEntity> UserRepository { get; }
        IRepository<RoleEntity> RoleRepository { get; }
        IRepository<ProfileEntity> ProfileRepository { get; }
        IRepository<ProfilesSkillsEntity> ProfilesSkillsRepository { get; }
        IRepository<WorkEntity> WorkRepository { get; }
        IRepository<JobPositionEntity> JobPositionRepository { get; }
        IRepository<EducationEntity> EducationRepository { get; }
        IRepository<InstitutionTypeEntity> InstitutionTypeRepository { get; }
        IRepository<WorkTypeEntity> WorkTypeRepository { get; }
        IRepository<UbicationEntity> UbicationRepository { get; }
        IRepository<SectorEntity> SectorRepository { get; }
        //ANSERS & QUESTIONS
        IRepository<QuestionEntity> QuestionRepository { get; }
        IRepository<AnswerEntity> AnswerRepository {  get; }
        IRepository<QuestionAnswerEntity> QuestionAnswerRepository { get; }
        IRepository<DifficultyEntity> DifficultyEntity { get; }
        //File
        IRepository<FileEntity> FileRepository { get; }
        void Dispose();
        Task<int> Save();

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}