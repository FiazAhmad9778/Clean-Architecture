using iHakeem.Infrastructure.Services.Mailing;
using iHakeem.Infrastructure.Services.TwilioMessanger;
using Microsoft.Extensions.DependencyInjection;

namespace iHakeem.Infrastructure.Services
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds Security Authentication.
        /// </summary>


        public static IServiceCollection AddInfrastructureservices(
            this IServiceCollection services
           )
        {
            services.AddScoped<IMailer, Mailer>();
            services.AddScoped<IMessanger, Messanger>();
            return services;
        }
    }
}