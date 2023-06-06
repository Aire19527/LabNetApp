using Lab.Domain.Dto.Education;
using Lab.Domain.Dto.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IEducationServices
    {
        Task<bool> Insert(AddEducationDto add);

        Task<bool> Delete(int id);

        Task<bool> Update(UpdateEducationDto add);
    }
}
