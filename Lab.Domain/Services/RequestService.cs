using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Resquest;
using Lab.Domain.Services.Interfaces;

namespace Lab.Domain.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDetailRequirementService _detailRequirement;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ConsultRequestDto>> GetAllRequests()
        {
            IEnumerable<RequestEntity> requestEntities =
                _unitOfWork.RequestRepository.GetAll();

            List<ConsultRequestDto> consultRequestDtos = requestEntities
                .Select(x => new ConsultRequestDto()
                {
                    IdRequest = x.Id,
                    TitleRequest = x.Title,
                    TimeInMinutes = x.TimeInMinutes,
                    PercentageMinimoRequired = x.PercentageMinimoRequired,
                }).ToList();

            return consultRequestDtos;
        }
        public async Task<bool> Insert(InsertRequestDto insertRequestDto)
        {
            List<DetailRequirementEntity> detailRequirementEntities =
                new List<DetailRequirementEntity>();

            List<RequirementQuestionEntity> requirementQuestionEntities =
                new List<RequirementQuestionEntity>();

            using (var db = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    if (insertRequestDto.DetailRequirements.Any())
                    {
                        foreach (var item in insertRequestDto.DetailRequirements)
                        {
                            DetailRequirementEntity detailRequirementEntity = await _detailRequirement.GetDetailRequirement(item);
                            detailRequirementEntities.Add(detailRequirementEntity);
                        }
                    }

                    if (!insertRequestDto.DetailRequirements.Any())
                        throw new BusinessException("Detalle Requerido");

                    if (!insertRequestDto.QuestionsRequired.Any())
                        throw new BusinessException("Pregunta requerida");

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

                    await _unitOfWork.Save();
                    await db.CommitAsync();

                    return true;
                }
                catch (BusinessException ex)
                {
                    await db.RollbackAsync();

                    throw ex;
                }
                catch (Exception ex)
                {
                    await db.RollbackAsync();

                    throw new Exception(GeneralMessages.Error500, ex);
                }
            }
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