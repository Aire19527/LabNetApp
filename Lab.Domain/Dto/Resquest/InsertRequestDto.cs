using Lab.Domain.Dto.DetailRequirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Resquest
{
    public class InsertRequestDto
    {
        public InsertRequestDto() {

            DetailRequirements = new List<DetailRequirementDto>();
            QuestionsRequired = new List<int>();
        }

        public int PercentageMinimoRequired { get; set; }
        public int TimeInMinutes { get; set; }
        public string TitleRequest { get; set; }

        public List<DetailRequirementDto> DetailRequirements { get; set; }
        public List<int> QuestionsRequired { get; set; }
    }
}