using System;
using System.Collections.Generic;
using System.Globalization;

namespace iHakeem.SharedKernal
{
    /// <summary>
    ///     Parses primitive types.
    /// </summary>
    public static class PrimitiveParser
    {
        private static readonly IDictionary<Type, Func<string, object>> TypeConverters =
            new Dictionary<Type, Func<string, object>>
            {
                [typeof(Guid)] = value => Guid.Parse(value),
            };

        /// <summary>
        ///     Parses primitive types from string (including nullable types).
        /// </summary>
        /// <param name="value">Value to parse.</param>
        /// <typeparam name="T">Type of expected value.</typeparam>
        /// <exception cref="FormatException">On invalid input format.</exception>
        /// <returns>Parsed value.</returns>
        public static T Parse<T>(string value)
        {
            Type type = typeof(T);
            type = Nullable.GetUnderlyingType(type) ?? type;

            if (TypeConverters.ContainsKey(type))
            {
                return (T)TypeConverters[type](value);
            }

            if (type.IsEnum)
            {
                return (T)Enum.Parse(type, value);
            }

            return string.IsNullOrWhiteSpace(value)
                ? default
                : (T)Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
        }
    }
}
