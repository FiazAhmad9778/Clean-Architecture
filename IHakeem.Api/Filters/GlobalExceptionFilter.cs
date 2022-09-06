using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using iHakeem.Application.Common.Contracts.Common;
using iHakeem.Infrastructure.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iHakeem.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            CodedException exception = context.Exception as CodedException;
            var response = new ResponseDto<object>()
            {
                Status = 0,
                Message = exception?.Payload?.GetType().Name == "String" ? exception?.Payload?.ToString() : "",
                Data = exception?.Payload?.GetType().Name == "String" == false ? exception.Payload : null
            };

            context.ExceptionHandled = true;
            context.Result = new JsonResult(response);
        }
    }
}
