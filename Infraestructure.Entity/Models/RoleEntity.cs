using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Role")]
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public IEnumerable<RolePermissionEntity> RolePermissionEntities { get; set; }
    }
}