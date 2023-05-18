using Lab.Domain.Dto.Skill;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.ProfileSkill
{
    public class AddProfileSkillDto
    {
        [Required]
        public int IdProfile { get; set; }
        [Required]
        public int  IdSkill { get; set; }
    }
}
