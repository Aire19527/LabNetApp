using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Work;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            
        

        #endregion
    }
}
