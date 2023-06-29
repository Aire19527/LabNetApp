using Lab.Domain.Dto.Difficulty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IDifficultyService
    {
       List<ConsultDifficulty> GetAll();
    }
}