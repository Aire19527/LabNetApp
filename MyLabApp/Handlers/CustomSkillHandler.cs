using Common.Exceptions;
using Lab.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyLabApp.Handlers
{
    public class CustomSkillHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HttpResponseException responseException = new HttpResponseException();

            ResponseDto response = new ResponseDto();

            if (context.Exception is DuplicatedInsertException) {
                responseException.Status = StatusCodes.Status406NotAcceptable;
                response.Message = context.Exception.Message;
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
