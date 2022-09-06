using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace iHakeem.Infrastructure.Common.Exceptions
{
    /// <summary>
    ///     Business exception to stop execution if some business rules are violated.
    /// </summary>
    public class CodedException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        /// <param name="code">Error category.</param>
        public CodedException(ErrorCode code)
            : this(code, default(string))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        /// <param name="code">Error category.</param>
        /// <param name="payload">Payload for error.</param>
        public CodedException(ErrorCode code, object payload)
            : this(code)
        {
            Payload = payload;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        /// <param name="code">Error category.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        protected CodedException(ErrorCode code, string message)
            : this(code, message, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        /// <param name="code">Error category.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="payload">Payload for error.</param>
        protected CodedException(ErrorCode code, string message, object payload)
            : this(code, message)
        {
            Payload = payload;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        /// <param name="code">Error category.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception. If the inner parameter is not
        ///     null, the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        protected CodedException(ErrorCode code, Exception innerException)
            : this(code, null, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        /// <param name="code">Error category.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception. If the inner parameter is not
        ///     null, the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        protected CodedException(ErrorCode code, string message, Exception innerException)
            : base(message, innerException)
        {
            Code = code;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        /// <param name="code">Error category.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception. If the inner parameter is not
        ///     null, the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        /// <param name="errorList">Errors.</param>
        protected CodedException(
            ErrorCode code,
            string message,
            Exception innerException,
            IEnumerable<string> errorList)
            : this(code, message, innerException)
        {
            Code = code;
            ErrorList = errorList;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        protected CodedException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        protected CodedException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CodedException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// ///
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception. If the inner parameter is not
        ///     null, the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        protected CodedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Gets error category.
        /// </summary>
        public ErrorCode Code { get; }

        /// <summary>
        ///     Gets errors as codes.
        /// </summary>
        public IEnumerable<string> ErrorList { get; }

        /// <summary>
        ///     Gets payload for error.
        /// </summary>
        public object Payload { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(ErrorList), ErrorList);
            info.AddValue(nameof(Payload), Payload);
        }
    }
}
