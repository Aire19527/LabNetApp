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
        [ForeignKey("RequestEntity")]
        public int IdRequest { get; set; }
        public RequestEntity RequestEntity { get; set; }

        [ForeignKey("SkillEntity")]
        public int IdSkill { get; set; }
        public SkillEntity SkillEntity { get; set; }

        [ForeignKey("DifficultyEntity")]
        public int IdDifficulty { get; set; }
        public DifficultyEntity DifficultyEntity { get; set; }
        public int QuantityQuestions { get; set; }
    }
}