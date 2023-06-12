using Common.Exceptions;
using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto.Work;
using Lab.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Services
{
    public class WorkServices : IWorkServices
    {

        #region Attributes
        private readonly IUnitOfWork _unitOfWork;

        #region Builder
        public WorkServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<List<ConsultWorkDto>> Getall()
        {
            IEnumerable<WorkEntity> workEntitie =
                _unitOfWork.WorkRepository.GetAll(s => s.SectorEntity,
                    u => u.UbicationEntity, wt => wt.WorkTypeEntity
                );

            List<ConsultWorkDto> consultWorkDtosList = workEntitie.Select(w => new ConsultWorkDto()
            {
                IdWork = w.Id,
                Company = w.Company,
                Role = w.Role,
                DetailFuntion = w.DetailFuntion,
                BossName = w.BossName,
                BossContact = w.BossContact,
                BossRole = w.BossRole,
                UbicationName = w.UbicationEntity.Description,
                SectorName = w.SectorEntity.Description,
                WorkTypeName = w.WorkTypeEntity.Description,
                StartDate = w.StartDate,
                EndDate = w.EndDate,
                IsCurrent = w.IsCurrent,

            }).ToList();

            return consultWorkDtosList;
        }

        public async Task<bool> Insert(AddWorkDto addWorkDto)
        {
            WorkEntity workEntity = new WorkEntity()
            {
                Company = addWorkDto.Company,
                Role = addWorkDto.Role,
                IdProfile = addWorkDto.IdProfile,
                IdSector = addWorkDto.IdSector,
                IdUbication = addWorkDto.IdUbication,
                IdWorkType = addWorkDto.IdWorkType,
                IdJobPosition = addWorkDto.IdJobPosition,
                EndDate = addWorkDto.IsCurrent ? null : addWorkDto.EndDate,
                StartDate = addWorkDto.StartDate,
                IsCurrent = addWorkDto.IsCurrent,
            };

            _unitOfWork.WorkRepository.Insert(workEntity);
           
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> Update(ModifyWorkDto modifyWorkDto)
        {
            WorkEntity workEntity = _unitOfWork.WorkRepository
                .FirstOrDefault(x => x.Id == modifyWorkDto.Id);

            if (workEntity != null)
            {
                workEntity.Company = modifyWorkDto.Company;
                workEntity.Role = modifyWorkDto.Role;
                workEntity.BossRole = modifyWorkDto.BossRole;
                workEntity.BossContact = modifyWorkDto.BossContact;
                workEntity.BossName = modifyWorkDto.BossName;
                workEntity.IdSector = modifyWorkDto.IdSector;
                workEntity.IdUbication = modifyWorkDto.IdUbication;
                workEntity.IdWorkType = modifyWorkDto.IdWorkType;
                workEntity.IdJobPosition = modifyWorkDto.IdJobPosition;
                workEntity.StartDate = modifyWorkDto.StartDate;
                workEntity.EndDate = modifyWorkDto.IsCurrent? null : modifyWorkDto.EndDate;
                workEntity.IsCurrent = modifyWorkDto.IsCurrent;

                _unitOfWork.WorkRepository.Update(workEntity);
                return await _unitOfWork.Save() > 0;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            WorkEntity workEntity = _unitOfWork.WorkRepository.
                FirstOrDefault((x) => x.Id == id);

            if (workEntity == null) 
                throw new BusinessException(GeneralMessages.ItemNoFound);

                _unitOfWork.WorkRepository.Delete(workEntity);
                return await _unitOfWork.Save() > 0;
        }
        #endregion
    }
}