using Lab.Domain.Dto.Skill;
using Lab.Domain.Dto;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab.Domain.Dto.Profile;
using Common.Resources;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        #region Attributes
        private readonly IProfileServices _profileServices;
        #endregion

        #region Builder
        public ProfileController(IProfileServices profileServices)
        {
            this._profileServices = profileServices;
        }
        #endregion


        #region Services

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<ConsultProfileDto> result = _profileServices.Getall();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById()
        {
            List<ConsultProfileDto> result = _profileServices.Getall();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AddProfileDto profile)
        {
            IActionResult action;

            bool result = await _profileServices.Insert(profile);
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


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(ModifyProfileDto update)
        {
            IActionResult action;

            bool result = await _profileServices.Update(update);
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
