using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace iHakeem.Api.Middleware.Logging
{
    /// <summary>
    ///     Http request logger.
    /// </summary>
    public interface IRequestLogger
    {
        /// <summary>
        ///     Logs Http request.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext" />.</param>
        /// <param name="loggingBehavior">Logging behavior to perform logging appropriately.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        Task LogAsync(HttpContext context, LoggingBehavior loggingBehavior);
    }
}
