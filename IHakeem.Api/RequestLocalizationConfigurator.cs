using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using iHakeem.Infrastructure.Common.Localization.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace iHakeem.Api
{
    /// <summary>
    ///     Provides methods to create options.
    /// </summary>
    public static class RequestLocalizationConfigurator
    {
        /// <summary>
        ///     Creates new instance of the <see cref="RequestLocalizationOptions" /> class.
        /// </summary>
        /// <param name="provider">The instance of <see cref="IServiceProvider" />.</param>
        /// <returns>New instance of the <see cref="RequestLocalizationOptions" /> class.</returns>
        public static RequestLocalizationOptions GetRequestLocalizationOptions(IServiceProvider provider)
        {
            var localizationOptions = provider.GetRequiredService<IOptions<LocalizationOptions>>();
            List<CultureInfo> supportedCultures = localizationOptions.Value.SupportedCultures
                .Select(culture => new CultureInfo(culture))
                .ToList();

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(localizationOptions.Value.DefaultCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            };

            return options;
        }
    }
}
