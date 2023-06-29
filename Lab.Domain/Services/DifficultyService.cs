using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Difficulty;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class DifficultyService : IDifficultyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DifficultyService( IUnitOfWork unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public List<ConsultDifficulty> GetAll()
        {
            
            IEnumerable<DifficultyEntity> difficultyEntities = _unitOfWork.DifficultyEntity.GetAll();

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