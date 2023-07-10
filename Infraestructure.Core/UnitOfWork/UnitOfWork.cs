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
        private IRepository<UserEntity> userRepository;
        private IRepository<RoleEntity> roleRepository;
        private IRepository<ProfileEntity> profileRepository;
        private IRepository<ProfilesSkillsEntity> profileSkillRepository;
        private IRepository<WorkEntity> workRepository;
        private IRepository<JobPositionEntity> jobPositionRepository;
        private IRepository<EducationEntity> educationRepository;
        private IRepository<InstitutionTypeEntity> institutionTypeRepository;
        private IRepository<WorkTypeEntity> workTypeRepository;
        private IRepository<UbicationEntity> ubicationRepository;
        private IRepository<SectorEntity> sectorRepository;
        private IRepository<AnswerEntity> answerRepository;
        private IRepository<QuestionEntity> questionRepository;
        private IRepository<FileEntity> fileRepository;
        private IRepository<QuestionAnswerEntity> questionAnswerRepository;
        private IRepository<DifficultyEntity> difficultyRepository;
        private IRepository<RequestEntity> requestRepository;
        private IRepository<DetailRequirementEntity> detailRequirementRepository;
        private IRepository<AssessmentUserEntity> assessmentUserRepository;
        private IRepository<RequirementQuestionEntity> requirementQuestionRepository;

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

        public IRepository<WorkTypeEntity> WorkTypeRepository
        {
            get
            {
                if (this.workTypeRepository == null)
                    this.workTypeRepository = new Repository<WorkTypeEntity>(_context);

                return workTypeRepository;
            }
        }


        public IRepository<UserEntity> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new Repository<UserEntity>(_context);

                return userRepository;
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

        public IRepository<WorkEntity> WorkRepository
        {
            get
            {
                if (this.workRepository == null)
                    this.workRepository = new Repository<WorkEntity>(_context);

                return workRepository;
            }
        }

        public IRepository<RoleEntity> RoleRepository
        {


            get
            {
                if (this.roleRepository == null)
                    this.roleRepository = new Repository<RoleEntity>(_context);

                return roleRepository;

            }
        }

        public IRepository<JobPositionEntity> JobPositionRepository
        {
            get
            {
                if (this.jobPositionRepository == null)
                    this.jobPositionRepository = new Repository<JobPositionEntity>(_context);

                return jobPositionRepository;
            }
        }



        public IRepository<EducationEntity> EducationRepository
        {
            get
            {
                if (this.educationRepository == null)
                    this.educationRepository = new Repository<EducationEntity>(_context);

                return educationRepository;
            }
        }

        public IRepository<InstitutionTypeEntity> InstitutionTypeRepository
        {
            get
            {
                if (this.institutionTypeRepository == null)
                    this.institutionTypeRepository = new Repository<InstitutionTypeEntity>(_context);

                return institutionTypeRepository;
            }
        }


        public IRepository<UbicationEntity> UbicationRepository
        {
            get
            {
                if (this.ubicationRepository == null)
                    this.ubicationRepository = new Repository<UbicationEntity>(_context);

                return ubicationRepository;
            }

        }

        public IRepository<SectorEntity> SectorRepository
        {
            get {  
                if (this.sectorRepository == null)
                    this.sectorRepository = new Repository<SectorEntity>(_context);

                return sectorRepository;
            }
        }

        public IRepository<QuestionEntity> QuestionRepository
        {
            get
            {
                if (this.questionRepository == null)
                {
                    this.questionRepository = new Repository<QuestionEntity>(_context);
                }
                return questionRepository;
            }
        }

        public IRepository<AnswerEntity> AnswerRepository
        {
            get
            {
                if (this.answerRepository == null)
                {
                    this.answerRepository = new Repository<AnswerEntity>(_context);
                }
                return answerRepository;
            }
        }

        public IRepository<FileEntity> FileRepository
        {
            get
            {
                if (this.fileRepository == null)
                {
                    this.fileRepository = new Repository<FileEntity>(_context);
                }
                return fileRepository;
            }
        }

        public IRepository<QuestionAnswerEntity> QuestionAnswerRepository
        {
            get
            {
                if (this.questionAnswerRepository == null)
                {
                    this.questionAnswerRepository = new Repository<QuestionAnswerEntity>(_context);
                }
                return questionAnswerRepository;
            }
        }

        public IRepository<DifficultyEntity> DifficultyEntity
        {
            get
            {
                if (this.difficultyRepository == null)
                {
                    this.difficultyRepository = new Repository<DifficultyEntity>(_context);
                }
                return difficultyRepository;
            }
        }

        public IRepository<RequestEntity> RequestRepository
        {
            get
            {
                if (this.requestRepository == null)
                {
                    this.requestRepository = new Repository<RequestEntity>(_context);
                }
                return requestRepository;
            }
        }

        public IRepository<DetailRequirementEntity> DetailRequirementRepository
        {
            get
            {
                if (this.detailRequirementRepository == null)
                {
                    this.detailRequirementRepository = new Repository<DetailRequirementEntity>(_context);
                }
                return detailRequirementRepository;
            }
        }

        public IRepository<AssessmentUserEntity> AssessmentUserRepository

        {
            get
            {
                if (this.assessmentUserRepository == null)
                {
                    this.assessmentUserRepository = new Repository<AssessmentUserEntity>(_context);
                }
                return assessmentUserRepository;
            }
        }

        public IRepository<RequirementQuestionEntity> RequirementQuestionRepository
        {
            get
            {
                if (this.requirementQuestionRepository == null)
                {
                    this.requirementQuestionRepository = new Repository<RequirementQuestionEntity>(_context);
                }
                return requirementQuestionRepository;
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