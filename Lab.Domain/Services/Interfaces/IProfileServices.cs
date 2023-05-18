using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.ProfileSkill;
using Lab.Domain.Dto.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IProfileServices
    {
        Task<bool> Insert(AddProfileDto add);

        List<ConsultProfileDto> Getall();

        Task<bool> Update(ModifyProfileDto update);

        ConsultProfileDto GetById(int id);
        Task<bool> AddSkillToProfile(AddProfileSkillDto profileSkill);

    }
}
