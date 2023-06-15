using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Work
{
    public class WorkDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Company { get; set; }
        [Required]
        [MaxLength(100)]
        public string Role { get; set; }

        public int IdSector { get; set; }

        public string DescriptionSector { get; set; }
        [Required]
        public int IdUbication { get; set; }
        public string DescriptionUbication { get; set; }

        [Required]
        public int IdWorkType { get; set; }
        public int IdJobPosition { get; set; }
        public string DescriptionWorkType { get; set; }
        public string DescriptionJobPosition { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
    }
}
