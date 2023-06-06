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
        public async Task<bool> Insert(AddSkilDto add)
        {
            SkillEntity skill = new SkillEntity()
            {
                Description = add.Description,
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

            }).ToList();

            return skills;
        }
        #endregion

    }
}
