﻿using Lab.Domain.Dto.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IRoleServices
    {
        public List<GetRoleDto> GetAll();
    }
}
