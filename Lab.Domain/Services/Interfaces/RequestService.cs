using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Resquest;

namespace Lab.Domain.Services.Interfaces
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
                }).ToList();

            return consultRequestDtos;
        }
        public async Task<bool> Insert(InsertRequestDto insertRequestDto)
        {
            RequestEntity requestEntity = new RequestEntity()
            {
                Title = insertRequestDto.TitleRequest,
                TimeInMinutes = insertRequestDto.TimeInMinutes,
                PercentageMinimoRequired = insertRequestDto.PercentageMinimoRequired,
                CreationDate = DateTime.Now,
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

            _unitOfWork.RequestRepository .Delete(requestEntity);

            return await _unitOfWork.Save() > 0;
        }
    }
}