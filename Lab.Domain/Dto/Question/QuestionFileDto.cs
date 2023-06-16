using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Question {
    public class QuestionFileDto {

        public string Description { get; set; }
        public int Value { get; set; }
        public int IdSkill { get; set; }
        public string FileName { get; set; }
        //To add File...
        public IFormFile File { get; set; }

    }
}
