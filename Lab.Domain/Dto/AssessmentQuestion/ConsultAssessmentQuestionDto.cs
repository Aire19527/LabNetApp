using Lab.Domain.Dto.AssessmentQuestionAnswer;

namespace Lab.Domain.Dto.AssessmentQuestion
{
    public class ConsultAssessmentQuestionDto 
    {
        public int IdQuestion { get; set; }

        public string UrlQuestion { get; set; }
        public string QuestionDescription { get; set; }

        public List<AssessmentAnswerDto> AssessmentAnswer { get; set; }
    }
}