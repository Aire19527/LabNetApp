using Lab.Domain.Dto.Sector;
using Lab.Domain.Dto.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface ISectorServices
    {
        Task<bool> Insert(AddSectorDto add);

        Task<bool> Delete(int id);

        List<GetSectorDto> Getall();
    }
}
