using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.AnswerQuestion;
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
        Task<int> Insert(AnswerFileDto add);
        Task<AnswerEntity> InsertToQuestion(AnswerFileDto answerFile);
        Task<bool> Delete(int id);
        Task<bool> DeleteAnswerToQuestion(int idQuestion, int idAnswer);
        GetAnswerDto getById(int id);
        List<GetAnswerDto> getAll();
        Task<bool> InsertAnswerInQuestion(AddAnswerQuestion add);
        
    }
}
