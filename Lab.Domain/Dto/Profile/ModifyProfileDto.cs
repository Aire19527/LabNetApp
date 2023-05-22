using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Profile
{
    public class ModifyProfileDto 
    {
        [Key]
        public int IdUser { get; set; }

        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        public string? CV { get; set; }
        public int IdAdress { get; set; }
        //public string AdressDescription { get; set; }
        public int IdJobPosition { get; set; }
        //public string JobPositionDescription { get; set; }

    }
}
