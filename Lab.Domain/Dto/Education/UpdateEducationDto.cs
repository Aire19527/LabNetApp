using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Education
{
    public class UpdateEducationDto
    {
        [Key]
        public int Id { get; set; }
        public string InstitutionName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Degree { get; set; }
        [Required]
        public DateTime AdmissionDate { get; set; }
        [Required]
        public DateTime ExpeditionDate { get; set; }
        public int IdInstitutionType { get; set; }
    }
}
