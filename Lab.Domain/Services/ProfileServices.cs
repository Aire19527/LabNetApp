using Common.Exceptions;
using Common.Helpers;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Education;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.ProfileImage;
using Lab.Domain.Dto.ProfileSkill;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Dto.Work;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Lab.Domain.Services
{
    public class ProfileServices : IProfileServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        #endregion

        #region Builder
        public ProfileServices(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }
        #endregion

        #region Methods

        public async Task<List<ConsultProfileDto>> Getall()
        {
            IEnumerable<ProfileEntity> ProfileList = _unitOfWork.ProfileRepository.GetAllSelect(x => x.AdressEntity,
                                                                                                d => d.DniTypeEntity,
                                                                                                w => w.WorkEntity,
                                                                                                e => e.EducationEntity.Select(x => x.InstitutionTypeEntity)
                                                                                                );

            List<ConsultProfileDto> profiles = ProfileList.Select(p => new ConsultProfileDto()
            {
                IdUser = p.Id,
                Description = p.Description,
                LastName = p.LastName,
                Name = p.Name,
                Mail = p.Mail,
                DNI = p.DNI,
                CV = _fileService.getResumee(p.CV),
                Photo = _fileService.getImage(p.Photo),
                Phone = p.Phone,
                BirthDate = p.BirthDate,
                IdAdress = p.AdressEntity?.Id,
                AdressDescription = p.AdressEntity?.Description,
                IdDniType = p.DniTypeEntity?.id,

                WorkEntities = p.WorkEntity.Select(x => new WorkDto()
                {
                    Id = x.Id,
                    Company = x.Company,
                    Role = x.Role,
                }).ToList(),

                EducationEntities = p.EducationEntity.Select(x => new EducationDto()
                {
                    Id = x.Id,
                    Degree = x.Degree,
                    InstitutionName = x.InstitutionName,
                    AdmissionDate = x.AdmissionDate,
                    ExpeditionDate = x.ExpeditionDate,
                    IdInstitutionType = x.IdInstitutionType,
                    DescriptionInstitutionType = x.InstitutionTypeEntity.Description
                }).ToList()

            }).ToList();

            return profiles;
        }

        public ConsultProfileDto GetById(int id)
        {
            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefaultSelect(x => x.IdUser == id,
                                                                                a => a.AdressEntity,
                                                                                d => d.DniTypeEntity,
                                                                                w => w.WorkEntity.Select(x => x.SectorEntity),
                                                                                w => w.WorkEntity.Select(x => x.UbicationEntity),
                                                                                w => w.WorkEntity.Select(x => x.JobPositionEntity),
                                                                                w => w.WorkEntity.Select(x => x.WorkTypeEntity),
                                                                                e => e.EducationEntity.Select(x => x.InstitutionTypeEntity)
                                                                                );


            if (profile == null)
                throw new BusinessException("El id no existe");

            ConsultProfileDto consultProfileDto = new ConsultProfileDto()
            {
                IdUser = profile.IdUser,
                IdProfile = profile.Id,
                Description = profile.Description,
                LastName = profile.LastName,
                Name = profile.Name,
                Mail = profile.Mail,
                DNI = profile.DNI,
                CV = _fileService.getResumee(profile.CV),
                Photo = _fileService.getImage(profile.Photo),
                Phone = profile.Phone,
                BirthDate = profile.BirthDate,
                IdAdress = profile.AdressEntity?.Id,
                AdressDescription = profile.AdressEntity?.Description,
                IdDniType = profile.DniTypeEntity?.id,
                DniDescrption = profile.DniTypeEntity?.Description,

                WorkEntities = profile.WorkEntity.Select(x => new WorkDto()
                {
                    Id = x.Id,
                    Company = x.Company,
                    Role = x.Role,
                    IdSector = x.SectorEntity.Id,
                    DescriptionSector = x.SectorEntity.Description,
                    IdUbication = x.UbicationEntity.Id,
                    DescriptionUbication = x.UbicationEntity.Description,
                    IdJobPosition = x.JobPositionEntity.Id,
                    DescriptionJobPosition = x.JobPositionEntity.Description,
                    IdWorkType = x.WorkTypeEntity.Id,
                    DescriptionWorkType = x.WorkTypeEntity.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                }).ToList(),

                EducationEntities = profile.EducationEntity.Select(x => new EducationDto()
                {
                    Id = x.Id,
                    Degree = x.Degree,
                    InstitutionName = x.InstitutionName,
                    AdmissionDate = x.AdmissionDate,
                    ExpeditionDate = x.ExpeditionDate,
                    IdInstitutionType = x.IdInstitutionType,
                    DescriptionInstitutionType = x.InstitutionTypeEntity.Description
                }).ToList()
            };

            return consultProfileDto;
        }

        public bool HasProfile(int idUser)
        {
            bool result;
            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefaultSelect(x => x.IdUser == idUser);

            if (profile == null)
                result = false;

            else result = true;

            return result;
        }   

        public async Task<bool> Insert(AddProfileDto add)
        {
            string urlImg = String.Empty;
            if (add.FileImage != null)
                urlImg = _fileService.UploadFile(add.FileImage, isImg: true);

            ProfileEntity profile = new ProfileEntity()
            {
                IdUser = add.IdUser,
                Name = add.Name,
                LastName = add.LastName,
                DNI = add.DNI,
                BirthDate = add.BirthDate,
                Mail = add.Mail,
                Photo = urlImg
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

                _unitOfWork.ProfileRepository.Update(profile);

                return await _unitOfWork.Save() > 0;
            }
            return false;
        }
        public async Task<string> UpdateFile(ProfileFileDto updateFile, bool isImg)
        {
            string urlFile = string.Empty;


            if (updateFile.File != null)
                urlFile = _fileService.UploadFile(updateFile.File, isImg);
            else throw new BusinessException("El archivo es requerido");


            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefault(x => x.IdUser == updateFile.Id);

            if (isImg)
            {
                if (!string.IsNullOrEmpty(profile.Photo))
                    _fileService.DeleteFile(profile.Photo);

                profile.Photo = urlFile;
            }

            else
            {
                if (!string.IsNullOrEmpty(profile.CV))
                    _fileService.DeleteFile(profile.CV);

                profile.CV = urlFile;

            }

            _unitOfWork.ProfileRepository.Update(profile);

            await _unitOfWork.Save();
            return urlFile;

        }

        #endregion

        #region ProfileSkill

        public async Task<bool> AddSkillToProfile(AddProfileSkillDto profileSkill)
        {
            if (profileSkill.IdProfile == null || profileSkill.IdSkill == null)
                throw new BusinessException("No se ha indicado skill o perfil.");

            ProfileEntity Profile = _unitOfWork.ProfileRepository.FirstOrDefault(x => x.Id == profileSkill.IdProfile);
            SkillEntity Skill = _unitOfWork.SkillRepository.FirstOrDefault(x => x.Id == profileSkill.IdSkill);

            if (Profile == null || Skill == null)
                throw new BusinessException("Perfil o skill no existente.");


            _unitOfWork.ProfilesSkillsRepository.Insert(new ProfilesSkillsEntity()
            {
                IdProfile = profileSkill.IdProfile,
                IdSkill = profileSkill.IdSkill
            });

            return await _unitOfWork.Save() > 0;
        }
        public async Task<bool> DeleteSkillToProfile(int idProfile, int idSkill)
        {
            if (idProfile == null || idSkill == null)
                throw new BusinessException("No se ha indicado skill o perfil.");

            ProfilesSkillsEntity? ProfilesSkills = _unitOfWork.ProfilesSkillsRepository.FirstOrDefault(p => p.IdProfile == idProfile &&
                                                                                        p.IdSkill == idSkill);

            if (ProfilesSkills == null)
                throw new BusinessException();

            _unitOfWork.ProfilesSkillsRepository.Delete(ProfilesSkills);


            return await _unitOfWork.Save() > 0;
        }

        public IEnumerable<ProfilesDto> FilterBySkill(List<int> skills)
        {
            if (skills.Count() == 0)
                throw new BusinessException("No hay skills para filtrar.");

            List<ProfilesSkillsEntity> perfilSkills = _unitOfWork.ProfilesSkillsRepository.FindAll(
                                                                            x => skills.Any(s => s.Equals(x.IdSkill)),
                                                                            p => p.ProfileEntity).ToList();

            IEnumerable<ProfilesDto> profiles = (
                                from p in perfilSkills.ToList()
                                group p by p.IdProfile into perf
                                where perf.Count() == skills.Count()
                                select new ProfilesDto
                                {
                                    Profile = perf.Select(x => new ProfileDto
                                    {
                                        Id = x.ProfileEntity.Id,
                                        IdUser = x.ProfileEntity.IdUser,
                                        Name = x.ProfileEntity.Name,
                                        LastName = x.ProfileEntity.LastName,
                                        Mail = x.ProfileEntity.Mail,
                                        Phone = x.ProfileEntity.Phone,
                                        Works = (GetWork(x.ProfileEntity.Id)),
                                        Skill = (GetProfileSkill(x.ProfileEntity.Id)),
                                    }).FirstOrDefault(),
                                    Key = perf.Key,
                                    Count = perf.Select(x => x.IdSkill).Count()
                                }).ToList();
            return profiles;
        }


        public IEnumerable<ConsultSkllDto> GetProfileSkill(int id)
        {

            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefaultSelect(x => x.Id == id,
                                                                               r => r.ProfilesSkillsEntity.Select(e => e.SkillEntity));

            if (profile == null)
                throw new BusinessException("No existe el perfil seleccinado");

            IEnumerable<ConsultSkllDto> listSkill = profile.ProfilesSkillsEntity.Select(x => new ConsultSkllDto
            {
                Id = x.SkillEntity.Id,
                Description = x.SkillEntity.Description,
                IsVisible = x.SkillEntity.IsVisible,
            }).ToList();

            return listSkill;
        }
        public IEnumerable<WorkDto> GetWork(int id)
        {

            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefaultSelect(x => x.Id == id,
                                                                                        w => w.WorkEntity.Select(x => x.SectorEntity),
                                                                                        w => w.WorkEntity.Select(x => x.UbicationEntity),
                                                                                        w => w.WorkEntity.Select(x => x.WorkTypeEntity)
                                                                                        );
            if (profile == null)
                throw new BusinessException("No existe el perfil seleccinado");

            IEnumerable<WorkDto> workEntities = profile.WorkEntity.Select(x => new WorkDto
            {
                Id = x.Id,
                Company = x.Company,
                Role = x.Role,
                IdSector = x.SectorEntity.Id,
                DescriptionSector = x.SectorEntity.Description,
                DescriptionUbication = x.UbicationEntity.Description,
                DescriptionWorkType = x.WorkTypeEntity.Description
            }).ToList();

            return workEntities;
        }

        #endregion
    }
}