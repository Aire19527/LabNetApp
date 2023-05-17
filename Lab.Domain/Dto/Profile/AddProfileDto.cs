﻿using Infraestructure.Entity.Models;
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
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(8)]
        public int DNI { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Mail { get; set; }


    }
}