using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("DniType")]
    public class DniTypeEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Description { get; set; }
    }
}