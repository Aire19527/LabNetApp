using Lab.Domain.Dto.AssessmentQuestion;

namespace Lab.Domain.Dto.AssessmentUser
{
    public class AddAssessmentUserDto
    {
        //public int IdUser { get; set; }
        public int IdRequest { get; set; }
        //public int PointsObtained { get; set; }
        //public int PointsMaximum { get; set; }
        public List<AssessmentQuestionDto> AssessmentQuestion { get; set; }
    }
}