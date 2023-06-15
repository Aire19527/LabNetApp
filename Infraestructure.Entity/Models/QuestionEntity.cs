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
        public int Value { get; set; }

        [Required]
        public bool IsVisible { get; set; }

        public SkillEntity Skill { get; set; }

        [ForeignKey("SkillEntity")]
        public int? IdSkill { get; set; }

        public IEnumerable<AnswerEntity> AnswerEntities { get; set; }

        public int? IdFile { get; set; }
        public FileEntity FileEntity { get; set; }
    }
}
