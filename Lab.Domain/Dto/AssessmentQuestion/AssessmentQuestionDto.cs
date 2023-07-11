using Infraestructure.Entity.Models;
using Lab.Domain.Dto.AssessmentQuestionAnswer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.AssessmentQuestion
{
    public class AssessmentQuestionDto
    {
        public int IdQuestion { get; set; }
        public List<AssessmentQuestionAnswerDto> AssessmentQuestionAnswer { get; set; }
    }
}