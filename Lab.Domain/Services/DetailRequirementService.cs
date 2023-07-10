using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.DetailRequirement;
using Lab.Domain.Dto.Difficulty;
using Lab.Domain.Dto.Question;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class DetailRequirementService : IDetailRequirementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailRequirementService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public DetailRequirementEntity GetDetailRequirement(DetailRequirementDto detailRequirementDto)
        {
            DetailRequirementEntity detailRequirementEntity = new DetailRequirementEntity()
            {
                IdSkill = detailRequirementDto.IdSkill,
                IdDifficulty = detailRequirementDto.IdDifficulty,
                QuantityQuestions = detailRequirementDto.QuantityQuestions,
            };

            return detailRequirementEntity;
        }


        public async Task<bool> Delete(int id)
        {
            DetailRequirementEntity detail = _unitOfWork.DetailRequirementRepository
                .FirstOrDefault(x => x.Id == id);

            if (detail == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.RequestRepository.Delete(detail);

            return await _unitOfWork.Save() > 0;
        }

     
        public List<QuestionDto> GetQuestion(DetailRequirementEntity detailRequirement)
        {

            List<QuestionDto> questionDtosList = new List<QuestionDto>();

            List<QuestionEntity> questionEntitiesList = _unitOfWork.QuestionRepository.FindAllSelect(
                                    x => x.IdDifficulty == detailRequirement.IdDifficulty
                                    && x.QuestionSkillEntities.Any(s => s.IdSkill == detailRequirement.IdSkill),
                                    f => f.FileEntity,
                                    ans=>ans.QuestionAnswerEntities.Select(a=>a.AnswerEntity),
                                    ans=>ans.QuestionAnswerEntities.Select(a=>a.AnswerEntity.FileEntity),
                                    d => d.DifficultyEntity
                                    ).ToList();



            if (questionEntitiesList.Count() < detailRequirement.QuantityQuestions)
            {

                List<QuestionDto> list = questionEntitiesList.Select(x => new QuestionDto()
                {
                    Id = x.Id,
                    Description = x.Description,
                    UrlImg = x.FileEntity?.Url,
                    Difficulty = new ConsultDifficultyDto()
                    {
                        id = x.DifficultyEntity.Id,
                        Description = x.DifficultyEntity.Description,
                        Value = x.DifficultyEntity.Value,
                    },
                    Answers =x.QuestionAnswerEntities.Select(a=>new GetAnswerDto()
                    {
                        Id=a.AnswerEntity.Id,
                        Description=a.AnswerEntity.Description,
                        isCorrect=a.IsCorrect,
                        urlFile=a.AnswerEntity.FileEntity?.Url
                    } ).ToList(),

                }).ToList();

                questionDtosList.AddRange(list);
            }
            else
            {

                Random random = new Random();

                while (questionDtosList.Count() < detailRequirement.QuantityQuestions)
                {
                    int posicionRandom = random.Next(0, questionEntitiesList.Count());

                    QuestionDto questionDto = new QuestionDto()
                    {
                        Id = questionEntitiesList[posicionRandom].Id,
                        Description = questionEntitiesList[posicionRandom].Description,
                        UrlImg = questionEntitiesList[posicionRandom].FileEntity?.Url,
                        Difficulty = new ConsultDifficultyDto()
                        {
                            id = questionEntitiesList[posicionRandom].DifficultyEntity.Id,
                            Description = questionEntitiesList[posicionRandom].DifficultyEntity.Description,
                            Value = questionEntitiesList[posicionRandom].DifficultyEntity.Value,
                        },
                        Answers = questionEntitiesList[posicionRandom].QuestionAnswerEntities.Select(a => new GetAnswerDto()
                        {
                            Id = a.AnswerEntity.Id,
                            Description = a.AnswerEntity.Description,
                            isCorrect = a.IsCorrect,
                            urlFile = a.AnswerEntity.FileEntity?.Url
                        }).ToList(),
                    };

                    if (!questionDtosList.Any(x => x.Id == questionDto.Id))
                        questionDtosList.Add(questionDto);
                }
            }

            return questionDtosList;
        }
    }
}
