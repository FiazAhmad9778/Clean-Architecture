using System;

namespace iHakeem.Api.Middleware.Logging
{
    /// <summary>
    ///     Represents ignore route descriptor for logging strategy.
    /// </summary>
    public class LoggingIgnoreRoute
    {
        /// <summary>
        ///     Gets or sets the relative route path.
        /// </summary>
        public Uri Path { get; set; }

        /// <summary>
        ///     Gets or sets the HTTP method verb.
        /// </summary>
        public string Method { get; set; }
    }
}
