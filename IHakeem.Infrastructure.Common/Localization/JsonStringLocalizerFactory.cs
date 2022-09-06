using iHakeem.Infrastructure.Common.Localization.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using LocalizationOptions = iHakeem.Infrastructure.Common.Localization.Options.LocalizationOptions;

namespace iHakeem.Infrastructure.Common.Localization
{
    /// <inheritdoc />
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IOptions<LocalizationOptions> _localizationOptions;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JsonStringLocalizerFactory(
            IOptions<LocalizationOptions> localizationOptions,
            ILoggerFactory loggerFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _localizationOptions = localizationOptions ?? throw new ArgumentNullException(nameof(localizationOptions));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _httpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc />
        public IStringLocalizer Create(Type resourceSource)
        {
            return CreateJsonStringLocalizer(_localizationOptions.Value.Sources);
        }

        /// <inheritdoc />
        public IStringLocalizer Create(string baseName, string location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            return CreateJsonStringLocalizer(
                new[] { new LocalizationSource(location, LocalizationSourceType.Common), });
        }

        private JsonStringLocalizer CreateJsonStringLocalizer(IEnumerable<LocalizationSource> sources)
        {
            return new JsonStringLocalizer(
                sources,

                _loggerFactory.CreateLogger<JsonStringLocalizer>(), _httpContextAccessor);
        }
    }
}
