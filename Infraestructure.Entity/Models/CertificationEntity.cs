using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("Certification")]
    public class CertificationEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }
        public DateTime ExpeditionDate { get; set; }
    }
}