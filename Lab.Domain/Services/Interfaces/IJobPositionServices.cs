using Lab.Domain.Dto.JobPosition;
using Lab.Domain.Dto.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IJobPositionServices
    {
        Task<List<ConsultJobPositionDto>> Getall();
        ConsultJobPositionDto GetById(int id);
        Task<bool> Insert(AddJobPositionDto add);
    }
}
