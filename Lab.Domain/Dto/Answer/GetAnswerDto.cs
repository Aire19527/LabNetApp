using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Answer
{
    public class GetAnswerDto : AddAnswerDto
    {
        public int Id { get; set; }
        public bool isCorrect { get; set; }
        public string? urlFile { get; set; }
    }
}
