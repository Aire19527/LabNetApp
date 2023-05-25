﻿using Common.Helpers;
using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Dto.User;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;
using System;
using static Common.Constant.Const;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            IActionResult action;

            List<GetUserDto> result = _userServices.GetAll();
            ResponseDto response = new ResponseDto();

            if (result != null)
            {
                response.IsSuccess = true;
                response.Message = string.Empty;
                response.Result = result;
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

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            IActionResult action;

            bool result = await _userServices.Delete(id);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = string.Empty,
                Message = result ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted
            };
            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }


        [HttpPut]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(UserPasswordDto password)
        {
            IActionResult action;
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);

            bool result = await _userServices.UpdatePassword(password, Convert.ToInt32(idUser));

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = string.Empty,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoUpdated
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
            IActionResult action;
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdRol);

            bool result = await _userServices.Update(tokenDto, newPass);

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = string.Empty,
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
