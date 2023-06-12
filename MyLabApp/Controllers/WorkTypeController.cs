using Lab.Domain.Dto.Role;
using Lab.Domain.Dto;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab.Domain.Dto.WorkType;
using Microsoft.AspNetCore.Authorization;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class WorkTypeController : ControllerBase
    {
        private IWorkTypeServices _workTypeServices;

        public WorkTypeController( IWorkTypeServices workTypeServices)
        {
            _workTypeServices = workTypeServices;
                
        }



        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<GetWorkTypeDto> result = _workTypeServices.GetAll();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }
    }
}
