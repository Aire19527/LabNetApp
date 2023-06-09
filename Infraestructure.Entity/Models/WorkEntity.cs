using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Work")]
    public class WorkEntity
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
        [Required]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
        
        [ForeignKey("ProfileEntity")]
        public int IdProfile { get; set; }

        [ForeignKey("UbicationEntity")]
        public int IdUbication { get; set; }

        [ForeignKey("WorkTypeEntity")]
        public int IdWorkType { get; set; }

        [ForeignKey("SectorEntity")]
        public int IdSector { get; set; }

        [ForeignKey("JobPositionEntity")]
        public int? IdJobPosition { get; set; }

        public UbicationEntity UbicationEntity { get; set; }
        public WorkTypeEntity WorkTypeEntity { get; set; }
        public SectorEntity SectorEntity { get; set; }
        public ProfileEntity ProfileEntity { get; set; }
        public JobPositionEntity? JobPositionEntity { get; set; }
    }
}
