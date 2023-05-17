using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("ProfileEducation")]
    public class ProfileEducationEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProfileEntity")]
        public int IdProfile { get; set; }
        [ForeignKey("EducationEntity")]
        public int IdEducation { get; set; }
        public ProfileEntity ProfileEntity { get; set; }
        public EducationEntity EducationEntity { get; set; }
    }
}