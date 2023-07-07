using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("QuestionsAnswers")]
    public class QuestionAnswerEntity
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("AnswerEntity")]
        public int AnswerId { get; set; }
        public AnswerEntity AnswerEntity { get; set; }

        [ForeignKey("QuestionEntity")]
        public int QuestionId { get; set; }
        public QuestionEntity QuestionEntity { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

    }
}
