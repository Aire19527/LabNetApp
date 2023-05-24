using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto
{
    public class TokenDto
    {
        public string Token { get; set; }
        public double Expiration { get; set; }
    }
}
