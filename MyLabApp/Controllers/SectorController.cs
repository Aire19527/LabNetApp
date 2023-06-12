using Lab.Domain.Dto.Role;
using Lab.Domain.Dto;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab.Domain.Dto.Sector;
using Common.Resources;
using Lab.Domain.Dto.Skill;
using MyLabApp.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace MyLabApp.Controllers
{
    [TypeFilter(typeof(CustomExceptionHandler))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorServices _sectorServices;

        public SectorController(ISectorServices sectorServices)
        {
            _sectorServices = sectorServices;
        }
        #region Methods
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<GetSectorDto> result = _sectorServices.Getall();

            return Ok(new ResponseDto()
            {
                IsSuccess = true,
                Message = string.Empty,
                Result = result
            });
        }


        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AddSectorDto sector)
        {
            IActionResult action;

            bool result = await _sectorServices.Insert(sector);

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
            bool res = await _sectorServices.Delete(id);

            return Ok(new ResponseDto()
            {
                IsSuccess = res,
                Message = res ? GeneralMessages.ItemDeleted : GeneralMessages.ItemNoDeleted,
                Result = res
            });
        }
        #endregion

    }
}
