using iHakeem.Infrastructure.Common.Localization;
using iHakeem.Infrastructure.Common.Localization.Options;
using iHakeem.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using System;
using System.Globalization;

namespace iHakeem.Api.Extensions
{
    /// <summary>
    ///     <see cref="IServiceCollection" /> extension methods which extend ASP.NET Core services.
    /// </summary>
    public static class CustomServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .Configure<Infrastructure.Common.Localization.Options.LocalizationOptions>(options => CreateLocalizationOptions(options, configuration));

            return services;
        }
        private static void CreateLocalizationOptions(
            Infrastructure.Common.Localization.Options.LocalizationOptions options,
            IConfiguration configuration)
        {
            options.SupportedCultures = configuration.GetSection("Localization:SupportedCultures").Get<string[]>();
            options.DefaultCulture = configuration.GetValue<string>("Localization:DefaultCulture");
            options.Sources = new[]
            {
                new LocalizationSource(ResourceMap.GetLocalizationsRootPath(), LocalizationSourceType.Common),
            };

        }



        public static IServiceCollection AddJsonLocalization(this IServiceCollection services)
        {
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.AddScoped<IStringLocalizer, JsonStringLocalizer>();


            return services;
        }


        /// <summary>
        ///     Adds Swagger services and configures the Swagger services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen();
        }


    }
}