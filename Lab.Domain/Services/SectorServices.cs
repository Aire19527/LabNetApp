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

        public Task<bool> Insert(AddSectorDto add)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
