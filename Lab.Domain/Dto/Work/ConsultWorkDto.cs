using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Work
{
    public class ConsultWorkDto : AddWorkDto
    {
        public int IdWork { get; set; }
        public string? DetailFuntion { get; set; }
        public string? BossRole { get; set; }
        public string? BossContact { get; set; }
        public string? BossName { get; set; }
        public string? SectorName { get; set; }
        public string? UbicationName { get; set; }
        public string? WorkTypeName { get; set; }
    }
}