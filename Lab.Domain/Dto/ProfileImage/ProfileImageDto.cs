using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.ProfileImage
{
    public class ProfileImageDto
    {
        public int Id { get; set; }
        public string UrlPhoto { get; set; }
        public IFormFile FileImage ;
    }
}
