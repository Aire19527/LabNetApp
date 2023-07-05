using Lab.Domain.Dto.DetailRequirement;
using Lab.Domain.Dto.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Resquest
{
    public class ConsultRequestDto : RequestDto
    {
        public int Id { get; set; }
        public List<ConsultDetailRequirementDto> DetailRequirements { get; set; }
        public List<QuestionDto> QuestionsRequired { get; set; }

    }
}