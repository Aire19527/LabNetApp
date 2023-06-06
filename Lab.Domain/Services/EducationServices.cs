using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Education;
using Lab.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Lab.Domain.Services
{
    public class EducationServices : IEducationServices
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public EducationServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }



        public async Task<bool> Delete(int id)
        {
            EducationEntity? education = _unitOfWork.EducationRepository.FirstOrDefault((x) => x.Id == id);

            if (education == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.EducationRepository.Delete(education);

            return await _unitOfWork.Save() > 0;
        }


        public async Task<bool> Insert(AddEducationDto add)
        {
            ProfileEntity profile = 
                _unitOfWork.ProfileRepository.FirstOrDefault(x => x.Id == add.IdProfile);

            if (profile == null)
                throw new BusinessException("No existe el perfil");

            InstitutionTypeEntity institutionType =
                _unitOfWork.InstitutionTypeRepository.FirstOrDefault(x => x.Id == add.IdInstitutionType);
            if (institutionType == null)
                throw new BusinessException("No existe el tipo de institucion");
                
                
            EducationEntity education = new EducationEntity()
            {
                IdProfile = add.IdProfile,
                InstitutionName = add.InstitutionName,
                Degree = add.Degree,
                AdmissionDate = add.AdmissionDate,
                ExpeditionDate = add.ExpeditionDate,
                IdInstitutionType = add.IdInstitutionType
            };
            _unitOfWork.EducationRepository.Insert(education);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(UpdateEducationDto update)
        {
            EducationEntity education =
                _unitOfWork.EducationRepository.FirstOrDefault(x => x.Id == update.Id);
            if (education != null)
            {

                education.Id = update.Id;
                education.InstitutionName = update.InstitutionName;
                education.Degree = update.Degree;
                education.AdmissionDate = update.AdmissionDate;
                education.ExpeditionDate = update.ExpeditionDate;
                education.IdInstitutionType = update.IdInstitutionType;
                _unitOfWork.EducationRepository.Update(education);

                return await _unitOfWork.Save() > 0;
            }
            return false;
        }
    }
}
