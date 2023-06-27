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
using Lab.Domain.Dto.File;
using Lab.Domain.Dto.Answer;
using Infraestructure.Entity.Models;

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
        [Route("Insert")]
        //public async Task<IActionResult> Insert([FromForm] QuestionFileDto add)
        public async Task<IActionResult> Insert(QuestionFileDto add)
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

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {
            IActionResult action;
            QuestionDto result = _questionServices.getById(id);


            ResponseDto rpdto = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            };

            if (result != null)
                action = Ok(rpdto);
            else
                action = BadRequest(rpdto);

            return action;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult GetAll()
        {
            IActionResult action;
            List<QuestionDto> result = _questionServices.getAll();


            ResponseDto rpdto = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            };

            if (result != null)
                action = Ok(rpdto);
            else
                action = BadRequest(rpdto);

            return action;
        }

        [HttpDelete]
        [Route("Delete/{id}")] 
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _questionServices.Delete(id);

            return Ok(new ResponseDto()
            {
                IsSuccess = res,
                Message = res ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted,
                Result = res
            });
        }
    }
}
