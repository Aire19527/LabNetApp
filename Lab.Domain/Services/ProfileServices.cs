using Common.Exceptions;
using Common.Helpers;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Education;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.ProfileImage;
using Lab.Domain.Dto.ProfileSkill;
using Lab.Domain.Dto.ProfileWork;
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
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Builder
        public ProfileServices(IUnitOfWork unitOfWork, IConfiguration config,
            IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _webHostEnvironment = webHostEnvironment;
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
                CV = getResumee(p.CV),
                Photo = getImage(p.Photo),
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
                }).ToList(),

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
                throw new BusinessException("El id no existe");

            ConsultProfileDto consultProfileDto = new ConsultProfileDto()
            {
                IdUser = profile.IdUser,
                Description = profile.Description,
                LastName = profile.LastName,
                Name = profile.Name,
                Mail = profile.Mail,
                DNI = profile.DNI,
                CV = getResumee(profile.CV),
                Photo = getImage(profile.Photo),
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
            string urlImg = String.Empty;
            if (add.FileImage != null)
                urlImg = UploadImage(add.FileImage);

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
                profile.IdJobPosition = update.IdJobPosition;

                _unitOfWork.ProfileRepository.Update(profile);

                return await _unitOfWork.Save() > 0;
            }
            return false;
        }
        //  ======== IMAGE-RELATED STUFF ========= 
        public string getImage(string? img)
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

        private string UploadImage(IFormFile fileImage)
        {

            if (fileImage.Length > 3000000)
                throw new BusinessException("The file size is too big!: [max 3 MB]");

            //Comprobar que el archivo sea una imagen
            string extension = Path.GetExtension(fileImage.FileName);

            if (!FileHelper.ValidExtension(extension, true))
                throw new BusinessException("Extension invalida");

            string path = $"{_config.GetSection("PathFiles").GetSection("ProfilePicture").Value}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            string uploads = Path.Combine(_webHostEnvironment.WebRootPath, path);
            string uniqueFileName = FileHelper.GetUniqueFileName(fileImage.FileName);
            string pathFinal = $"{uploads}/{uniqueFileName}";

            using (var stream = new FileStream(pathFinal, FileMode.Create))
            {
                fileImage.CopyTo(stream);
            }

            return $"{path}/{uniqueFileName}";
        }


        public async Task<string> UpdateImage(ProfileFileDto updateImage)
        {
            string urlImage = string.Empty;


            if (updateImage.File != null)
                urlImage = UploadImage(updateImage.File);
            else throw new BusinessException("La img es requerida");


            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefault(x => x.IdUser == updateImage.Id);

            if (!string.IsNullOrEmpty(profile.Photo))
            {
                DeleteFile(profile.Photo);
            }

            profile.Photo = urlImage;


            _unitOfWork.ProfileRepository.Update(profile);

            await _unitOfWork.Save();
            return urlImage;

        }


        public void DeleteFile(string path)
        {
            string pathFull = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }


        // ============ CV - RELATED STUFF ==================
        public string getResumee(string? resumee)
        {
            string path = string.Empty;
            if (string.IsNullOrEmpty(resumee))
            {
                path = "";
            }
            else
            {
                path = $"/{resumee}";
            }
            return path;
        }

        private string UploadResumee(IFormFile resumeeFile)
        {

            if (resumeeFile.Length > 3000000)
                throw new BusinessException("The file size is too big!: [max 3 MB]");

            //Comprobar que el archivo sea una imagen
            string extension = Path.GetExtension(resumeeFile.FileName);

            if (!FileHelper.ValidExtension(extension, false))
                throw new BusinessException("Extension invalida");

            string path = $"{_config.GetSection("PathFiles").GetSection("resumee").Value}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            string uploads = Path.Combine(_webHostEnvironment.WebRootPath, path);
            string uniqueFileName = FileHelper.GetUniqueFileName(resumeeFile.FileName);
            string pathFinal = $"{uploads}/{uniqueFileName}";

            using (var stream = new FileStream(pathFinal, FileMode.Create))
            {
                resumeeFile.CopyTo(stream);
            }

            return $"{path}/{uniqueFileName}";
        }

        public async Task<string> UpdateResumee(ProfileFileDto updateResumee)
        {
            string urlResumee = string.Empty;


            if (updateResumee.File != null)
                urlResumee = UploadResumee(updateResumee.File);
            else throw new BusinessException("El Cv es requerido");


            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefault(x => x.IdUser == updateResumee.Id);

            if (!string.IsNullOrEmpty(profile.CV))
            {
                DeleteFile(profile.CV);
            }


            profile.CV = urlResumee;

            _unitOfWork.ProfileRepository.Update(profile);

            await _unitOfWork.Save();
            return urlResumee;

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
                                        IdUser = x.ProfileEntity.Id,
                                        Name = x.ProfileEntity.Name,
                                        LastName = x.ProfileEntity.LastName,
                                        Mail = x.ProfileEntity.Mail,
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


        #endregion
    }
}