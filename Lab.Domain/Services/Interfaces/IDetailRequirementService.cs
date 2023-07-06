using Infraestructure.Entity.Models;
using Lab.Domain.Dto.DetailRequirement;
using Lab.Domain.Dto.Question;

namespace Lab.Domain.Services.Interfaces
{
    public interface IDetailRequirementService
    {

        List<QuestionDto> GetQuestion(DetailRequirementEntity detailRequirement);
        //Task<List<QuestionDto>> GetQuestion(ConsultDetailRequirementDto consultDetailRequirementDto);
        DetailRequirementEntity GetDetailRequirement(DetailRequirementDto detailRequirementDto);

        Task<bool> Delete(int id);
    }
}
