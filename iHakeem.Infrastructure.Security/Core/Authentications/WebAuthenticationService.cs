using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Login;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using iHakeem.Infrastructure.Security.Abstractions.Authorization.Roles;
using iHakeem.SharedKernal.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using IAuthenticationService = iHakeem.Infrastructure.Security.Abstractions.Authentications.IAuthenticationService;

namespace iHakeem.Infrastructure.Security.Core.Authentications
{
    /// <inheritdoc />
    internal class WebAuthenticationService : IAuthenticationService

    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IClaimProvider _claimProvider;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public WebAuthenticationService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            IStringLocalizer stringLocalizer,
            IClaimProvider claimProvider,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _stringLocalizer = stringLocalizer;
            _claimProvider = claimProvider;
            _roleManager = roleManager;
        }

        public async Task<LoginResponseData> LogInAsync(LoginData model)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Status == Convert.ToInt32(UserStatus.Active));
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var role = await _roleManager.FindByNameAsync(userRoles.FirstOrDefault());
                long referenceId = 0;
                if (role.Id != Convert.ToInt64(UserRoles.Admin))
                {
                    referenceId = await _claimProvider.GetReferenceIdByRole(role.Id, user.Id);
                }

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, role.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimConstant.ReferenceId, referenceId.ToString())

                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"));

                var token = new JwtSecurityToken(
                    expires: DateTime.UtcNow.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new LoginResponseData
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpiredOn = token.ValidTo,
                    IsAuthenticated = true
                };
            }
            throw new CodedException(ErrorCode.InValidUsernameOrPassword, _stringLocalizer[ErrorCode.InValidUsernameOrPassword.ToString()].ToString());
        }



        public Task LogOutAsync()
        {
            _signInManager.SignOutAsync();
            return Task.CompletedTask;
        }


    }
}
