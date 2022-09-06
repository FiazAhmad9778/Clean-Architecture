using System;
using System.Text;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.Security.Abstractions.Authentications;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Login;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using iHakeem.Infrastructure.Security.Abstractions.GetAuthenticateToken;
using iHakeem.Infrastructure.Security.Core.Authentications;
using iHakeem.Infrastructure.Security.Core.GetAuthticateToken;
using iHakeem.Infrastructure.Security.Core.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace iHakeem.Infrastructure.Security
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds Security Authentication.
        /// </summary>


        public static IServiceCollection AddSecurityAuthorization(
            this IServiceCollection services, IConfiguration configuration
           )
        {

            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
           .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

           // Adding Jwt Bearer  
           .AddJwtBearer(

                options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"))
                    };

                }

           );

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            return services;
        }
        public static IServiceCollection AddSecurityServices(
          this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, WebAuthenticationService>();
            services.AddScoped<IGetAuthenticateToken, GetAuthticateTokenService>();
            services.AddScoped<IClaimProvider, ClaimProvider>();
            return services;
        }

        public static IServiceCollection AddSecurityAuthenticationCore<T>(
         this IServiceCollection serviceCollection
        )
         where T : class, IUser
        {
            serviceCollection
                .AddScoped<IUserManagementService<T>, UserManagementService<T>>();
            return serviceCollection;
        }
    }
}
