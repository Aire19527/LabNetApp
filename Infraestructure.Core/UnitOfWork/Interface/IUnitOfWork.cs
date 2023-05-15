using Infraestructure.Core.Repository.Inerface;
using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<SkillEntity> SkillRepository { get; }



        void Dispose();
        Task<int> Save();

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
