using Infraestructure.Core.Repository.Inerface;
using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<SkillEntity> SkillRepository { get; }
        IRepository<UserEntity> UserRepository { get; }
        IRepository<RoleEntity> RoleRepository { get; }
        IRepository<ProfileEntity> ProfileRepository { get; }
        IRepository<ProfilesSkillsEntity> ProfilesSkillsRepository { get; }
        IRepository<WorkEntity> WorkRepository { get; }
        IRepository<JobPositionEntity> JobPositionRepository { get; }

        void Dispose();
        Task<int> Save();

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
