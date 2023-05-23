using Common.Exceptions;
using Common.Resources;
using Lab.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace MyLabApp.Handlers
{
    public class CustomExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HttpResponseException responseException = new HttpResponseException();

            ResponseDto response = new ResponseDto();

            if (context.Exception is DuplicatedSkillException)
            {
                responseException.Status = StatusCodes.Status406NotAcceptable;
                response.Message = context.Exception.Message;
                context.ExceptionHandled = true;
            } else if (context.Exception is SkillNotFoundException)
            {
                responseException.Status = StatusCodes.Status400BadRequest;
                response.Message = context.Exception.Message;
                context.ExceptionHandled = true;
            }
            else
            {
                responseException.Status = StatusCodes.Status500InternalServerError;
                response.Result = JsonConvert.SerializeObject(context.Exception);
                response.Message = GeneralMessages.Error500;
                context.ExceptionHandled = true;
            }

            context.Result = new ObjectResult(responseException.value)
            {
                StatusCode = responseException.Status,
                Value = response
            };

        }
    }
}
