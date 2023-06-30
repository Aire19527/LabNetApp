using Lab.Domain.Dto.Resquest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IRequestService
    {
        Task<List<ConsultRequestDto>> GetAllRequests();
        Task<bool> Insert(InsertRequestDto insertRequestDto);
        Task<bool> Delete(int id);
    }
}