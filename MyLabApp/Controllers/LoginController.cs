using Common.Resources;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Lab.Domain.Dto;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;
using System;
using System.Reflection.Metadata.Ecma335;
using static System.Collections.Specialized.BitVector32;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class LoginController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private IActionResult action;
        public LoginController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDto login)
        {
            TokenDto result = _userServices.Login(login);
            ResponseDto response = new ResponseDto();

            if (result != null)
            {
                response.IsSuccess = true;
                response.Result = result;
                response.Message = String.Empty;
                return action = Ok(response);
            }

            else
            {
                response.IsSuccess = false;
                response.Message = string.Empty;
                response.Result = result;
                return action = BadRequest(response);
            }

        }
    }
}
