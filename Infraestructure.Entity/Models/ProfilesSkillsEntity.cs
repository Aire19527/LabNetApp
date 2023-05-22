using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("ProfilesSkills")]
    public class ProfilesSkillsEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProfileEntity")]
        public int? IdProfile { get; set; }

        [ForeignKey("SkillEntity")]
        public int? IdSkill { get; set; }

        public SkillEntity SkillEntity { get; set; }

        public ProfileEntity ProfileEntity { get; set; }
    }
}