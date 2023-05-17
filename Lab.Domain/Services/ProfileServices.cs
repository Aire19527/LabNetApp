using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<ProfileEntity> ProfileList = _unitOfWork.ProfileRepository.GetAll();

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
                BirthDate = p.BirthDate

            }).ToList();

            return profiles;
        }

        public async Task<ConsultProfileDto> GetById(int id)
        {
            //TODO: IMPLEMENT GET BY ID
            throw new NotImplementedException();
        }

        public async Task<bool> Insert(AddProfileDto add)
        {
            ProfileEntity profile = new ProfileEntity()
            {
                IdUser = add.IdUser,
                Name = add.Name,
                LastName = add.LastName,
                DNI = add.DNI,
                BirthDate=add.BirthDate,
                Mail = add.Mail
            };
            _unitOfWork.ProfileRepository.Insert(profile);

            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> Update(ModifyProfileDto update)
        {
            ProfileEntity profile = _unitOfWork.ProfileRepository.FirstOrDefault(x => x.Id == update.IdUser);
            if (profile != null)
            {
                profile.Description = update.Description;
                profile.Phone = update.Phone;
                profile.CV = update.CV;
                profile.Photo = update.Photo;

                _unitOfWork.ProfileRepository.Update(profile);

                return await _unitOfWork.Save() > 0;
            }
            return false;
        }

        #endregion
    }


}
