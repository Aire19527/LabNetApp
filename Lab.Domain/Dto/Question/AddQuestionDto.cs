using Infraestructure.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Domain.Dto.File;

namespace Lab.Domain.Dto.Question
{
    public class AddQuestionDto
    {
        public string Description { get; set; }
        public int Value { get; set; }
        public int? IdSkill { get; set; }
        public int? IdFile { get; set; }
        public AddFileDto? Image { get; set; }

    }
}
