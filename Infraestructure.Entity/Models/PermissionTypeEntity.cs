using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("PermissionType")]
    public  class PermissionTypeEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Description { get; set; }

        public IEnumerable<PermissionEntity> PermissionEntity { get;}
    }
}