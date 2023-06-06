using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Role;
using Lab.Domain.Dto.WorkType;
using Lab.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class WorkTypeServices : IWorkTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;


        public WorkTypeServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;

        }
        public List<GetWorkTypeDto> GetAll()
        {

            IEnumerable<WorkTypeEntity> workQuery = _unitOfWork.WorkTypeRepository.GetAll();
            //.FindAll(x=> & | ) para separar las condiciones


            List<GetWorkTypeDto> works = workQuery.Select(x => new GetWorkTypeDto()
            {
                Id = x.Id,
                Descripcion = x.Description
            })
            .ToList();

            return works;

        }
    }
}
