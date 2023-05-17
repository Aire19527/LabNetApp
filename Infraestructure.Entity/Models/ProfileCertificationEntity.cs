using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("ProfileCertification")]
    public class ProfileCertificationEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProfileEntity")]
        public int IdProfile { get; set; }
        [ForeignKey("CertificationEntity")]
        public int IdCertification { get; set; }
        public ProfileEntity ProfileEntity { get; set; }
        public CertificationEntity CertificationEntity { get; set; }
    }
}