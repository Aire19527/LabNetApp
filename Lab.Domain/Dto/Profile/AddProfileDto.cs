using Infraestructure.Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Profile
{
    public class AddProfileDto
    {
        public int IdUser { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z\s]+$",
            ErrorMessage = "El nombre solo pueden contener letras y espacios.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z\s]+$",
            ErrorMessage = "El apellido solo pueden contener letras y espacios.")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "El DNI solo pueden contener números.")]
        public int DNI { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress (ErrorMessage = "Formato del e-mail invalido")]

        public string Mail { get; set; }

        public IFormFile? FileImage { get; set; }
        public IFormFile? FileResumee { get; set; }
    }
}
