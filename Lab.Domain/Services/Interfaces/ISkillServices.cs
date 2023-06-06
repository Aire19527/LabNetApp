using Lab.Domain.Dto.Skill;

namespace Lab.Domain.Services.Interfaces
{
    public interface ISkillServices
    {
        Task<bool> Insert(AddSkilDto add);

        List<ConsultSkllDto> Getall();
    }
}
