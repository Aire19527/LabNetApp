using Common.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Question;
using Lab.Domain.Dto.Resquest;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult GetAll()
        {
            IActionResult actionResult = null;

            List<ConsultRequestDto> consultRequestDtos =  _requestService.GetAllRequests();

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

        [HttpGet]
        [Route("GetAllQuestion/{id}")]

        public async Task<IActionResult> GetQuestionAll(int id)
        {
            IActionResult result;

            List<QuestionDto> questionDtosList = await _requestService.GetAllQuestion(id);

            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = questionDtosList
            };

            if (responseDto != null )
            {
                result = Ok(responseDto);
            }
            else { result = BadRequest(responseDto); }

            return result;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(ModifyRequestDto modifyRequestDto)
        {
            IActionResult actionResult;

            bool requestUpdate = await _requestService.Update(modifyRequestDto);

            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = true,
                Message = requestUpdate ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted,
                Result = requestUpdate
            };

            if (requestUpdate)
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
        public async Task<IActionResult> Insert([FromBody] InsertRequestDto insertRequestDto)
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