using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Question")]
    public class QuestionEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Description { get; set; }

        [Required]
        public bool IsVisible { get; set; }

        [ForeignKey("FileEntity")]
        public int? IdFile { get; set; }
        public FileEntity? FileEntity { get; set; }

        [ForeignKey("DifficultyEntity")]
        public int IdDifficulty { get; set; }

        public DifficultyEntity DifficultyEntity { get; set; }

        public IEnumerable<QuestionSkillEntity> QuestionSkillEntities { get; set; }

        public IEnumerable<QuestionAnswerEntity> QuestionAnswerEntities { get; set; }
        public IEnumerable<RequirementQuestionEntity> RequirementQuestionEntities { get; set; }

        public IEnumerable<AssessmentQuestionEntity> AssessmentQuestionEntities { get; set; }
    }
}