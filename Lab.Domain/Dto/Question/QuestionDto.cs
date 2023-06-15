using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Question
{
    public class QuestionDto : AddQuestionDto
    {
        public int Id { get; set;}
        public bool IsVisible { get; set; }
        public IEnumerable<GetAnswerDto>? AnswerEntities { get; set; }

    }
}
