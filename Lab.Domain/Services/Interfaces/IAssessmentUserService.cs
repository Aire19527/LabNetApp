using Lab.Domain.Dto.Assessment;
using Lab.Domain.Dto.AssessmentUser;

namespace Lab.Domain.Services.Interfaces
{
    public interface IAssessmentUserService
    {
        List<ConsultAssessmentUserDto> GetAssessment(int idUser, int idRol);

        Task<bool> Insert(AddAssessmentUserDto addAssessmentUserDto, int idUser);
    }
}