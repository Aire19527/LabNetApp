using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab.Domain.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El email es requerido")]
        [MaxLength(200)]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
