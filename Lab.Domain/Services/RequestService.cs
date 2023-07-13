using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.DetailRequirement;
using Lab.Domain.Dto.Difficulty;
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

        public async Task<RequestEntity> GetRequestEntity(int idRequest)
        {
            return await _unitOfWork.RequestRepository.FirstOrDefaultAsync(x => x.Id == idRequest);
        }


        public async Task<List<QuestionDto>> GetAllQuestion(int id)
        {
            List<QuestionDto> questionDtosList = new List<QuestionDto>();

            RequestEntity requestEntity = await _unitOfWork.RequestRepository.FirstOrDefaultSelectAsync(x => x.Id == id,
                                                                    d => d.DetailRequirementEntities,
                                                                    f => f.RequirementQuestionEntities.Select(x => x.QuestionEntity.DifficultyEntity),
                                                                    f => f.RequirementQuestionEntities.Select(x => x.QuestionEntity.FileEntity),
                                                                    ans => ans.RequirementQuestionEntities.Select(
                                                                    x => x.QuestionEntity.QuestionAnswerEntities.Select(a => a.AnswerEntity.FileEntity)));

            if (requestEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            foreach (var item in requestEntity.DetailRequirementEntities)
            {
                List<QuestionDto> lista = _detailRequirement.GetQuestion(item);

                if (lista != null)
                    questionDtosList.AddRange(lista);
            }

            if (requestEntity.RequirementQuestionEntities.Any())
            {

                List<QuestionDto> listRequeriment = requestEntity.RequirementQuestionEntities.Select(x => new QuestionDto()
                {
                    Id = x.QuestionEntity.Id,
                    Description = x.QuestionEntity.Description,
                    UrlImg = x.QuestionEntity?.FileEntity?.Url,
                    Difficulty = new ConsultDifficultyDto()
                    {
                        id = x.QuestionEntity.DifficultyEntity.Id,
                        Description = x.QuestionEntity.DifficultyEntity.Description,
                        Value = x.QuestionEntity.DifficultyEntity.Value,
                    },
                    Answers = x.QuestionEntity.QuestionAnswerEntities.Select(a => new GetAnswerDto()
                    {
                        Id = a.AnswerEntity.Id,
                        Description = a.AnswerEntity.Description,
                        isCorrect = a.IsCorrect,
                        urlFile = a.AnswerEntity.FileEntity?.Url
                    }).ToList()
                }).ToList();

                questionDtosList.AddRange(listRequeriment);
            }

            return questionDtosList;
        }

        public List<ConsultRequestDto> GetAllRequests()
        {
            IEnumerable<RequestEntity> requestEntities = _unitOfWork.RequestRepository.GetAllSelect(
                                                                        d => d.DetailRequirementEntities.Select(s => s.SkillEntity),
                                                                        d => d.DetailRequirementEntities.Select(s => s.DifficultyEntity),
                                                                        d => d.RequirementQuestionEntities.Select(s => s.QuestionEntity),
                                                                        d => d.RequirementQuestionEntities.Select(s => s.QuestionEntity.FileEntity),
                                                                        d => d.RequirementQuestionEntities.Select(s => s.QuestionEntity.DifficultyEntity)

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
                    QuestionsRequired = x.RequirementQuestionEntities.Select(q => new QuestionDto()
                    {
                        Id = q.QuestionEntity.Id,
                        Description = q.QuestionEntity.Description,
                        UrlImg = q.QuestionEntity.FileEntity?.Url,
                        Difficulty = new ConsultDifficultyDto()
                        {
                            id = q.QuestionEntity.DifficultyEntity.Id,
                            Description = q.QuestionEntity.DifficultyEntity.Description,
                            Value = q.QuestionEntity.DifficultyEntity.Value,
                        }

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

        public async Task<bool> Delete(int id)
        {
            RequestEntity requestEntity = _unitOfWork.RequestRepository
                .FirstOrDefault(x => x.Id == id);

            if (requestEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.RequestRepository.Delete(requestEntity);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> DeleteToQuestionRequired(int idRequest, int idQuestion)
        {
            RequirementQuestionEntity requirementQuestionEntity =
               _unitOfWork.RequirementQuestionRepository
               .FirstOrDefault(x => x.IdRequest == idRequest &&
                               x.IdQuestion == idQuestion);

            if (requirementQuestionEntity == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.RequirementQuestionRepository.Delete(requirementQuestionEntity);

            return await _unitOfWork.Save() > 0;
        }
    }
}