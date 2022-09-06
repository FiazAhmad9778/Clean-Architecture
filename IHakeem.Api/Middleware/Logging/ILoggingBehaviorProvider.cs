using Microsoft.AspNetCore.Http;

namespace iHakeem.Api.Middleware.Logging
{
    /// <summary>
    ///     Provides logging strategy for particular request.
    /// </summary>
    public interface ILoggingBehaviorProvider
    {
        /// <summary>
        ///     Gets log behavior for request.
        /// </summary>
        /// <param name="httpRequest">Instance of <see cref="HttpRequest" />.</param>
        /// <returns><see cref="LoggingBehavior" />.</returns>
        LoggingBehavior GetRequestBehavior(HttpRequest httpRequest);

        /// <summary>
        ///     Gets log behavior for response.
        /// </summary>
        /// <param name="httpRequest">Instance of <see cref="HttpRequest" />.</param>
        /// <returns><see cref="LoggingBehavior" />.</returns>
        LoggingBehavior GetResponseBehavior(HttpRequest httpRequest);
    }
}
