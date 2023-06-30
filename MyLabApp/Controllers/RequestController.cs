using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Resquest;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IUnitOfWork _unitOfWork;

        public RequestController(IRequestService requestService, IUnitOfWork unitOfWork)
        {
            this._requestService = requestService;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult actionResult = null;

            List<ConsultRequestDto> consultRequestDtos = await _requestService.GetAllRequests();

            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = consultRequestDtos
            };

            if (responseDto != null)
            {
                actionResult = Ok(responseDto);
            }
            else
            {
                actionResult = BadRequest(responseDto);
            }

            return actionResult;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(InsertRequestDto insertRequestDto)
        {
            IActionResult actionResult;

            bool requestinserted = await _requestService.Insert(insertRequestDto);

            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = true,
                Message = requestinserted ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted,
                Result = requestinserted
            };

            if (requestinserted)
            {
                actionResult = Ok(responseDto);
            }
            else
            {
                actionResult= BadRequest(responseDto);
            }

            return actionResult;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            bool requestDelete = await _requestService.Delete(id);

            return Ok( new ResponseDto
            {
                IsSuccess= true,
                Message = requestDelete ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted,
                Result = requestDelete
            });
        }
    }
}