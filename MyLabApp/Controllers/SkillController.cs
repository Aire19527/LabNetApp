using Common.Resources;
using Infraestructure.Entity.Models;
using Lab.Domain.Dto;
using Lab.Domain.Dto.Skill;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Exceptions;
using MyLabApp.Handlers;

namespace MyLabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class SkillController : ControllerBase
    {
        #region Attributes
        private readonly ISkillServices _skillServices;
        #endregion

        #region Builder
        public SkillController(ISkillServices skillServices)
        {
            this._skillServices = skillServices;
        }
        #endregion

       #region Services

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<ConsultSkllDto> result = _skillServices.Getall();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AddSkilDto skill)
        {
            IActionResult action;

            bool result = await _skillServices.Insert(skill);
            
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
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           bool res = await _skillServices.Delete(id);

            return Ok(new ResponseDto()
            {
                IsSuccess = res,
                Message = res ? "se ha borrado":"no se ha borrado",
                Result = res ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted
            });
        }
        #endregion

    }
}
