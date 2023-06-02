using Infraestructure.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.JobPosition
{
    public class ConsultJobPositionDto : AddJobPositionDto
    {
        public int IdJobPosition { get; set; }
    }
}
