using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.AnswerQuestion
{
    public class AnswerQuestionDto
    {
        [Required]
        public int IdAnswer { get; set; }
        [Required]
        public int IdQuestion { get; set; }

        [Required]
        public bool isCorrect { get; set; }
    }
}
