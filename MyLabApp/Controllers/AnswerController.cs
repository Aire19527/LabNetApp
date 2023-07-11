using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Answer;
using Lab.Domain.Dto.AnswerQuestion;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AnswerController : ControllerBase
    {
        #region Attributes
        private readonly IAnswerService _answerService;
        #endregion

        #region Builder
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        #endregion
        #region Endpoints

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {
            IActionResult action;
            GetAnswerDto result = _answerService.getById(id);


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
        public IActionResult GetAllAnswers ()
        {
            IActionResult action;
            List<GetAnswerDto> result = _answerService.getAll();


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

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromForm]AnswerFileDto add)
        {
            IActionResult action;

            int idInserted = await _answerService.Insert(add);


            ResponseDto rpdto = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = idInserted
            };

            if (idInserted!=null)
                action = Ok(rpdto);
            else
                action = BadRequest(rpdto);
            return action;

        }

        [HttpPost]
        [Route("InsertInQuestion")]
        public async Task<IActionResult> InsertInQuestion([FromBody] AnswerQuestionDto add)
        {
            IActionResult action;

            bool result = await _answerService.InsertAnswerInQuestion(add);


            ResponseDto rpdto = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            };

            if (result)
                action = Ok(rpdto);
            else
                action = BadRequest(rpdto);
            return action;

        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _answerService.Delete(id);

            return Ok(new ResponseDto()
            {
                IsSuccess = res,
                Message = res ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted,
                Result = res
            });
        }


        [HttpDelete]
        [Route("DeleteAnswerToQuestion/{idQuestion}/{idAnswer}")]
        public async Task<IActionResult> DeleteSkillToProfile(int idQuestion, int idAnswer)
        {
            IActionResult action;

            bool result = await _answerService.DeleteAnswerToQuestion(idQuestion, idAnswer);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted
            };

            if (result)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }


        #endregion

    }
}