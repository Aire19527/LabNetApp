using Lab.Domain.Dto.Role;
using Lab.Domain.Dto;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab.Domain.Dto.Sector;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorServices _sectorServices;

        public SectorController(ISectorServices sectorServices)
        {
            _sectorServices = sectorServices;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<GetSectorDto> result = _sectorServices.Getall();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }

    }
}
