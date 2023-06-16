using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IAnswerService
    {
        Task<bool> Insert(AnswerFileDto add);
        Task<bool> Delete(int id);
        GetAnswerDto getById(int id);
        List<GetAnswerDto> getByQuestion(int idQuestion);
        
    }
}
