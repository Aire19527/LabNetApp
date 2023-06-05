using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.JobPosition;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class JobPositionServices : IJobPositionServices
    { 

        private readonly IUnitOfWork _unitOfWork;

    public JobPositionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        
        }
        public async Task<List<ConsultJobPositionDto>> Getall()
        {
            IEnumerable<JobPositionEntity> jobPositionEntities =
                _unitOfWork.JobPositionRepository.GetAllSelect();

            List<ConsultJobPositionDto> consultJobPositionDtos = jobPositionEntities
                .Select(j => new ConsultJobPositionDto()
                {
                    IdJobPosition = j.Id,
                    Description = j.Description,
                }).ToList();

            return consultJobPositionDtos;
        }

        public ConsultJobPositionDto GetById(int id)
        {
            JobPositionEntity jobPositionEntity = _unitOfWork.JobPositionRepository
                .FirstOrDefaultSelect(x => x.Id == id);

            if (jobPositionEntity == null)
            {
                throw new BusinessException(GeneralMessages.ItemNoFound);
            }

            ConsultJobPositionDto consultJobPositionDto = new ConsultJobPositionDto()
            {
                IdJobPosition = jobPositionEntity.Id,
                Description = jobPositionEntity.Description,
            };

            return consultJobPositionDto;
        }

        public async Task<bool> Insert(AddJobPositionDto add)
        {

            if ( add == null)
            {
                throw new BusinessException(GeneralMessages.ItemNoInserted);
            }
            JobPositionEntity jobPositionEntity = new JobPositionEntity()
            {
                Description = add.Description,
            };

            _unitOfWork.JobPositionRepository.Insert(jobPositionEntity);
            return await _unitOfWork.Save() > 0;
        }
    }
}
