using Common.Exceptions;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Difficulty;
using Lab.Domain.Services.Interfaces;

namespace Lab.Domain.Services
{
    public class DifficultyService : IDifficultyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DifficultyService( IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public List<ConsultDifficulty> GetAll()
        {
            
            IEnumerable<DifficultyEntity> difficultyEntities = _unitOfWork.DifficultyEntity.GetAll();

            if (difficultyEntities == null)
            {
                throw new BusinessException("No existe entidades");
            }

            List<ConsultDifficulty> consultDifficulties = difficultyEntities
                .Select(x => new ConsultDifficulty()
                {
                    id = x.Id,
                    Description = x.Description,
                    Value = x.Value
                }).ToList();

            return consultDifficulties;
        }
    }
}