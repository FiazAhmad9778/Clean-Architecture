using iHakeem.Infrastructure.FileStorage.AzureBlob;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace iHakeem.Infrastructure.FileStorage
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds Security Authentication.
        /// </summary>


        public static IServiceCollection AddFileStorageServices(
            this IServiceCollection services
           )
        {
            services.AddScoped<IFileStorageService, AzureBlobStorageService>();
            services.AddScoped<IAzureBlobClientFactory, AzureBlobClientFactory>();

            return services;
        }

    }
}
