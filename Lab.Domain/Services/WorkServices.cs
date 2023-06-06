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
                _unitOfWork.WorkRepository.GetAll();

            List<ConsultWorkDto> consultWorkDtosList = workEntitie.Select(w =>
            new ConsultWorkDto()
            {
                IdWork = w.Id,
                Company = w.Company,
                Role = w.Role,
                DetailFuntion = w.DetailFuntion,
                BossName = w.BossName,
                BossContact = w.BossContact,
                BossRole = w.BossRole,

            }).ToList();

            return consultWorkDtosList;
        }

        public Task<bool> Insert(AddWorkEntity addWorkEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ModifyWorkDto modifyWorkDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}