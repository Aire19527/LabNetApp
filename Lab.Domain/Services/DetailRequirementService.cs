using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.DetailRequirement;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class DetailRequirementService : IDetailRequirementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailRequirementService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public DetailRequirementEntity GetDetailRequirement(DetailRequirementDto detailRequirementDto)
        {
            DetailRequirementEntity detailRequirementEntity = new DetailRequirementEntity()
            {
                IdSkill = detailRequirementDto.IdSkill,
                IdDifficulty = detailRequirementDto.IdDifficulty,
                QuantityQuestions = detailRequirementDto.QuantityQuestions,
            };

            return detailRequirementEntity;
        }


        public async Task<bool> Delete(int id)
        {
            DetailRequirementEntity detail = _unitOfWork.DetailRequirementRepository
                .FirstOrDefault(x => x.Id == id);

            if (detail == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.RequestRepository.Delete(detail);

            return await _unitOfWork.Save() > 0;
        }
    }
}
