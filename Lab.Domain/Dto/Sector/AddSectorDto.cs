using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Sector
{
    public class AddSectorDto
    {
        
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z\s]+$",
                   ErrorMessage = "La descripcion solo pueden contener letras y espacios.")]
        public string Description { get; set; }
    }
}
