using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.Question;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class QuestionServices : IQuestionServices
    {
        #region builder
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        public  QuestionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public QuestionDto getById(int idQuestion)
        {
            QuestionEntity entity = _unitOfWork.QuestionRepository.FirstOrDefault(x => x.Id == idQuestion,
                                                                                  s => s.Skill,
                                                                                  i => i.FileEntity,
                                                                                  a => a.AnswerEntities.Select(x => x.IdQuestion == idQuestion));

            QuestionDto question = new QuestionDto()
            {
                Id = entity.Id,
                Description = entity.Description,
                IdSkill = entity.Skill.Id,
                IdFile = entity.FileEntity.Id,
                Image = entity.FileEntity,
                IsVisible = entity.IsVisible,
                Value = entity.Value,
                AnswerEntities = entity.AnswerEntities.Select(x => new GetAnswerDto()
                {
                    Id = x.Id,
                    Description = x.Description,
                    IsCorrect = x.IsCorrect,
                    IdFile = x.IdFile
                }).ToList()
            };

            return question;
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }


        public bool Insert(AddQuestionDto questionDto)
        {
            throw new NotImplementedException();
        }

        public bool Update(QuestionDto questionDto)
        {
            throw new NotImplementedException();
        }
    }
}
