using Lab.Domain.Dto.File;
using Lab.Domain.Dto.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public interface IQuestionServices
    {
        QuestionDto getById(int idQuestion);
        List<QuestionDto> getAll();
        Task<bool> Insert(QuestionFileDto questionDto);
        Task<bool> Delete(int id);
    }
}
