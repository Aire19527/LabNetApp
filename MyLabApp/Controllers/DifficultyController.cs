using Lab.Domain.Dto;
using Lab.Domain.Dto.Difficulty;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class DifficultyController : ControllerBase
    {
        private readonly IDifficultyService _difficultyService;

        public DifficultyController(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllDifficulty()
        {
            IActionResult actionResult = null;

            List<ConsultDifficulty> consultDifficulties = _difficultyService.GetAll();

            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = consultDifficulties
            };

            if (responseDto != null)
            {
                actionResult = Ok(responseDto);
            }
            else
            {
                actionResult = BadRequest(responseDto);
            }

            return actionResult;
        }
    }
}