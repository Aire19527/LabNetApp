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
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(8)]
        public int DNI { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        [Required]
        public string Mail { get; set; }
        public byte[]? CV { get; set; }
        public UserEntity UserEntity { get; set; }
        public int IdUser { get; set; }

        [ForeignKey("AdressEntity")]
        public int? IdAdress { get; set; }
        [ForeignKey("DniTypeEntity")]
        public int? IdDniType { get; set; }
        [ForeignKey("JobPositionEntity")]
        public int? IdJobPosition { get; set; }
        public AdressEntity? AdressEntity { get; set; }
        public DniTypeEntity? DniTypeEntity { get; set; }
        public JobPositionEntity? JobPositionEntity { get; set; }
        public IEnumerable<ProfileEducationEntity>? ProfileEducationEntity { get; set; }
        public IEnumerable<ProfilesSkillsEntity>? ProfilesSkillsEntity { get; set; }
        public IEnumerable<ProfileCertificationEntity>? ProfileCertificationEntity { get; set; }
        public IEnumerable<ProfileWorkEntity>? ProfileWorkEntity { get; set; }
    }
}
