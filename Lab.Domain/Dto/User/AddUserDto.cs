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

      
        public string Password { get; set; }


        public bool IsActive { get; set; }

        public int IdRole { get; set; } 


    }
}
