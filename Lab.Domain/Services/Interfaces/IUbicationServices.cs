using Lab.Domain.Dto.Ubication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IUbicationServices
    {

       public List<GetUbicationDto> GetAll();
    }
}
