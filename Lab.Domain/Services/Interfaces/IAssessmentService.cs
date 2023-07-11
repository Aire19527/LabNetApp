using Lab.Domain.Dto.Assessment;

namespace Lab.Domain.Services.Interfaces
{
    public interface IAssessmentService
    {
        List<ConsultAssessmentUserDto> GetAssessment();
    }
}