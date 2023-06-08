using Lab.Domain.Dto;
using Lab.Domain.Dto.Ubication;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicationController : ControllerBase
    {
        private IUbicationServices _ubicationServices;


        public UbicationController(IUbicationServices ubicationServices)
        {
            _ubicationServices = ubicationServices;
        }


        [HttpGet]
        [Route("GetAll")]

        public IActionResult GetAll()
        {
            List<GetUbicationDto> result = _ubicationServices.GetAll();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });

        }

    }
}
