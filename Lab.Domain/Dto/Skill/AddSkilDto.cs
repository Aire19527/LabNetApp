using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.Dto.Skill
{
    public class AddSkilDto
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
