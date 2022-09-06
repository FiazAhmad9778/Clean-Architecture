using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace iHakeem.Api.Middleware.Logging
{
    /// <summary>
    ///     Http response logger.
    /// </summary>
    public interface IResponseLogger
    {
        /// <summary>
        ///     Logs Http response.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext" />.</param>
        /// <param name="loggingBehavior">Logging behavior to perform logging appropriately.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        Task LogAsync(HttpContext context, LoggingBehavior loggingBehavior);
    }
}
