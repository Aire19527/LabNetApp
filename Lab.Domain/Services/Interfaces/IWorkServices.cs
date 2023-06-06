using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IWorkServices
    {
        Task<List<ConsultWorkDto>> Getall();
        Task<bool> Insert(AddWorkEntity addWorkEntity);
        Task<bool> Update(ModifyWorkDto modifyWorkDto);
        Task<bool> Delete(int id);
    }
}