using iHakeem.Api.Extensions;
using iHakeem.Api.Middleware;
using iHakeem.Api.Middleware.Logging;
using iHakeem.Application.Extensions.Installers;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using iHakeem.Infrastructure.Services;
using Microsoft.OpenApi.Models;
using iHakeem.Api.Filters;
using iHakeem.Infrastructure.FileStorage;

namespace iHakeem.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJsonLocalization();
            services.AddCustomOptions(_configuration);
            services.AddControllers();
            services.RegisterRepositories();
            services.RegisterServices();
            services.RegisterPackages(_configuration);
            services.AddSingleton<ExceptionHandlingMiddleware>();
            services.AddSingleton<IRequestLogger, RequestLogger>();
            services.AddSingleton<IResponseLogger, ResponseLogger>();
            services.AddSingleton<ILoggingBehaviorProvider, LoggingBehaviorProvider>();
            services.AddSingleton<RequestResponseLoggingMiddleware>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddFile("Logs/app_{0:yyyy}-{0:MM}-{0:dd}.log", fileLoggerOpts =>
                {
                    fileLoggerOpts.FormatLogFileName = fName =>
                    {
                        return String.Format(fName, DateTime.UtcNow);
                    };
                });
            });
            services.AddSecurityAuthorization(_configuration);
            services.AddSecurityServices();
            services.AddSecurityAuthenticationCore<ApplicationUser>();
            services.AddInfrastructureservices();
            services.AddFileStorageServices();

            //services.AddSwagger();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iHakeem.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            services.AddMvcCore(config =>
            {
                config.Filters.Add(typeof(GlobalExceptionFilter));
            })
            .AddCustomMvcOptions()
            .AddCustomJsonOptions(_hostingEnvironment)
            .AddCustomCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRequestLocalization(
                    RequestLocalizationConfigurator.GetRequestLocalizationOptions(app.ApplicationServices));
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "iHakeem.API v1");
            });
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            //app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
