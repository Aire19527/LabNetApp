using Lab.Domain.Dto.JobPosition;
using Lab.Domain.Dto.NewFolder;

namespace Lab.Domain.Services.Interfaces
{
    public interface IInstitutionTypeServices
    {
        Task<List<InstitutionTypeDto>> Getall();
    }
}
