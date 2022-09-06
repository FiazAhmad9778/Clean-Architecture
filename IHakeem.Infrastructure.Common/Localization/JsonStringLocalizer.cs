using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using iHakeem.Infrastructure.Common.Localization.Extensions;
using iHakeem.Infrastructure.Common.Localization.Options;
using iHakeem.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace iHakeem.Infrastructure.Common.Localization
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private static readonly ConcurrentDictionary<string, Dictionary<string, string>> ResourcesCache =
            new ConcurrentDictionary<string, Dictionary<string, string>>();

        private CultureInfo _cultureInfo;
        private readonly ILogger<JsonStringLocalizer> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _searchedLocations;
        private readonly IEnumerable<LocalizationSource> _sources;
        private readonly string DEFAULT_CULTURE = "en-Us";

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonStringLocalizer" /> class.
        /// </summary>
        /// <param name="sources">Paths to resources.</param>
        /// <param name="cultureInfo">Culture info.</param>
        /// <param name="logger">The instance of <see cref="ILogger" />.</param>
        public JsonStringLocalizer(
            IEnumerable<LocalizationSource> sources,
            ILogger<JsonStringLocalizer> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _sources = sources ?? throw new ArgumentNullException(nameof(sources));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpContextAccessor = httpContextAccessor;
            var userLangs = httpContextAccessor.HttpContext.Request.Headers["Accept-Language"].ToString();
            var firstLang = userLangs.Split(',').FirstOrDefault();
            var defaultLang = string.IsNullOrEmpty(firstLang) ? DEFAULT_CULTURE : firstLang;
            _cultureInfo = new CultureInfo(defaultLang);
            if (!ResourcesCache.ContainsKey(_cultureInfo.Name))
            {
                ResourcesCache[_cultureInfo.Name] = GetLocalization();
            }
            _searchedLocations = string.Join(";", _sources);

        }

        /// <inheritdoc />
        public LocalizedString this[string name]
        {
            get
            {
                string value = GetStringSafely(name);

                return new LocalizedString(name, value ?? name, value == null, _searchedLocations);
            }
        }

        /// <inheritdoc />
        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                string format = GetStringSafely(name);
                string value = string.Format(CultureInfo.InvariantCulture, format ?? name, arguments);

                return new LocalizedString(name, value, format == null, _searchedLocations);
            }
        }

        /// <inheritdoc />
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return GetAllStrings(includeParentCultures, _cultureInfo);
        }

        /// <inheritdoc />
        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new JsonStringLocalizer(_sources, _logger, _httpContextAccessor);
        }

        private static IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures, CultureInfo culture)
        {
            if (ResourcesCache.TryGetValue(culture.Name, out Dictionary<string, string> values))
            {
                IEnumerable<LocalizedString> localizedStrings =
                    values.Select(pair => new LocalizedString(pair.Key, pair.Value));
                if (includeParentCultures)
                {
                    IEnumerable<LocalizedString> parentCultureLocalizedStrings = GetAllStrings(false, culture.Parent);
                    return localizedStrings.Concat(parentCultureLocalizedStrings);
                }

                return localizedStrings;
            }

            return Enumerable.Empty<LocalizedString>();
        }

        private Dictionary<string, string> GetLocalization()
        {

            return Merge(GetLocalization(new LocalizationSource(ResourceMap.GetLocalizationsRootPath(), LocalizationSourceType.Common)));
        }

        private Dictionary<string, string> GetLocalization(LocalizationSource source)
        {
            string[] filePaths = FindFiles(source.Path, $"*{_cultureInfo.Name}*.json");
            IEnumerable<KeyValuePair<string, string>> entries = filePaths.SelectMany(ReadFile);
            return Merge(entries);
        }

        private Dictionary<string, string> Merge(IEnumerable<KeyValuePair<string, string>> entries)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> entry in entries)
            {
                if (dictionary.ContainsKey(entry.Key))
                {
                    _logger.LogWarning($"Localization sources contains duplicate keys: {entry.Key}");
                    continue;
                }

                dictionary.Add(entry.Key, entry.Value);
            }

            return dictionary;
        }

        private IDictionary<string, string> ReadFile(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
            var temp = JsonSerializer.Deserialize<Dictionary<string, string>>(fileText);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(fileText);
        }

        private string[] FindFiles(string directory, string pattern)
        {
            return Directory.Exists(directory)
                ? Directory.GetFiles(directory, pattern)
                : Array.Empty<string>();
        }

        private string GetStringSafely(string name)
        {
            if (!ResourcesCache.TryGetValue(_cultureInfo.Name, out Dictionary<string, string> resources))
            {
                throw new ArgumentException($"There is no localization for [{_cultureInfo.Name}] culture.");
            }

            KeyValuePair<string, string>? resource = resources?.SingleOrDefault(s => s.Key == name);
            if (resource == null)
            {
                _logger.LocalizationNotFound(name, _searchedLocations, _cultureInfo);
            }

            return resource?.Value;
        }
    }
}
