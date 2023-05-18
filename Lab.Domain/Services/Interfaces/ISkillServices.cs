using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Skill;

namespace Lab.Domain.Services.Interfaces
{
    public interface ISkillServices
    {
        Task<bool> Insert(AddSkilDto add);

        Task<bool> Delete(int id);

        List<ConsultSkllDto> Getall();
    }
}
