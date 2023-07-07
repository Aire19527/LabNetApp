using Lab.Domain.Dto.AssessmentUser;

namespace Lab.Domain.Services.Interfaces
{
    public interface IAssessmentUserService
    {
        Task<bool> Insert(AddAssessmentUserDto addAssessmentUserDto, int idUser);
    }
}