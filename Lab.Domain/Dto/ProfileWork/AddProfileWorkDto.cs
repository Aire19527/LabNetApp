using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.ProfileWork
{
    public class AddProfileWorkDto
    {
        [Required]
        public int IdProfile { get; set; }
        [Required]
        public int IdWork { get; set; }
    }
}