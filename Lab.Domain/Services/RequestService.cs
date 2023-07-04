using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.DetailRequirement;
using Lab.Domain.Dto.Question;
using Lab.Domain.Dto.Resquest;
using Lab.Domain.Services.Interfaces;

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
                    IdRequest = x.Id,
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
                    requiredQuestions = x.RequirementQuestionEntities.Select(x => new QuestionDto()
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
    }
}