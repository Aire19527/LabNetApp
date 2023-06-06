using Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.User
{ 
    public class AddUserDto
    {
       
       
      
        [EmailAddress(ErrorMessage ="El campo debe ser un correo valido")]
        public string Email { get; set; }

        [ValidPassword(ErrorMessage = "El password debe contener al menos 8 caracteres, una mayuscula," +
            " una minuscula, un numero y un caracter especial")]
        public string Password { get; set; }


        public bool IsActive { get; set; }

        public int IdRole { get; set; } 


    }
}
