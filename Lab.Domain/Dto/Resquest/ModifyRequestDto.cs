﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Resquest
{
    public class ModifyRequestDto : InsertRequestDto
    {
        public int id { get; set; }
    }
}