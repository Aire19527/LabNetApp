using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.AssessmentQuestionAnswer
{
    public class AssessmentQuestionAnswerDto
    {
        //public int IdAssessmentQuestion { get; set; }
        public int IdAnswer { get; set; }
        //public int Points { get; set; }
        public bool IsCorrect { get; set; }
    }
}