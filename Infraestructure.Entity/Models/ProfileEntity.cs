using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Profile")]
    public class ProfileEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z\s]+$", 
            ErrorMessage = "El nombre solo pueden contener letras y espacios.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z\s]+$",
            ErrorMessage = "El apellido solo pueden contener letras y espacios.")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(8)]
        [RegularExpression(@"^[0-9]+$", 
            ErrorMessage = "El DNI solo pueden contener números.")]
        public int DNI { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string? Description { get; set; }
        [RegularExpression(@"^[0-9\s-]+$",
            ErrorMessage = "El Telefono solo pueden contener números.")]
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        public string? CV { get; set; }
        public UserEntity UserEntity { get; set; }
        public int IdUser { get; set; }

        [ForeignKey("AdressEntity")]
        public int? IdAdress { get; set; }
        [ForeignKey("DniTypeEntity")]
        public int? IdDniType { get; set; }

        public AdressEntity? AdressEntity { get; set; }
        public DniTypeEntity? DniTypeEntity { get; set; }
        public IEnumerable<ProfileEducationEntity>? ProfileEducationEntity { get; set; }
        public IEnumerable<ProfilesSkillsEntity>? ProfilesSkillsEntity { get; set; }
        public IEnumerable<ProfileCertificationEntity>? ProfileCertificationEntity { get; set; }
        public IEnumerable<ProfileWorkEntity>? ProfileWorkEntity { get; set; }
    }
}
