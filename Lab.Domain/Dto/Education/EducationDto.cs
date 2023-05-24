using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Education
{
    public class EducationDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string InstitutionName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Degree { get; set; }
        [Required]
        public DateTime AdmissionDate { get; set; }
        [Required]
        public DateTime ExpeditionDate { get; set; }
        public int IdInstitutionType { get; set; }
        public string DescriptionInstitutionType { get; set; }
    }
}
