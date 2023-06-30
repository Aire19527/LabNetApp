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

        public RequestController(IRequestService requestService)
        {
            this._requestService = requestService;
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
    }
}
