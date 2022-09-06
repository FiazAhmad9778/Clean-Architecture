using System;
using System.Threading.Tasks;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.Infrastructure.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace iHakeem.Api.Middleware
{
    /// <summary>
    ///     Middleware for exception handling.
    /// </summary>
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IOptions<MvcNewtonsoftJsonOptions> _options;

        public ExceptionHandlingMiddleware(
            ILogger<ExceptionHandlingMiddleware> logger,
            IOptions<MvcNewtonsoftJsonOptions> options)
        {
            _logger = logger;
            _options = options;
        }

        /// <summary>
        ///     Process current request to handle exceptions.
        /// </summary>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string errorId = context.TraceIdentifier;

            try
            {

                await next(context);
                HandleNonSuccessResponse(context, errorId);

            }
            catch (Exception exception)
            {
                HandleException(context, exception, errorId);
            }
        }

        private void HandleNonSuccessResponse(HttpContext context, string errorId)
        {
            switch (context.Response.StatusCode)
            {
                case StatusCodes.Status401Unauthorized:
                    SetError(context, StatusCodes.Status401Unauthorized, ErrorCode.Unauthenticated, errorId);
                    break;
                case StatusCodes.Status403Forbidden:
                    SetError(context, StatusCodes.Status403Forbidden, ErrorCode.Unauthorized, errorId);
                    break;
                case StatusCodes.Status404NotFound:
                    SetError(context, StatusCodes.Status404NotFound, ErrorCode.RouteNotFound, errorId);
                    break;
            }
        }

        private void SetError(HttpContext context, int statusCode, ErrorCode code, string errorId)
        {
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.Headers[HttpHeaders.ErrorCode] = code.ToString("d");
            context.Response.Headers[HttpHeaders.ErrorId] = errorId;
        }

        private void HandleException(HttpContext context, Exception exception, string errorId)
        {
            _logger.LogError(exception, $"Error ID: {errorId}");

            if (exception.IsConcurrentUpdateException())
            {
                SetError(context, StatusCodes.Status409Conflict, ErrorCode.ConcurrentModification, errorId);
                return;
            }

            var codedException = exception as CodedException;
            switch (exception)
            {
                case EntityNotFoundException _:
                    SetCodedExceptionError(context, StatusCodes.Status404NotFound, codedException, errorId);
                    break;
                case ValidationException _:
                    SetCodedExceptionError(context, StatusCodes.Status400BadRequest, codedException, errorId);
                    break;
                case UnauthorizedException _:
                    SetCodedExceptionError(context, StatusCodes.Status403Forbidden, codedException, errorId);
                    break;
                case CodedException _:
                    SetCodedExceptionError(context, StatusCodes.Status400BadRequest, codedException, errorId);
                    SetCodedExceptionError(context, StatusCodes.Status400BadRequest, codedException, errorId);
                    break;
                default:
                    SetError(context, StatusCodes.Status500InternalServerError, ErrorCode.UnhandledException, errorId);
                    break;
            }
        }

        private void SetCodedExceptionError(
            HttpContext context,
            int statusCode,
            CodedException exception,
            string errorId)
        {
            SetError(context, statusCode, exception.Code, errorId);
            context.Response.Headers[HttpHeaders.ErrorPayload] = exception.Payload != null
                ? JsonConvert.SerializeObject(exception.Payload, Formatting.None, _options.Value.SerializerSettings)
                : string.Empty;
        }
    }
}
