using Lab.Domain.Dto.Sector;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class SectorServices : ISectorServices
    {
       

        public List<GetSectorDto> Getall()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(AddSectorDto add)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
