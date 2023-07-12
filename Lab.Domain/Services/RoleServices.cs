using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Role;
using Lab.Domain.Dto.User;
using Lab.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public RoleServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<GetRoleDto> GetAll()
        {
            IEnumerable<RoleEntity> roleQuery = _unitOfWork.RoleRepository.GetAll();
            //.FindAll(x=> & | ) para separar las condiciones


            List<GetRoleDto> roles = roleQuery.Select(x => new GetRoleDto()
            {
                Id = x.Id,
                Descripcion= x.Description
            })
            .ToList();

            return roles;

        }
    }
}
