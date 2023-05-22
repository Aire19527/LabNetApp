using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.ProfileImage
{
    public class ProfileFileDto
    {
        public int Id { get; set; }
        public IFormFile? File { get; set; }
    }
}
