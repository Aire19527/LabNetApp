using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Work;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class WorkController : ControllerBase
    {
        #region Attributes
        private readonly IWorkServices _workServices;
        #endregion


        #region Builder
        public WorkController(IWorkServices workServices)
        {
            _workServices = workServices;
        }
        #endregion

        #region Services
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll() 
        {

            List<ConsultWorkDto> consultWorkDtos = await _workServices.Getall();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = consultWorkDtos
            });
        }

        
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AddWorkDto addWorkDto)
        {
            IActionResult action;

            bool result = await _workServices.Insert(addWorkDto);

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted,
                Result = result
            };

            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(ModifyWorkDto modifyWorkDto)
        {
            IActionResult action;
            bool result = await _workServices.Update(modifyWorkDto);

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Message = result ? GeneralMessages.ItemUpdated : GeneralMessages.ItemNoUpdated,
                Result = result
            };

            if (result)
            {
                action = Ok(response);
            }
            else
            {
                action = BadRequest(response);
            }

            return action;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _workServices.Delete(id);

            return Ok(new ResponseDto
            {
                IsSuccess = result,
                Message = result ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted,
                Result = result
            });
        }
        #endregion
    }
}
