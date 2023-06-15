using Infraestructure.Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Question
{
    public class ImageFileDto
    {
        public int Id { get; set; }

        public IFormFile Image { get; set; }
    }
}
