using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("AssessmentQuestion")]
    public class AssessmentQuestionEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AssessmentUserEntity")]
        public int IdAssessmentUser { get; set; }

        public AssessmentUserEntity AssessmentUserEntity { get; set; }

        [ForeignKey("QuestionEntity")]
        public int IdQuestion { get; set; }

        public QuestionEntity QuestionEntity { get; set; }

        public IEnumerable<AssessmentQuestionAnswerEntity> AssessmentQuestionAnswerEntities { get; set; }
    }
}