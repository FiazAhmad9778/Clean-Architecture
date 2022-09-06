using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace iHakeem.Infrastructure.Common.Localization.Extensions
{
    public static class StringLocalizerExtensions
    {
        /// <summary>
        ///     Localizes enum value.
        /// </summary>
        /// <param name="localizer"><see cref="IStringLocalizer" />.</param>
        /// <param name="value">Enum value to localize.</param>
        /// <returns>Localized string.</returns>
        public static string Enum(this IStringLocalizer localizer, Enum value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return localizer[value.GetLocalizationKey()];
        }

        /// <summary>
        ///     Localizes enum value.
        /// </summary>
        /// <param name="localizer"><see cref="IStringLocalizer" />.</param>
        /// <param name="value">Enum value to localize.</param>
        /// <param name="postfix">Postfix for enum value.</param>
        /// <returns>Localized string.</returns>
        public static string Enum(this IStringLocalizer localizer, Enum value, string postfix)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return localizer[value.GetLocalizationKey(postfix)];
        }

        /// <summary>
        ///     Get the localized "None" value.
        /// </summary>
        /// <param name="localizer"><see cref="IStringLocalizer" />.</param>
        /// <returns>Localized value.</returns>
        public static string None(this IStringLocalizer localizer)
        {
            return localizer["None"];
        }

        public static string YesNo(this IStringLocalizer localizer, bool value)
        {
            return localizer[value ? LocalizationConstants.YesKey : LocalizationConstants.NoKey];
        }

        public static string Bool(this IStringLocalizer localizer, bool value)
        {
            return localizer[value ? LocalizationConstants.TrueKey : LocalizationConstants.FalseKey];
        }

        public static string TimeSpan(this IStringLocalizer localizer, TimeSpan value)
        {
            var parts = new List<string>(3);
            if (value.Days > 0)
            {
                parts.Add(FormatTimeSpanPart(localizer, "TimeSpan_DaysTemplate", value.Days));
            }

            if (value.Hours > 0)
            {
                parts.Add(FormatTimeSpanPart(localizer, "TimeSpan_HoursTemplate", value.Hours));
            }

            if (value.Minutes > 0)
            {
                parts.Add(FormatTimeSpanPart(localizer, "TimeSpan_MinutesTemplate", value.Minutes));
            }

            return parts.Any() ? string.Join(" ", parts) : FormatTimeSpanPart(localizer, "TimeSpan_MinutesTemplate", 0);
        }

        private static string FormatTimeSpanPart(IStringLocalizer localizer, string templateKey, int value)
        {
            return string.Format(CultureInfo.InvariantCulture, localizer[templateKey], value);
        }
    }
}
