using System;
using System.Collections.Generic;

namespace iHakeem.Infrastructure.Common.Exceptions
{
    /// <summary>
    ///     Business validation violated exception.
    /// </summary>
    public class ValidationException : CodedException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationException" /> class.
        /// </summary>
        public ValidationException()
            : this(default(string))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ValidationException(string message)
            : base(ErrorCode.ValidationFailed, message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationException" /> class.
        /// </summary>
        /// <param name="errorList">Errors.</param>
        public ValidationException(IEnumerable<string> errorList)
            : base(ErrorCode.ValidationFailed, null, null, errorList)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception. If the inner parameter is not
        ///     null, the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        public ValidationException(string message, Exception innerException)
            : base(ErrorCode.ValidationFailed, message, innerException)
        {
        }
    }
}
