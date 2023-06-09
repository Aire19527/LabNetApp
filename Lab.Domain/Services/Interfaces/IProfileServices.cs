﻿using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.ProfileImage;
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

        Task<List<ConsultProfileDto>> Getall();

        Task<bool> Update(ModifyProfileDto update);

        Task<bool> AddSkillToProfile(AddProfileSkillDto profileSkill);

        Task<bool> DeleteSkillToProfile(int idProfile, int idSkill);

        ConsultProfileDto GetById(int id);
        Task<string> UpdateFile(ProfileFileDto updateFile, bool isImg);

        IEnumerable<ProfilesDto> FilterBySkill(List<int> skills);

        IEnumerable<ConsultSkllDto> GetProfileSkill(int id);

        bool HasProfile(int idUser);
    }
}
