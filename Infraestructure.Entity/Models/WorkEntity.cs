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
        public IEnumerable<ProfileWorkEntity> ProfileWorkEntity { get; set; }
    }
}
