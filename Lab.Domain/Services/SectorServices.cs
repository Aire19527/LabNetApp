using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Role;
using Lab.Domain.Dto.Sector;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class SectorServices : ISectorServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SectorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<GetSectorDto> Getall()
        {
            IEnumerable<SectorEntity> sectorQuery = _unitOfWork.SectorRepository.GetAll();


            List<GetSectorDto> sectores = sectorQuery.Select(x => new GetSectorDto()
            {
                Id = x.Id,
                Description = x.Description
            })
            .ToList();

            return sectores;
        }

        public async Task<bool> Insert(AddSectorDto add)
        {
            if (_unitOfWork.SectorRepository.FirstOrDefault(x => x.Description.Equals(add.Description)) != null)
                throw new BusinessException("No se puede insertar un registro duplicado");

            SectorEntity sector = new SectorEntity()
            {
                Description = add.Description
            };
            _unitOfWork.SectorRepository.Insert(sector);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            SectorEntity? sector = _unitOfWork.SectorRepository.FirstOrDefault((sector) => sector.Id == id);

            if (sector == null)
                throw new BusinessException(GeneralMessages.ItemNoFound);

            _unitOfWork.SectorRepository.Delete(sector);

            return await _unitOfWork.Save() > 0;
        }
    }
}
