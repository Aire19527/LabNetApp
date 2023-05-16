using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("User")]
    public class UserEntity
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string  Password { get; set; }
        public bool State { get; set; }
    }
}