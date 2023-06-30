using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("DetailRequirement")]
    public class DetailRequirementEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Request")]
        public int IdRequest { get; set; }
        public RequestEntity RequestEntity { get; set; }

        [ForeignKey("Skill")]
        public int IdSkill { get; set; }
        public SkillEntity SkillEntity { get; set; }

        [ForeignKey("Difficulty")]
        public int IdDifficulty { get; set; }
        public DifficultyEntity DifficultyEntity { get; set; }
        public int QuantityQuestions { get; set; }
    }
}