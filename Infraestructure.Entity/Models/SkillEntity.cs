using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("Skill")]
    public class SkillEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public bool IsVisible { get; set; }
        public IEnumerable<ProfilesSkillsEntity> ProfilesSkillsEntity { get; set; }

        public IEnumerable<QuestionSkillEntity> QuestionSkillEntity { get; set; }
    }
}