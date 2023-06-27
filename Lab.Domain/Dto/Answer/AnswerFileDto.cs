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
        public int IdAnswer { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        //To add File...
        public IFormFile? File { get; set; }
    }
}
