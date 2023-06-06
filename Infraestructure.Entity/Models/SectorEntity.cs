using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Sector")]
    public class SectorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z\s]+$",
                    ErrorMessage = "La descripcion solo pueden contener letras y espacios.")]
        public int Description { get; set; }
    }
}