namespace iHakeem.Infrastructure.Common.Exceptions
{
#pragma warning disable CA1032 // Implement standard exception constructors

    /// <summary>
    ///     Represents unauthorized access exception.
    /// </summary>
    public class UnauthorizedException : CodedException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnauthorizedException" /> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public UnauthorizedException(string message)
            : base(ErrorCode.Unauthorized, message)
        {
        }
    }
#pragma warning restore CA1032 // Implement standard exception constructors
}
