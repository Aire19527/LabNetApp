using Lab.Domain.Dto.JobPosition;
using Lab.Domain.Dto;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Lab.Domain.Dto.NewFolder;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class InstitutionTypeController : ControllerBase
    {
            private readonly IInstitutionTypeServices _InstitutionTypeServices;

            public InstitutionTypeController(IInstitutionTypeServices institutionTypeServices)
            {
                _InstitutionTypeServices = institutionTypeServices;
            }

            [HttpGet]
            [Route("GetAll")]
            public async Task<IActionResult> GetAll()
            {
                List<InstitutionTypeDto> consultJobPositionDto = await
                     _InstitutionTypeServices.Getall();

                return Ok(new ResponseDto()
                {
                    IsSuccess = true,
                    Message = string.Empty,
                    Result = consultJobPositionDto
                });
            }
    }

}

