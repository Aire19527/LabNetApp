using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Work
{
    public class ConsultWorkDto
    {
        [Required]
        [MaxLength(120)]
        public string Company { get; set; }
        [Required]
        [MaxLength(100)]
        public string Role { get; set; }
        public int IdWork { get; set; }
        public string? DetailFuntion { get; set; }
        public string? BossRole { get; set; }
        public string? BossContact { get; set; }
        public string? BossName { get; set; }
        public string? SectorName { get; set; }
        public string? UbicationName { get; set; }
        public string? WorkTypeName { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
    }
}