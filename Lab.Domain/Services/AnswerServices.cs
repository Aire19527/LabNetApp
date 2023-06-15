using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class AnswerServices : IAnswerService
    {
        #region builder
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        public AnswerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<GetAnswerDto> getByQuestion(int idQuestion)
        {
            IEnumerable<AnswerEntity> answerList = _unitOfWork.AnswerRepository.GetAllSelect(x => x.QuestionEntity);

            List<GetAnswerDto> answers = answerList.Select(a => new GetAnswerDto()
            {
                Id = a.Id,
                Description = a.Description,
                IdQuestion = a.IdQuestion,
                IsCorrect = a.IsCorrect,
                IdFile = a.IdFile,
                Image = a.FileEntity
            }).ToList();

            return answers;
        }

        public async Task<bool> Insert(AddAnswerDto add)
        {

            AnswerEntity answer = new AnswerEntity()
            {
                Description = add.Description,
                IdQuestion = add.IdQuestion,
                IdFile = add.IdFile,
                IsCorrect = add.IsCorrect,
            };
            _unitOfWork.AnswerRepository.Insert(answer);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            AnswerEntity? AnswerEntity = _unitOfWork.AnswerRepository.FirstOrDefault((x) => x.Id == id);

            if (AnswerEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.SkillRepository.Delete(AnswerEntity);

            return await _unitOfWork.Save() > 0;
        }

        public GetAnswerDto getById(int id)
        {
            AnswerEntity entity = _unitOfWork.AnswerRepository.FirstOrDefault(x => x.Id == id);

            GetAnswerDto answer = new GetAnswerDto()
            {
                Id = entity.Id,
                Description = entity.Description,
                IdQuestion = entity.IdQuestion,
                IsCorrect = entity.IsCorrect,
                IdFile = entity.IdFile,
                Image = entity.FileEntity
            };

            return answer;
        }
    }
}
