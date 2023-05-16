using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Province")]
    public class ProvinceEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Description { get; set; }
    }
}