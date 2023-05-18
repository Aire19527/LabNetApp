using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.User
{ 
    public class AddUserDto
    {
       
        [Required]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage ="El campo debe ser un correo valido")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public int IdStatus { get; set; }
        [Required]
        public int IdRole { get; set; } 


    }
}
