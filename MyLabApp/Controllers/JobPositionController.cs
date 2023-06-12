using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.JobPosition;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class JobPositionController : ControllerBase
    {
        private readonly IJobPositionServices _jobPositionServices;

        public JobPositionController(IJobPositionServices jobPositionServices) 
        {
            _jobPositionServices = jobPositionServices;
        }

        [HttpGet]
        [Route("GetAllJob")]
        public async Task<IActionResult> GetAll()
        {
           List <ConsultJobPositionDto> consultJobPositionDto = await 
                _jobPositionServices.Getall();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = consultJobPositionDto
            });
        }

        [HttpGet]
        [Route("GetByIdJob/{id}")]
        public IActionResult GetById(int id)
        {
            IActionResult action;
            ConsultJobPositionDto consultJobPositionDtos = 
                _jobPositionServices.GetById(id);

           ResponseDto result =  new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = consultJobPositionDtos
            };

            if (result != null)
                action = Ok(result);
            else
                action = BadRequest(result);

            return action;
        }
    }
}
