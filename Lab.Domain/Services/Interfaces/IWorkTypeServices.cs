using Lab.Domain.Dto.Role;
using Lab.Domain.Dto.WorkType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IWorkTypeServices
    {
        public List<GetWorkTypeDto> GetAll();
    }
}
