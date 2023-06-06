using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Ubication")]
    public class UbicationEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z\s]+$",
            ErrorMessage = "La descripcion solo pueden contener letras y espacios.")]
        public string Description { get; set; }


        //revisar
        public IEnumerable<WorkEntity> WorkEntitys { get; set; }
    }
}