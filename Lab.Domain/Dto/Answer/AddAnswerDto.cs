﻿using Infraestructure.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Answer
{
    public class AddAnswerDto
    {
        public string Description { get; set; }
        public int? IdFile { get; set; }
    }
}
