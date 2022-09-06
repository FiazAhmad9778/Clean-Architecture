using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace iHakeem.Api.Middleware.Logging
{
    /// <summary>
    ///     Middleware for request/response logging.
    /// </summary>
    public class RequestResponseLoggingMiddleware : IMiddleware
    {
        private readonly ILoggingBehaviorProvider _behaviorProvider;
        private readonly IRequestLogger _requestLogger;
        private readonly IResponseLogger _responseLogger;

        public RequestResponseLoggingMiddleware(
            IRequestLogger requestLogger,
            IResponseLogger responseLogger,
            ILoggingBehaviorProvider behaviorProvider)
        {
            _requestLogger = requestLogger;
            _responseLogger = responseLogger;
            _behaviorProvider = behaviorProvider;
        }

        /// <summary>
        ///     Process current response to log request/response.
        /// </summary>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            LoggingBehavior requestBehavior = _behaviorProvider.GetRequestBehavior(context.Request);
            await _requestLogger.LogAsync(context, requestBehavior);

            LoggingBehavior responseBehavior = _behaviorProvider.GetResponseBehavior(context.Request);
            if (responseBehavior != LoggingBehavior.Full)
            {
                await next(context);
                await _responseLogger.LogAsync(context, responseBehavior);
            }
            else
            {
                // Copy a pointer to the original response body stream
                Stream originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    await next(context);

                    await _responseLogger.LogAsync(context, responseBehavior);

                    // Copy the contents of the new memory stream (which contains the response) to the original stream, which is then returned to the client.
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
        }
    }
}
