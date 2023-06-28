using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.Skill;
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
        public string SkillDescription { get; set; }
        public bool IsVisible { get; set; }

        public string? UrlImg { get; set; }
        public IEnumerable<GetAnswerDto>? AnswerEntities { get; set; }

        public IEnumerable<ConsultSkllDto>? SkillEntities { get; set; }

    }
}
