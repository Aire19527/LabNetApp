using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.Dto.ProfileSkill
{
    public class AddProfileSkillDto
    {
        [Required]
        public int? IdProfile { get; set; }
        [Required]
        public int?  IdSkill { get; set; }
    }
}
