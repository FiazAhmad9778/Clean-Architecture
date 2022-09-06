using iHakeem.Infrastructure.Common.Localization.Options;
using System.Collections.Generic;

namespace iHakeem.Infrastructure.Common.Localization.Options
{
    /// <summary>
    ///     Provides programmatic configuration for localization.
    /// </summary>
    public class LocalizationOptions
    {
        /// <summary>
        ///     Gets or sets collection of supported cultures.
        /// </summary>
        public IEnumerable<string> SupportedCultures { get; set; }

        /// <summary>
        ///     Gets or sets. default culture.
        /// </summary>
        public string DefaultCulture { get; set; }

        /// <summary>
        ///     Gets or sets the localization sources.
        /// </summary>
        public IEnumerable<LocalizationSource> Sources { get; set; }
    }
}
