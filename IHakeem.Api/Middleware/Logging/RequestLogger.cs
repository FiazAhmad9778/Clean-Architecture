using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace iHakeem.Api.Middleware.Logging
{
    /// <inheritdoc />
    public class RequestLogger : IRequestLogger
    {
        private static readonly HashSet<string> LogRequestHeaders = new HashSet<string>();

        private readonly ILogger<RequestLogger> _logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RequestLogger" /> class.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger" />.</param>
        public RequestLogger(ILogger<RequestLogger> logger)
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
                bodyAsText = await FormatBody(context.Request);
            }

            string requestLog = RequestResponseFormatter.FormatRequest(context.Request, bodyAsText, LogRequestHeaders);

            _logger.LogInformation(requestLog);
        }

        private static async Task<string> FormatBody(HttpRequest request)
        {
            var bodyStr = string.Empty;

            // Allows using several time the stream in ASP.Net Core
            request.EnableBuffering();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader
                      = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = await reader.ReadToEndAsync();
            }

            // Rewind, so the core is not lost when it looks the body for the request
            request.Body.Position = 0;
            return bodyStr;
        }
    }
}
