using System;

namespace iHakeem.Infrastructure.Common.Localization.Extensions
{
    /// <summary>
    ///     Provides methods to get localization keys for enums.
    /// </summary>
    public static class EnumLocalizationKeyExtensions
    {
        /// <summary>
        ///     Gets localization key for enum value.
        /// </summary>
        /// <param name="value">Value of enum to get localization key.</param>
        /// <returns>Localization key,.</returns>
        public static string GetLocalizationKey(this Enum value)
        {
            return $"{value.GetType().Name}_{value.ToString()}";
        }

        /// <summary>
        ///     Gets localization key with specific <paramref name="postfix" /> for enum value.
        /// </summary>
        /// <param name="value">Value of enum to get localization key.</param>
        /// <param name="postfix">Postfix for enum value.</param>
        /// <returns>Localization key,.</returns>
        public static string GetLocalizationKey(this Enum value, string postfix)
        {
            return $"{value.GetType().Name}_{value.ToString()}_{postfix}";
        }
    }
}
