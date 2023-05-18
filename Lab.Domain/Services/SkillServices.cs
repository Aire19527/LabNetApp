﻿using Infraestructure.Core.UnitOfWork.Interface;
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
        public async Task<bool> Insert(AddSkilDto add)
        {
            SkillEntity skill = new SkillEntity()
            {
                Description = add.Description,
                IsVisible = true
            };
            _unitOfWork.SkillRepository.Insert(skill);

            return await _unitOfWork.Save() > 0;
        }

        public List<ConsultSkllDto> Getall()
        {
            IEnumerable<SkillEntity> skillList = _unitOfWork.SkillRepository.FindAll((skill) => skill.IsVisible == true);

            

            List<ConsultSkllDto> skills = skillList.Select(x => new ConsultSkllDto()
            {
                Id = x.Id,
                Description = x.Description,

            }).ToList();

            return skills;
        }

        
        public async Task Delete(int id)
        {
            SkillEntity? skillEntity = _unitOfWork.SkillRepository.FindAll((skill) => skill.Id == id).FirstOrDefault();
            if (skillEntity != null)
            {
                skillEntity.IsVisible = false;
                _unitOfWork.SkillRepository.Update(skillEntity);
                await _unitOfWork.Save();
            }
        }

        #endregion

    }
}
