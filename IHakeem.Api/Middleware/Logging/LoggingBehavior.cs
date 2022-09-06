namespace iHakeem.Api.Middleware.Logging
{
    /// <summary>
    ///     Represent behavior for request/response logging.
    /// </summary>
    public enum LoggingBehavior
    {
        /// <summary>
        ///     Skips entire request and response logs.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Logs requests and responses ignoring body.
        /// </summary>
        IgnoreBodyLog = 1,

        /// <summary>
        ///     Logs request and response with body.
        /// </summary>
        Full = 2,
    }
}
