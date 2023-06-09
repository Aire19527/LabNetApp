using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Work
{
    public class AddWorkDto
    {
        [Required]
        [MaxLength(120)]
        public string Company { get; set; }
        [Required]
        [MaxLength(100)]
        public string Role { get; set; }
        [Required]
        public int IdProfile { get; set; }
        [Required]
        public int IdSector { get; set; }
        [Required]
        public int IdUbication { get; set; }
        [Required]
        public int IdWorkType { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
    }
}