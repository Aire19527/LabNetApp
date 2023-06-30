using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Answer")]
    public class AnswerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public IEnumerable<QuestionAnswerEntity>? QuestionAnswerEntityEntities { get; set; }

        public int? IdFile { get; set; }
        public FileEntity FileEntity { get; set; }

        public IEnumerable<AssessmentQuestionAnswerEntity> AssessmentQuestionAnswerEntities { get; set; }
    }

}
