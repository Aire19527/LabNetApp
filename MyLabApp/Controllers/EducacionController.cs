using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Education;
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


    public class EducacionController : ControllerBase
    {
        private readonly IEducationServices _educationServices;

        public EducacionController(IEducationServices educationServices)
        {
            _educationServices = educationServices;
        }


        #region Endpoints

        [HttpPost]
        [Route("/Insert")]
        public async Task<IActionResult> InsertEducation(AddEducationDto add)
        {
            IActionResult action;

            bool result = await _educationServices.Insert(add);

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


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _educationServices.Delete(id);

            return Ok(new ResponseDto()
            {
                IsSuccess = res,
                Message = res ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted,
                Result = res
            });
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(UpdateEducationDto update)
        {
            IActionResult action;

            bool result = await _educationServices.Update(update);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemUpdated : GeneralMessages.ItemNoUpdated
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
