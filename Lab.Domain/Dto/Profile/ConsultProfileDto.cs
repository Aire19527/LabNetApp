using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Profile
{
    public class ConsultProfileDto : AddProfileDto
    {
        public string Description { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public byte[] CV { get; set; }

    }
}
