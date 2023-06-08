using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Ubication;
using Lab.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class UbicationServices : IUbicationServices
    {
        private readonly IUnitOfWork _unitOfWork;
       

        public UbicationServices(IUnitOfWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }
        public List<GetUbicationDto> GetAll()
        {
             
             IEnumerable<UbicationEntity> queryUbications = _unitOfWork.UbicationRepository.GetAll();

            List<GetUbicationDto> ubications = queryUbications.Select(x => new GetUbicationDto()
            {
                Id = x.Id,
                Descripcion= x.Description
            }).ToList();

            return ubications;


        }
    }
}
