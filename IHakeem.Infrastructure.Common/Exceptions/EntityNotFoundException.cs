using System;

namespace iHakeem.Infrastructure.Common.Exceptions
{
    /// <summary>
    ///     Entity not found exception.
    /// </summary>
    public class EntityNotFoundException : CodedException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityNotFoundException" /> class.
        /// </summary>
        public EntityNotFoundException()
            : base(ErrorCode.EntityNotFound)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityNotFoundException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public EntityNotFoundException(string message)
            : base(ErrorCode.EntityNotFound, message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityNotFoundException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception. If the inner parameter is not
        ///     null, the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        public EntityNotFoundException(string message, Exception innerException)
            : base(ErrorCode.EntityNotFound, message, innerException)
        {
        }
    }
}
