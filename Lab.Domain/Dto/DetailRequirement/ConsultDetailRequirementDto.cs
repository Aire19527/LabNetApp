using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.DetailRequirement
{
    public class ConsultDetailRequirementDto : DetailRequirementDto
    {
        public int id { get; set; }
        public string skillDescription { get; set; }
        public string difficultDescription { get; set; }
    }
}
