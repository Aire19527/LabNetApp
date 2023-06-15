using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.File
{
    public class UpdateFileDto : AddFileDto
    {
        public int Id { get; set; }

        public string FileName { get; set; }
        public string Url { get; set; }

        //To add File...
        public IFormFile File { get; set; }

        public int IdProp { get; set; }
    }
}

