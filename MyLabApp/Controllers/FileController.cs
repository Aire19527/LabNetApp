using Lab.Domain.Dto;
using Lab.Domain.Dto.File;
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
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileServices;


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            IActionResult action;
            GetFileDto result = _fileServices.getById(id, isImg: true);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };


            if (result != null)
                action = Ok(response);
            else
                action = BadRequest(response);

            return action;
        }
    }
}
