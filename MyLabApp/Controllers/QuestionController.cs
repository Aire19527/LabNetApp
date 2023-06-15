using Common.Resources;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;
using Lab.Domain.Dto.Question;
using Infraestructure.Core.Migrations;
using Lab.Domain.Dto.File;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class QuestionController : ControllerBase
    {

        #region Attributes
        private readonly IQuestionServices _questionServices;
        #endregion

        #region Builder
        public QuestionController(IQuestionServices questionServices)
        {
           _questionServices = questionServices;
        }
        #endregion


        [HttpPost]
        public async Task<IActionResult> Insert(int number,AddQuestionDto add)
        {
            IActionResult action;

            bool result = await _questionServices.Insert(add);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }
    }
}
