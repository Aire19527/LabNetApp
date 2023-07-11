using Lab.Domain.Dto.Assessment;
using Lab.Domain.Dto.AssessmentUser;

namespace Lab.Domain.Services.Interfaces
{
    public interface IAssessmentUserService
    {
        List<ConsultAssessmentUserDto> GetAssessment();
        Task<bool> Insert(AddAssessmentUserDto addAssessmentUserDto, int idUser);
    }
}