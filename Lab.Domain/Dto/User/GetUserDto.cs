using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.User
{
    public class GetUserDto: AddUserDto
    {
        public int Id { get; set; }
        public string Role { get; set; }

    }
}
