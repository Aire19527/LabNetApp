﻿using Common.Resources;
using Lab.Domain.Dto.Work;
using Lab.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab.Domain.Services.Interfaces;
using Lab.Domain.Dto.AssessmentUser;
using Common.Helpers;
using static Common.Constant.Const;
using Microsoft.AspNetCore.Authorization;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AssessmentUserController : ControllerBase
    {
        private readonly IAssessmentUserService _assessmentUserService;

        public AssessmentUserController(IAssessmentUserService assessmentUserService)
        {
            _assessmentUserService = assessmentUserService;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AddAssessmentUserDto addAssessmentUserDto)
        {
            IActionResult action;

            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);

            bool result = await _assessmentUserService.Insert(addAssessmentUserDto, int.Parse(idUser));

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted,
                Result = result
            };

            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }
    }
}
