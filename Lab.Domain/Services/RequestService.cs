﻿using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.DetailRequirement;
using Lab.Domain.Dto.Question;
using Lab.Domain.Dto.Resquest;
using Lab.Domain.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Lab.Domain.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDetailRequirementService _detailRequirement;

        public RequestService(IUnitOfWork unitOfWork, IDetailRequirementService detailRequirementService)
        {
            _unitOfWork = unitOfWork;
            _detailRequirement = detailRequirementService;
        }

        public async Task<List<QuestionDto>> GetAllQuestion(int id)
        {
            List<QuestionDto> questionDtosList = new List<QuestionDto>();

            RequestEntity requestEntity = _unitOfWork.RequestRepository.FirstOrDefaultSelect(x => x.Id == id,
                                                                    d => d.DetailRequirementEntities,
                                                                    f => f.RequirementQuestionEntities.Select(x => x.QuestionEntity.FileEntity),
                                                                    ans => ans.RequirementQuestionEntities.Select(
                                                                                x => x.QuestionEntity.QuestionAnswerEntities.Select(a => a.AnswerEntity.FileEntity)));

            if (requestEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            foreach (var item in requestEntity.DetailRequirementEntities)
            {
                List<QuestionDto> lista =  _detailRequirement.GetQuestion(item);

                if (lista != null)
                    questionDtosList.AddRange(lista);
            }


            if (requestEntity.RequirementQuestionEntities.Any())
            {
                foreach (var item in requestEntity.RequirementQuestionEntities)
                {
                    QuestionDto questionDto = new QuestionDto()
                    {
                        Id = item.QuestionEntity.Id,
                        Description = item.QuestionEntity.Description,
                        UrlImg = item.QuestionEntity.FileEntity?.Url,
                        Answers = item.QuestionEntity.QuestionAnswerEntities.Select(a => new GetAnswerDto()
                        {
                            Id = a.AnswerEntity.Id,
                            Description = a.AnswerEntity.Description,
                            isCorrect = a.isCorrect,
                            urlFile = a.AnswerEntity.FileEntity?.Url
                        }).ToList()
                    };

                    if (!questionDtosList.Any(x => x.Id == questionDto.Id))
                        questionDtosList.Add(questionDto);
                }
            }

            return questionDtosList;
        }

        public async Task<List<ConsultRequestDto>> GetAllRequests()
        {
            IEnumerable<RequestEntity> requestEntities = _unitOfWork.RequestRepository.GetAllSelect(
                                                                        d => d.DetailRequirementEntities.Select(s => s.SkillEntity),
                                                                        d => d.DetailRequirementEntities.Select(s => s.DifficultyEntity),
                                                                        d => d.RequirementQuestionEntities.Select(s => s.QuestionEntity),
                                                                        d => d.RequirementQuestionEntities.Select(s => s.QuestionEntity.FileEntity)
                                                                        );

            List<ConsultRequestDto> consultRequestDtos = requestEntities
                .Select(x => new ConsultRequestDto()
                {
                    Id = x.Id,
                    TitleRequest = x.Title,
                    TimeInMinutes = x.TimeInMinutes,
                    PercentageMinimoRequired = x.PercentageMinimoRequired,
                    DetailRequirements = x.DetailRequirementEntities.Select(x => new ConsultDetailRequirementDto()
                    {
                        id = x.Id,
                        IdDifficulty = x.IdDifficulty,
                        IdSkill = x.IdSkill,
                        skillDescription = x.SkillEntity.Description,
                        difficultDescription = x.DifficultyEntity.Description,
                        QuantityQuestions = x.QuantityQuestions
                    }).ToList(),
                    QuestionsRequired = x.RequirementQuestionEntities.Select(x => new QuestionDto()
                    {
                        Id = x.QuestionEntity.Id,
                        Description = x.QuestionEntity.Description,
                        UrlImg = x.QuestionEntity.FileEntity?.Url,
                    }).ToList(),
                }).ToList();

            return consultRequestDtos;
        }

        public async Task<bool> Insert(InsertRequestDto insertRequestDto)
        {
            List<DetailRequirementEntity> detailRequirementEntities =
                new List<DetailRequirementEntity>();

            if (!insertRequestDto.DetailRequirements.Any())
                throw new BusinessException("Detalle Requerido");


            foreach (var item in insertRequestDto.DetailRequirements)
            {
                DetailRequirementEntity detailRequirementEntity = _detailRequirement.GetDetailRequirement(item);
                detailRequirementEntities.Add(detailRequirementEntity);
            }


            RequestEntity requestEntity = new RequestEntity()
            {
                Title = insertRequestDto.TitleRequest,
                TimeInMinutes = insertRequestDto.TimeInMinutes,
                PercentageMinimoRequired = insertRequestDto.PercentageMinimoRequired,
                CreationDate = DateTime.Now,
                DetailRequirementEntities = detailRequirementEntities,
                RequirementQuestionEntities = insertRequestDto.QuestionsRequired
                .Select(s => new RequirementQuestionEntity()
                {
                    IdQuestion = s
                }).ToList(),
            };

            _unitOfWork.RequestRepository.Insert(requestEntity);

            return await _unitOfWork.Save() > 0;
        }



        public async Task<bool> Delete(int id)
        {
            RequestEntity requestEntity = _unitOfWork.RequestRepository
                .FirstOrDefault(x => x.Id == id);

            if (requestEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.RequestRepository.Delete(requestEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(ModifyRequestDto modifyRequestDto)
        {
            RequestEntity request = _unitOfWork.RequestRepository
                .FirstOrDefault(x => x.Id == modifyRequestDto.id,
                                a => a.DetailRequirementEntities,
                                r => r.RequirementQuestionEntities);
            if (request == null)
                throw new Exception(GeneralMessages.ItemNoFound);

            request.Title = modifyRequestDto.TitleRequest;
            request.PercentageMinimoRequired = modifyRequestDto.PercentageMinimoRequired;
            request.TimeInMinutes = modifyRequestDto.TimeInMinutes;



            if (modifyRequestDto.QuestionsRequired.Any())
            {
                List<RequirementQuestionEntity> requirementQuestionEntities = modifyRequestDto.QuestionsRequired.Select(x => new RequirementQuestionEntity()
                {
                    IdQuestion = x,
                    IdRequest = modifyRequestDto.id,

                }).ToList();

                request.RequirementQuestionEntities = requirementQuestionEntities;
            }

            if (modifyRequestDto.DetailRequirements.Any())
            {

                List<DetailRequirementEntity> detailRequirementEntities = modifyRequestDto.DetailRequirements.Select(x => new DetailRequirementEntity()
                {
                    IdSkill = x.IdSkill,
                    IdDifficulty = x.IdDifficulty,
                    QuantityQuestions = x.QuantityQuestions,
                }).ToList();

                request.DetailRequirementEntities = detailRequirementEntities;
            }

            _unitOfWork.RequestRepository.Update(request);

            return await _unitOfWork.Save() > 0;
        }
    }
}