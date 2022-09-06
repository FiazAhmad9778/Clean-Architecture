using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace iHakeem.Api.Middleware.Logging
{
    /// <summary>
    ///     Performs request/response formatting for logging.
    /// </summary>
    public static class RequestResponseFormatter
    {
        /// <summary>
        ///     Formats http request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequest" />.</param>
        /// <param name="body">The body as <c>string</c>.</param>
        /// <param name="headers">The headers key need to included in result.</param>
        /// <returns>Log-formatted request string.</returns>
        public static string FormatRequest(HttpRequest request, string body, HashSet<string> headers)
        {
            return
                $"REQUEST: {request.Scheme} {request.Host}{request.Path} {request.QueryString} {body} {FormatHeaders(request.Headers, headers)}";
        }

        /// <summary>
        ///     Formats http response.
        /// </summary>
        /// <param name="response">The <see cref="HttpResponse" />.</param>
        /// <param name="body">The body as <c>string</c>.</param>
        /// <param name="headers">The headers key need to included in result.</param>
        /// <returns>Log-formatted response string.</returns>
        public static string FormatResponse(HttpResponse response, string body, HashSet<string> headers)
        {
            return $"RESPONSE: {response.StatusCode}: {body} {FormatHeaders(response.Headers, headers)}";
        }

        private static string FormatHeaders(IHeaderDictionary headers, HashSet<string> headersToInclude)
        {
            if (headersToInclude?.Any() != true)
            {
                return string.Empty;
            }

            List<KeyValuePair<string, StringValues>> foundHeaders =
                headers.Where(header => headersToInclude.ToList().Contains(header.Key)).ToList();

            if (!foundHeaders.Any())
            {
                return string.Empty;
            }

            string headersAsText = string.Join(", ", foundHeaders.Select(header => $"[{header.Key}: {header.Value}]"));
            return $"HEADERS: {headersAsText}";
        }
    }
}
