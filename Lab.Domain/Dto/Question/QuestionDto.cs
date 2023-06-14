using Infraestructure.Entity.Models;
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
        public IEnumerable<AnswerEntity>? AnswerEntities { get; set; }

    }
}
