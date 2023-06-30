using Infraestructure.Entity.Models;
using Lab.Domain.Dto.DetailRequirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IDetailRequirementService
    {
        DetailRequirementEntity GetDetailRequirement(DetailRequirementDto detailRequirementDto);
    }
}
