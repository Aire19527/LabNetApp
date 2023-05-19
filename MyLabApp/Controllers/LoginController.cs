using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Lab.Domain.Dto;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public LoginController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDto login)
        {
            TokenDto result = _userServices.Login(login);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };

            return Ok(response);
        }
    }
}
