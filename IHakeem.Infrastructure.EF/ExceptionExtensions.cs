using System;
using Microsoft.EntityFrameworkCore;

namespace iHakeem.Infrastructure.EF
{
    /// <summary>
    ///     DataAccess.EF specific exceptions extensions.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        ///     Check if exception is kind of Concurrency update case.
        /// </summary>
        /// <param name="exception">Original exception to check.</param>
        /// <returns><c>True</c> if Concurrency error, otherwise <c>false</c>.</returns>
        /// <remarks>This is abstraction to keep Infrastructure Ignorance principal.</remarks>
        public static bool IsConcurrentUpdateException(this Exception exception)
        {
            return exception is DbUpdateConcurrencyException;
        }
    }
}
