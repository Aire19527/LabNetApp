using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Dto.User;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;
using System;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private IActionResult action;

        public UserController(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AddUserDto user)
        {
            bool result = await _userServices.Insert(user);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = String.Empty,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.RegisteredEmail
            };

            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<GetUserDto> result = _userServices.GetAll();

            ResponseDto response = new ResponseDto();

            if(result != null)
            {
                response.IsSuccess = true;
                response.Message = string.Empty;
                response.Result = result;
                return action = Ok(response);
            }
            else {
                response.IsSuccess = false;
                response.Message = string.Empty;
                response.Result = result;
                return action = BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _userServices.Delete(id);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = String.Empty,
                Message = result ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted
            };
            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(TokenDto tokenDto, string newPass) 
        {
            bool result = await _userServices.Update(tokenDto,newPass);

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = String.Empty,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoUpdated
            };

            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
          
        }

    }
}
