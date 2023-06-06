using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Adress")]
    public class AdressEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Street { get; set; }
        public int? Number { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public IEnumerable<ProfileEntity> ProfileEntity { get; set; }


        [ForeignKey("CityEntity")]
        public int IdCityEntity { get; set; }
        public CityEntity CityEntity { get; set; }
    }
}