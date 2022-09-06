using System;

namespace iHakeem.Infrastructure.Common
{
    /// <inheritdoc />
    public class DateTimeProvider : IDateTimeProvider
    {
        /// <inheritdoc />
        public DateTime PlatformSpecificNow => DateTime.UtcNow;
    }
}
