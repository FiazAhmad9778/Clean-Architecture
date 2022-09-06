using System;

namespace iHakeem.Infrastructure.Common
{
    /// <summary>
    ///     Retrieves the current date and/or time.
    /// </summary>
    /// <remarks>Abstraction which gives possibility to mock the system clock.</remarks>
    public interface IDateTimeProvider
    {
        /// <summary>
        ///     Gets a <see cref="DateTime"></see> object whose date and time are set to the current Local date and time.
        /// </summary>
        DateTime PlatformSpecificNow { get; }
    }
}
