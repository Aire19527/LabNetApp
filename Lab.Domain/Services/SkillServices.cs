﻿using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Services.Interfaces;

namespace Lab.Domain.Services
{
    public class SkillServices : ISkillServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public SkillServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Methods
        public async Task<bool> Insert(AddSkilDto dto)
        {
            if (_unitOfWork.SkillRepository.FirstOrDefault(x => x.Description.Equals(dto.Description)) != null)
                throw new BusinessException("No se puede insertar un registro duplicado");

            SkillEntity skill = new SkillEntity()
            {
                Description = dto.Description,
                IsVisible = true,
            };
            _unitOfWork.SkillRepository.Insert(skill);

            return await _unitOfWork.Save() > 0;
        }

        public List<ConsultSkllDto> Getall()
        {
            IEnumerable<SkillEntity> skillList = _unitOfWork.SkillRepository.GetAll();

            List<ConsultSkllDto> skills = skillList.Select(x => new ConsultSkllDto()
            {
                Id = x.Id,
                Description = x.Description,
                IsVisible = x.IsVisible

            }).ToList().FindAll((skill) => skill.IsVisible == true);

            return skills;
        }

        public async Task<bool> Delete(int id)
        {
            SkillEntity? skillEntity = _unitOfWork.SkillRepository.FirstOrDefault((skill) => skill.Id == id);

            if (skillEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.SkillRepository.Delete(skillEntity);

            return await _unitOfWork.Save() > 0;
        }

        #endregion

    }
}
