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
            SkillEntity skill = new SkillEntity()
            {
                Description = dto.Description,

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
                IsVisible = x.IsVisible

            }).ToList();

            return skills;
        }

        public async Task<bool> Delete(int id)
        {
            SkillEntity? skillEntity = _unitOfWork.SkillRepository.FindAll((skill) => skill.Id == id).FirstOrDefault();
            if (skillEntity != null)
            {
                skillEntity.IsVisible = false;
                _unitOfWork.SkillRepository.Update(skillEntity);
                await _unitOfWork.Save();
                return true;
            }
            return false;
        }

        #endregion

    }
}
