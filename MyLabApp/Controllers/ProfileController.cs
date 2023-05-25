using Common.Resources;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Profile;
using Lab.Domain.Dto.ProfileSkill;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Lab.Domain.Dto.ProfileImage;

using MyLabApp.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
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
        [Route("DeleteSkillToProfile/{idProfile}/{idSkill}")]
        public async Task<IActionResult> DeleteSkillToProfile(int idProfile,int idSkill)
        {
            IActionResult action;

            bool result = await _profileServices.DeleteSkillToProfile(idProfile,idSkill);
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

        [HttpGet]
        [Route("GetProfileSkill/{id}")]
        public IActionResult GetProfileSkill(int id)
        {
            IActionResult action;

            IEnumerable<ConsultSkllDto> result = _profileServices.GetProfileSkill(id);

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

        [HttpPut]
        [Route("UpdateImage")]

        public async Task<IActionResult> UpdateImage([FromForm] ProfileFileDto updateImage )
        {
            IActionResult action;

            string result = await _profileServices.UpdateImage(updateImage);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = !string.IsNullOrEmpty(result),
                Result = result,
                Message = !string.IsNullOrEmpty(result) ? "Imagen Actualizada satisfatoriamente" : "Imagen Actualizada satisfatoriamente"
            };

            if (!string.IsNullOrEmpty(result))
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }

        [HttpPut]
        [Route("UpdateResumee")]
        [Consumes("multipart/form-data")]


        public async Task<IActionResult> UpdateResumee([FromForm] ProfileFileDto updateResumee)
        {
            IActionResult action;

            string result = await _profileServices.UpdateResumee(updateResumee);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = !string.IsNullOrEmpty(result),
                Result = result,
                Message = !string.IsNullOrEmpty(result) ? "CV Actualizado satisfatoriamente" : "El CV no pudo ser actualizado.."
            };

            if (!string.IsNullOrEmpty(result))
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }
        #endregion
    }
}
