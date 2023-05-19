using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Models
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        //[EmailAddress(ErrorMessage ="el campo ingresado debe ser un email")]
        public string Mail { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; }

        public bool IsActive { get; set; }


        public ProfileEntity ProfileEntity { get; set; }
   


        [ForeignKey("RoleEntity")]
        public int IdRole { get; set; }
        public RoleEntity RoleEntity { get; set; }
    }
}