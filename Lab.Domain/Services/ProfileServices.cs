using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.ProfileSkill;
using Lab.Domain.Dto.ProfileWork;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Dto.Work;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class ProfileServices : IProfileServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public ProfileServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region MethodsEmi-Salva

        public async Task<List<ConsultProfileDto>> Getall()
        {
            IEnumerable<ProfileEntity> ProfileList = _unitOfWork.ProfileRepository.GetAllSelect(x => x.AdressEntity,
                                                                                                j => j.JobPositionEntity,
                                                                                                d => d.DniTypeEntity,
                                                                                                r => r.ProfileWorkEntity,
                                                                                                r => r.ProfileWorkEntity.Select(e => e.WorkEntity)
                                                                                               );
            List<ConsultProfileDto> profiles = ProfileList.Select(p => new ConsultProfileDto()
            {
                IdUser = p.IdUser,
                Description = p.Description,
                LastName = p.LastName,
                Name = p.Name,
                Mail = p.Mail,
                DNI = p.DNI,
                CV = p.CV,
                Photo = p.Photo,
                Phone = p.Phone,
                BirthDate = p.BirthDate,
                IdAdress = p.AdressEntity?.Id,
                AdressDescription = p.AdressEntity?.Description,
                IdJobPosition = p.JobPositionEntity?.Id,
                JobPositionDescription = p.JobPositionEntity?.Description,
                IdDniType = p.DniTypeEntity?.id,
                DniDescrption = p.JobPositionEntity?.Description,
                workEntities = p.ProfileWorkEntity.Select(x => new WorkDto
                {
                    Id = x.WorkEntity.Id,
                    Company = x.WorkEntity.Company,
                    Role = x.WorkEntity.Role
                }).ToList(),

            }).ToList();

            return profiles;
        }

        public ConsultProfileDto GetById(int id)
        {
            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefaultSelect(x => x.IdUser == id,
                                                                                a => a.AdressEntity,
                                                                                j => j.JobPositionEntity,
                                                                                d => d.DniTypeEntity,
                                                                                r => r.ProfileWorkEntity.Select(e => e.WorkEntity));

            if (profile == null)
                throw new Exception("No existe el perfil seleccinado");

            ConsultProfileDto consultProfileDto = new ConsultProfileDto()
            {
                IdUser = profile.IdUser,
                Description = profile.Description,
                LastName = profile.LastName,
                Name = profile.Name,
                Mail = profile.Mail,
                DNI = profile.DNI,
                CV = profile.CV,
                Photo = profile.Photo,
                Phone = profile.Phone,
                BirthDate = profile.BirthDate,
                IdAdress = profile.AdressEntity?.Id,
                AdressDescription = profile.AdressEntity?.Description,
                IdJobPosition = profile.JobPositionEntity?.Id,
                JobPositionDescription = profile.JobPositionEntity?.Description,
                IdDniType = profile.DniTypeEntity?.id,
                DniDescrption = profile.DniTypeEntity?.Description,
                workEntities = profile.ProfileWorkEntity.Select(x => new WorkDto
                {
                    Id = x.WorkEntity.Id,
                    Company = x.WorkEntity.Company,
                    Role = x.WorkEntity.Role
                }).ToList(),
            };

            return consultProfileDto;
        }

        public async Task<bool> Insert(AddProfileDto add)
        {
            ProfileEntity profile = new ProfileEntity()
            {
                IdUser = add.IdUser,
                Name = add.Name,
                LastName = add.LastName,
                DNI = add.DNI,
                BirthDate = add.BirthDate,
                Mail = add.Mail
            };
            _unitOfWork.ProfileRepository.Insert(profile);

            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> Update(ModifyProfileDto update)
        {
            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefault(x => x.IdUser == update.IdUser);
            if (profile != null)
            {

                profile.Description = update.Description;
                profile.Phone = update.Phone;
                profile.CV = update?.CV;
                profile.Photo = update.Photo;
                profile.IdAdress = update.IdAdress;
                profile.IdJobPosition = update.IdJobPosition;



                _unitOfWork.ProfileRepository.Update(profile);

                return await _unitOfWork.Save() > 0;
            }
            return false;
        }

        public async Task<bool> AddWorkProfile(AddProfileWorkDto addProfileWorkDto)
        {
            ProfileEntity Profile = _unitOfWork.ProfileRepository.FirstOrDefault(x => x.Id == addProfileWorkDto.IdProfile);
            WorkEntity Work = _unitOfWork.WorkRepository.FirstOrDefault(x => x.Id == addProfileWorkDto.IdWork);

            if (Profile != null && Work != null)
            {
                _unitOfWork.ProfilesWorkRepository.Insert(new ProfileWorkEntity()
                {
                    IdProfile = addProfileWorkDto.IdProfile,
                    IdWork = addProfileWorkDto.IdWork
                });
            }

            return await _unitOfWork.Save() > 0;
        }

        #endregion

        #region Nico-benja

        public async Task<bool> AddSkillToProfile(AddProfileSkillDto profileSkill)
        {
            ProfileEntity Profile = _unitOfWork.ProfileRepository.FirstOrDefault(x => x.Id == profileSkill.IdProfile);
            SkillEntity Skill = _unitOfWork.SkillRepository.FirstOrDefault(x => x.Id == profileSkill.IdSkill);

            if (Profile != null && Skill != null)
            {
                _unitOfWork.ProfilesSkillsRepository.Insert(new ProfilesSkillsEntity()
                {
                    IdProfile = profileSkill.IdProfile,
                    IdSkill = profileSkill.IdSkill
                });

            }

            return await _unitOfWork.Save() > 0;
        }
        public async Task<bool> DeleteSkillToProfile(AddProfileSkillDto profileSkill)
        {
            ProfilesSkillsEntity? ProfilesSkills = _unitOfWork.ProfilesSkillsRepository.FindAll( p => p.IdProfile == profileSkill.IdProfile && 
                                                                                        p.IdSkill == profileSkill.IdSkill).FirstOrDefault();

            if (ProfilesSkills != null)
            {
                _unitOfWork.ProfilesSkillsRepository.Delete(ProfilesSkills);
            }

            return await _unitOfWork.Save() > 0;
        }

        public IEnumerable<ProfilesDto> FilterBySkill(List<int> skills)
        {
            if (skills.Count() == 0)
                return null;

            IEnumerable<ProfilesSkillsEntity> perfilSkills = _unitOfWork.ProfilesSkillsRepository.FindAll(x => skills.Any(s => s == x.IdSkill), p => p.ProfileEntity); 

            IEnumerable<ProfilesDto> profiles = (
                                from p in perfilSkills 
                                group p by p.IdProfile into perf
                                where perf.Count() == skills.Count()
                                select new ProfilesDto 
                                { 
                                    Profile = perf.Select(x => new ProfileDto
                                    {
                                        IdUser = x.ProfileEntity.Id,
                                        Name = x.ProfileEntity.Name,
                                        LastName = x.ProfileEntity.LastName,
                                        Mail = x.ProfileEntity.Mail,
                                    }).
                                    FirstOrDefault(),
                                    Key = perf.Key,
                                    Count = perf.Select(x => x.IdSkill)
                                    .Count()
                                }).ToList();

            return profiles;
        }
        #endregion
    }
}