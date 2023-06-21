using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Answer
{
    public class AnswerFileDto
    {
        public string Description { get; set; }
        public string? FileName { get; set; }
        //To add File...
        public IFormFile? File { get; set; }
    }
}
