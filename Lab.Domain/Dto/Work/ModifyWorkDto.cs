using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Work
{
    public class ModifyWorkDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Company { get; set; }
        [Required]
        [MaxLength(100)]
        public string Role { get; set; }
        public string? DetailFuntion { get; set; }
        public string? BossRole { get; set; }
        public string? BossContact { get; set; }
        public string? BossName { get; set; }

        public int IdSector { get; set; }
        [Required]
        public int IdUbication { get; set; }
        [Required]
        public int IdWorkType { get; set; }
        public int IdJobPosition { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
    }
}