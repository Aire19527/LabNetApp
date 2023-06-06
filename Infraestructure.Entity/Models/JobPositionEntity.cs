using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("JobPosition")]
    public class JobPositionEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public IEnumerable<WorkEntity> WorkEntity { get; set; }
    }
}