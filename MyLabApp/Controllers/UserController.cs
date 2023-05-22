using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Dto.User;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AddUserDto user)
        {
            IActionResult action;

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

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _userServices.Delete(id);

            return Ok(new ResponseDto()
            {
                IsSuccess = result,
                Message = string.Empty,
                Result = result ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted
            });
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(TokenDto tokenDto, string newPass) 
        {
            bool result = await _userServices.Update(tokenDto,newPass);

            return Ok(new ResponseDto()
            {
                IsSuccess = result,
                Message = string.Empty,
                Result = result ? GeneralMessages.ItemUpdated : GeneralMessages.ItemNoUpdated
            }) ;
        }

    }
}
