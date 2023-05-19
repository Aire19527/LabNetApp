using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.ProfileSkill;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Lab.Domain.Dto.Profile;
using Common.Resources;
using Microsoft.AspNetCore.Cors;
using System;

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
        public async Task<IActionResult> GetAll()
        {
            List<ConsultProfileDto> result = await _profileServices.Getall();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult GetById(int id)
        {

            IActionResult action;

            ConsultProfileDto result = _profileServices.GetById(id);

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
        [Route("FilterSkills")]
        public IActionResult FilterProfileBySkills([FromQuery(Name = "skills")]List<int> skills)
        {
            IActionResult action;

            IEnumerable<ProfilesDto> result = _profileServices.FilterBySkill(skills);
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

        [HttpPost]
        [Route("AddSkillToProfile")]
        public async Task<IActionResult> AddSkillToProfile(AddProfileSkillDto addProfileSkillDto)
        {
            IActionResult action;

            bool result = await _profileServices.AddSkillToProfile(addProfileSkillDto);
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
        [Route("DeleteSkillToProfile")]
        public async Task<IActionResult> DeleteSkillToProfile(AddProfileSkillDto addProfileSkillDto)
        {
            IActionResult action;

            bool result = await _profileServices.DeleteSkillToProfile(addProfileSkillDto);
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
