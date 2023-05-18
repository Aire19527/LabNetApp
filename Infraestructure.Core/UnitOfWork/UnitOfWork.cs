using Infraestructure.Core.Context;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Inerface;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Attibutes
        private readonly DataContext _context;
        private bool disposed = false;


        #endregion


        #region MyRegion
        public UnitOfWork(DataContext dataContext)
        {
            _context = dataContext;
        }
        #endregion

        #region Properties
        private IRepository<SkillEntity> skillRepository;
        private IRepository<ProfileEntity> profileRepository;
        private IRepository<ProfilesSkillsEntity> profileSkillRepository;
        #endregion

        #region Members


        public IRepository<SkillEntity> SkillRepository
        {
            get
            {
                if (this.skillRepository == null)
                    this.skillRepository = new Repository<SkillEntity>(_context);

                return skillRepository;
            }
        }

        public IRepository<ProfileEntity> ProfileRepository
        {
            get
            {
                if (this.profileRepository == null)
                    this.profileRepository = new Repository<ProfileEntity>(_context);
                return profileRepository;
            }
        }

        public IRepository<ProfilesSkillsEntity> ProfilesSkillsRepository
        {
            get
            {
                if (this.profileSkillRepository == null)
                    this.profileSkillRepository = new Repository<ProfilesSkillsEntity>(_context);

                return profileSkillRepository;
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
        #endregion



        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();


    }

}
