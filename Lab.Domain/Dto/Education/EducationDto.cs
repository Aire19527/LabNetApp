using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Education
{
    public class EducationDto : UpdateEducationDto
    {
        public string DescriptionInstitutionType { get; set; }
    }
}
