using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("AssessmentQuestionAnswer")]
    public class AssessmentQuestionAnswerEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AssessmentQuestionEntity")]
        public int IdAssessmentQuestion { get; set; }

        public AssessmentQuestionEntity AssessmentQuestionEntity { get; set; }

        [ForeignKey("AnswerEntity")]
        public int IdAnswer { get; set; }

        public AnswerEntity AnswerEntity { get; set; }

        public decimal Points { get; set; }

    }
}