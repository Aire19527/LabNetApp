using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Difficulty")]
    public class DifficultyEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        [RegularExpression(@"^[A-Za-z\s]+$",
                    ErrorMessage = "La descripcion solo pueden contener letras y espacios.")]
        public string Description { get; set; }
        [Required]
        public int Value { get; set; }

        public IEnumerable<QuestionEntity> QuestionEntity { get; set; }
    }
}