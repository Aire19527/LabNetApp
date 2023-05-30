using Lab.Domain.Dto;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IUserServices
    {
        Task<bool> Insert(AddUserDto add);
        List<GetUserDto> GetAll();

        TokenDto Login(LoginDto user);

        Task<bool> Delete(int id);
        Task<bool> UpdatePassword(UserPasswordDto password, int idUser);
    }
}
