using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        [ForeignKey("StateEntity")]
        public int IdStatus { get; set; }
        public ProfileEntity ProfileEntity { get; set; }
        public StateEntity StateEntity { get; set; }
    }
}