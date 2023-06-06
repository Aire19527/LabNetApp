using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("ProfileWork")]
    public class ProfileWorkEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProfileEntity")]
        public int IdProfile { get; set; }
        [ForeignKey("WorkEntity")]
        public int IdWork { get; set; }
        public ProfileEntity ProfileEntity { get; set; }
        public WorkEntity WorkEntity { get; set; }
    }
}
