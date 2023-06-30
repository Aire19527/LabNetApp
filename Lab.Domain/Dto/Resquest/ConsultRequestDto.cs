using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Resquest
{
    public class ConsultRequestDto
    {
        public int PercentageMinimoRequired { get; set; }
        public int TimeInMinutes { get; set; }
        public string TitleRequest { get; set; }
        public int IdRequest { get; set; }
    }
}