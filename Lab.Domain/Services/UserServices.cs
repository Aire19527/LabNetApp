using Common;
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
            IEnumerable<UserEntity> userQuery = _unitOfWork.UserRepository.GetAll(x=> x.RoleEntity);
                                                                        //.FindAll(x=> & | ) para separar las condiciones


            List<GetUserDto> usuarios = userQuery.Select(x => new GetUserDto()
            {
                Id = x.Id,
                Email=x.Mail,
                Password=x.Password,
                IdRole=x.IdRole, 
                Role=x.RoleEntity.Description,
                IsActive =x.IsActive
            })
            .ToList();

            return usuarios;

        }

        public async Task<bool> Insert(AddUserDto dto)
        {
          
            
                if (_unitOfWork.UserRepository.FirstOrDefault(x => x.Mail == dto.Email) == null)
                {
                    UserEntity user = new UserEntity()
                    {
                        Mail = dto.Email,
                        Password = "12345678",
                        IsActive = true,
                        IdRole = dto.IdRole
                    };
                    _unitOfWork.UserRepository.Insert(user);

                    return await _unitOfWork.Save() > 0;
                }
                else
                {
                    return false;
                }
        
        }


        public async Task<bool> Delete(int id)
        {
            UserEntity? userEntity = _unitOfWork.UserRepository.FindAll((user) => user.Id == id).SingleOrDefault();

            if (userEntity != null)
            {   
                userEntity.IsActive = false;
                _unitOfWork.UserRepository.Update(userEntity);
                await _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
