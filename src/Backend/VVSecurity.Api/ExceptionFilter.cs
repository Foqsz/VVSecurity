using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security;
using VVSecurity.Communication.Responses;
using VVSecurity.Exceptions;

namespace VVSecurity.Api;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is VVSecurityException vvSecurityException)
        {
            context.HttpContext.Response.StatusCode = (int)vvSecurityException.GetStatusCode();

            context.Result = new ObjectResult(new ResponseErrorJson(vvSecurityException.GetErrorMessages()));
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesExceptions.UNKNOWN_ERROR));
        }
    }
}
