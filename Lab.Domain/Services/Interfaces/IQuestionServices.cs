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
        List<QuestionDto> getByQuestionId(int idQuestion);
        bool Insert(AddQuestionDto questionDto);
        bool Update(AddQuestionDto questionDto);

    }
}
