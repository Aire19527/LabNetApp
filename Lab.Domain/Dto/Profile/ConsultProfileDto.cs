using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Education;
using Lab.Domain.Dto.Work;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Profile
{
    public class ConsultProfileDto : AddProfileDto
    {

        public int IdProfile { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }

        //TODO: STRING URL
        public string? Photo { get; set; }
        public string? CV { get; set; }

        //TODO: POR EJEMPLO ID TIPO DNI Y DESCRIPCION TIPO DNI
        public int? IdAdress { get; set; }
        public string? AdressDescription { get; set; }
        public int? IdDniType { get; set; }
        public string?  DniDescrption { get; set; }
        public int? IdJobPosition { get; set; }
        public string? JobPositionDescription { get; set; }

        public IEnumerable<WorkDto>? WorkEntities { get; set; }
        public IEnumerable<EducationDto>? EducationEntities { get; set; }

    }
}