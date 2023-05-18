using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table ("Configuration")]
    public class ConfigEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
       
        public string? Description { get; set; }
    }
}