using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("QuestionSkillEntity")]
    public class QuestionSkillEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("QuestionEntity")]
        public int IdQuestion { get; set; }

        [ForeignKey("SkillEntity")]
        public int IdSkill { get; set; }

        public QuestionEntity? QuestionEntity { get; set; }
        public SkillEntity? SkillEntity { get; set; }
    }
}