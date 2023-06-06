using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("State")]
    public class StateEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string State { get; set; }

        [MaxLength(100)]
        [Required]
        public string Ambit { get; set; }

    }
}
