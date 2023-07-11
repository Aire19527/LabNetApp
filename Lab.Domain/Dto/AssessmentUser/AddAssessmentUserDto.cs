using Lab.Domain.Dto.AssessmentQuestion;

namespace Lab.Domain.Dto.AssessmentUser
{
    public class AddAssessmentUserDto
    {
        public int IdRequest { get; set; }
        public List<AssessmentQuestionDto> AssessmentQuestion { get; set; }
    }
}