using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Education;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.ProfileSkill;
using Lab.Domain.Dto.ProfileWork;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Dto.Work;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public ProfileServices(IUnitOfWork unitOfWork , IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }
        #endregion


        #region MethodsEmi-Salva

        public async Task<List<ConsultProfileDto>> Getall()
        {
            IEnumerable<ProfileEntity> ProfileList = _unitOfWork.ProfileRepository.GetAllSelect(x => x.AdressEntity,
                                                                                                j => j.JobPositionEntity,
                                                                                                d => d.DniTypeEntity,
                                                                                                //r => r.ProfileWorkEntity,
                                                                                                r => r.ProfileWorkEntity.Select(e => e.WorkEntity),
                                                                                                e => e.ProfileEducationEntity.Select(b => b.EducationEntity.InstitutionTypeEntity));
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
                WorkEntities = p.ProfileWorkEntity.Select(x => new WorkDto
                { 
                    Id = x.WorkEntity.Id,
                    Company = x.WorkEntity.Company,
                    Role = x.WorkEntity.Role
                } ).ToList(),

                EducationEntities = p.ProfileEducationEntity.Select(x => new EducationDto
                {
                    Id = x.EducationEntity.Id,
                    InstitutionName = x.EducationEntity.InstitutionName,
                    Degree = x.EducationEntity.Degree,
                    AdmissionDate = x.EducationEntity.AdmissionDate,
                    ExpeditionDate = x.EducationEntity.ExpeditionDate,
                    IdInstitutionType = x.EducationEntity.InstitutionTypeEntity.Id,
                    DescriptionInstitutionType = x.EducationEntity.InstitutionTypeEntity.Description
                    
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
                                                                                r => r.ProfileWorkEntity.Select(e => e.WorkEntity),
                                                                                e => e.ProfileEducationEntity.Select(b => b.EducationEntity));

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

                WorkEntities = profile.ProfileWorkEntity.Select(x => new WorkDto
                {
                    Id = x.WorkEntity.Id,
                    Company = x.WorkEntity.Company,
                    Role = x.WorkEntity.Role
                }).ToList(),
                EducationEntities = profile.ProfileEducationEntity.Select(x => new EducationDto
                {
                    Id = x.EducationEntity.Id,
                    InstitutionName = x.EducationEntity.InstitutionName,
                    Degree = x.EducationEntity.Degree,
                    AdmissionDate = x.EducationEntity.AdmissionDate,
                    ExpeditionDate = x.EducationEntity.ExpeditionDate,
                    IdInstitutionType = x.EducationEntity.IdInstitutionType,
                    DescriptionInstitutionType = x.EducationEntity.InstitutionTypeEntity.Description
                }).ToList()

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
                profile.CV = update.CV;
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

        //  ======== IMAGE-RELATED STUFF ========= 
        public string getImage(string img)
        {
            string path = string.Empty;
            if (string.IsNullOrEmpty(img))
            {
                path = $"/{_config.GetSection("PathFiles").GetSection("NoImage").Value}";
            }
            else
            {
                path = $"/{img}";
            }
            return path;
        }

        //private string UploadImage(IFormFile fileImage)
        //{
        //    if (fileImage.Length > 3000000)
        //        throw new Exception("The file size is too big!: [max 3 MB]");
        //}


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
        #endregion
    }
}