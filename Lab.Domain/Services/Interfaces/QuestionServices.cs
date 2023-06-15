using Lab.Domain.Dto.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services.Interfaces
{
    public class QuestionServices : IQuestionServices
    {
        public List<QuestionDto> getByQuestionId(int idQuestion)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AddQuestionDto questionDto)
        {
            throw new NotImplementedException();
        }

        public bool Update(AddQuestionDto questionDto)
        {
            throw new NotImplementedException();
        }
    }
}
