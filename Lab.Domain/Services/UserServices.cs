using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Dto.User;
using Lab.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class UserServices : IUserServices
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<GetUserDto> GetAll()
        {
            IEnumerable<UserEntity> userQuery = _unitOfWork.UserRepository.GetAll(x=> x.RoleEntity,r=>r.StateEntity);
                                                                        //.FindAll(x=> & | ) para separar las condiciones


            List<GetUserDto> usuarios = userQuery.Select(x => new GetUserDto()
            {
                Id = x.Id,
                Email=x.Mail,
                Password=x.Password,
                IdRole=x.IdRole, 
                Role=x.RoleEntity.Description,
                State=x.StateEntity.State
            })
            .ToList();

            return usuarios;

        }

        public async Task<bool> Insert(AddUserDto dto)
        {
            UserEntity user = new UserEntity()
            {
                Mail = dto.Email,
                Password = dto.Password,
                IdState = dto.IdState,
                IdRole = dto.IdRole
            };
            _unitOfWork.UserRepository.Insert(user);

            return await _unitOfWork.Save() > 0;
        }
    }
}
