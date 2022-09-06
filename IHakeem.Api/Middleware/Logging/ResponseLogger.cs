using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace iHakeem.Api.Middleware.Logging
{
    /// <inheritdoc />
    public class ResponseLogger : IResponseLogger
    {
        private static readonly HashSet<string> LogResponseHeaders = new HashSet<string>
        {
            HttpHeaders.ErrorCode,
            HttpHeaders.ErrorId,
        };

        private readonly ILogger<ResponseLogger> _logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResponseLogger" /> class.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger" />.</param>
        public ResponseLogger(ILogger<ResponseLogger> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task LogAsync(HttpContext context, LoggingBehavior loggingBehavior)
        {
            if (loggingBehavior == LoggingBehavior.None)
            {
                return;
            }

            var bodyAsText = "#ignored#";

            if (loggingBehavior != LoggingBehavior.IgnoreBodyLog)
            {
                bodyAsText = await FormatBody(context.Response);
            }

            string responseLog = RequestResponseFormatter.FormatResponse(
                context.Response,
                bodyAsText,
                LogResponseHeaders);
            _logger.LogInformation(responseLog);
        }

        private static async Task<string> FormatBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
#pragma warning disable CA2000 // CA2000: Dispose objects before losing scope
            string bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
#pragma warning restore CA2000 // CA2000: Dispose objects before losing scope
            response.Body.Seek(0, SeekOrigin.Begin);
            return bodyAsText;
        }
    }
}
