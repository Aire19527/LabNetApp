using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Profile")]
    public class ProfileEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(8)]
        public int DNI { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        [Required]
        public string Mail { get; set; }
        public byte[] CV { get; set; }
    }
}
