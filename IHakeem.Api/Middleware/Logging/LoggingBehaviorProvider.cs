using System;
using System.Collections.Generic;
using System.Linq;
using iHakeem.Application.Common.Constants;
using Microsoft.AspNetCore.Http;

namespace iHakeem.Api.Middleware.Logging
{
    /// <inheritdoc />
    public class LoggingBehaviorProvider : ILoggingBehaviorProvider
    {
        private readonly IEnumerable<LoggingIgnoreRoute> _globalIgnoreRoutes = new List<LoggingIgnoreRoute>
        {
            new LoggingIgnoreRoute
            {
                Path = new Uri($"{Routes.Swagger}", UriKind.Relative),
                Method = null,
            },
            new LoggingIgnoreRoute
            {
                Path = new Uri($"{Routes.SwaggerUiStartPageRoute}", UriKind.Relative),
                Method = null,
            },
        };

        /// <inheritdoc />
        public LoggingBehavior GetRequestBehavior(HttpRequest httpRequest)
        {
            return GetBehavior(httpRequest, _globalIgnoreRoutes);
        }

        /// <inheritdoc />
        public LoggingBehavior GetResponseBehavior(HttpRequest httpRequest)
        {
            return GetBehavior(httpRequest, _globalIgnoreRoutes);
        }

        private static LoggingBehavior GetBehavior(
            HttpRequest httpRequest,
            IEnumerable<LoggingIgnoreRoute> globalIgnoreRoutes)
        {
            if (IsInIgnoreRules(globalIgnoreRoutes, httpRequest))
            {
                return LoggingBehavior.None;
            }

            return LoggingBehavior.Full;
        }

        private static bool IsInIgnoreRules(IEnumerable<LoggingIgnoreRoute> ignoredRoutes, HttpRequest request)
        {
            return ignoredRoutes.Any(
                route => request.Path.StartsWithSegments(
                             new PathString(route.Path.ToString()),
                             StringComparison.OrdinalIgnoreCase)
                         && (string.IsNullOrWhiteSpace(route.Method) || string.Equals(
                                 request.Method,
                                 route.Method,
                                 StringComparison.OrdinalIgnoreCase)));
        }
    }
}
