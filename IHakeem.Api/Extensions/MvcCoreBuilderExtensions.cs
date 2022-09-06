using iHakeem.Api.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace iHakeem.Api.Extensions
{

    /// <summary>
    ///     <see cref="IMvcCoreBuilder" /> extension methods which extend ASP.NET Core MVC configuration.
    /// </summary>
    public static class MvcCoreBuilderExtensions
    {
        /// <summary>
        ///     Adds customized JSON serializer settings.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder" />.</param>
        /// <param name="hostingEnvironment">The <see cref="IWebHostEnvironment" />.</param>
        /// <returns>The <see cref="IMvcCoreBuilder" /> with JSON configured.</returns>
        public static IMvcCoreBuilder AddCustomJsonOptions(
            this IMvcCoreBuilder builder,
            IWebHostEnvironment hostingEnvironment)
        {
            return builder.AddNewtonsoftJson(
                options =>
                {
                    if (hostingEnvironment.IsDevelopment())
                    {
                        // Pretty print the JSON in development for easier debugging.
                        options.SerializerSettings.Formatting = Formatting.Indented;
                    }

                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    // Parse dates as DateTimeOffset values by default. You should prefer using DateTimeOffset over
                    // DateTime everywhere. Not doing so can cause problems with time-zones.
                    options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;

                    // Output enumeration values as strings in JSON.
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());

                    // Output dates in host local timezone.
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                });
        }

        /// <summary>
        ///     Add cross-origin resource sharing (CORS) services and configures named CORS policies. See
        ///     https://docs.asp.net/en/latest/security/cors.html.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder" />.</param>
        /// <returns>The <see cref="IMvcCoreBuilder" /> with CORS enabled.</returns>
        public static IMvcCoreBuilder AddCustomCors(this IMvcCoreBuilder builder)
        {
            return builder.AddCors(
                options =>
                {
                    // Create named CORS policies here which you can consume using application.UseCors("PolicyName")
                    // or a [EnableCors("PolicyName")] attribute on your controller or action.
                    options.AddPolicy(
                        CorsPolicyName.AllowAny,
                        x => x
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                });
        }

        /// <summary>
        ///     Registers MVC with customization.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder" />.</param>
        /// <returns>The <see cref="IMvcCoreBuilder" /> with custom options applied.</returns>
        public static IMvcCoreBuilder AddCustomMvcOptions(this IMvcCoreBuilder builder)
        {
            return builder.AddMvcOptions(
                options =>
                {
                    // Remove string and stream output formatter. These are not useful for an API serving JSON or XML.
                    options.OutputFormatters.RemoveType<StreamOutputFormatter>();
                    options.OutputFormatters.RemoveType<StringOutputFormatter>();

                    // Returns a 406 Not Acceptable if the MIME type in the Accept HTTP header is not valid.
                    options.ReturnHttpNotAcceptable = true;
                });
        }


    }
}
