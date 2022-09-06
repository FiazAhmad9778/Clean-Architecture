using System.Runtime.Serialization;

namespace iHakeem.Infrastructure.Common.Exceptions
{
    /// <summary>
    ///     Error code which uniquely identifies error category.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        ///     Unhandled error.
        /// </summary>
        UnhandledException = 0,

        /// <summary>
        ///     Unauthenticated access.
        /// </summary>
        Unauthenticated = 1,

        /// <summary>
        ///     Unauthorized access.
        /// </summary>
        Unauthorized = 2,

        /// <summary>
        ///     Route Not found.
        /// </summary>
        RouteNotFound = 3,

        /// <summary>
        ///     Entity not found.
        /// </summary>
        EntityNotFound = 4,

        /// <summary>
        ///     Validation violated.
        /// </summary>
        ValidationFailed = 5,

        /// <summary>
        ///     Concurrent access.
        /// </summary>
        ConcurrentModification = 6,

        InvalidResetPasswordToken = 7,

        EmailNotFound = 8,
        EmailAlreadyExist = 9,
        UserNameAlreadyExist = 10,
        PhoneNumberAlreadyExist = 11,
        /// <summary>
        ///    Provided user code is invalid
        /// </summary>
        InvalidVerificationCode = 12,
        /// <summary>
        ///    User not found with this id.
        /// </summary>
        InvalidUserId = 13,
        UserNamePendingRegisteration = 14,
        InValidUsernameOrPassword = 15,
        InValidOldPassword = 16,
        EmailPendingRegisteration = 17,
        PhoneNumberPendingRegisteration = 18,
        InvalidPatientId = 19,
        InvalidEmail = 20,
        InvalidDoctorId = 21,




    }
}
