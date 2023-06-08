using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.JobPosition;
using Lab.Domain.Dto.NewFolder;
using Lab.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class InstitutionTypeServices : IInstitutionTypeServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        #endregion

        #region Builder
        public InstitutionTypeServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<List<InstitutionTypeDto>> Getall()
        {

            IEnumerable<InstitutionTypeEntity> institutionType = _unitOfWork.InstitutionTypeRepository.GetAll();

            List<InstitutionTypeDto> institutionTypeList = institutionType
                .Select(i => new InstitutionTypeDto()
                {
                    Id = i.Id,
                    Description = i.Description,
                }).ToList();

            return institutionTypeList;
        }
        #endregion
    }
}
