using Lab.Domain.Dto.AssessmentQuestionAnswer;
using Lab.Domain.Dto.DetailRequirement;

namespace Lab.Domain.Dto.Assessment
{
    public class ConsultAssessmentDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public List<ConsultDetailRequirementDto> ConsultDetailRequirementies { get; set; }
        public List<AssessmentQuestionAnswerDto> AssessmentQuestionAnsweries { get; set; }
    }
}