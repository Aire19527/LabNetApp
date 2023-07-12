using Lab.Domain.Dto.AssessmentQuestion;
using Lab.Domain.Dto.Resquest;

namespace Lab.Domain.Dto.Assessment
{
    public class ConsultAssessmentUserDto
    {
        public int IdRequest { get; set; }
        public string RequestTitle { get; set; }

        public DateTime DateAssessment { get; set; }

        public int PointsObtained { get; set; }

        public int DniUsuario { get; set; }

        public int IdUser { get; set; }
        public string NombreUser { get; set; }

        public List<ConsultAssessmentQuestionDto> ConsultAssessmentQuestion { get; set; }
    }
}