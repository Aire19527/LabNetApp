using Lab.Domain.Dto.JobPosition;

namespace Lab.Domain.Services.Interfaces
{
    public interface IJobPositionServices
    {
        Task<List<ConsultJobPositionDto>> Getall();
        ConsultJobPositionDto GetById(int id);
        Task<bool> Insert(AddJobPositionDto add);
    }
}
