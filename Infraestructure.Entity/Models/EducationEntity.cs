using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Education")]
    public class EducationEntity
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
    }
}
