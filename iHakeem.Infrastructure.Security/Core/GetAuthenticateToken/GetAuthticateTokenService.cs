using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Login;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using iHakeem.Infrastructure.Security.Abstractions.GetAuthenticateToken;
using iHakeem.SharedKernal.BaseDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using IAuthenticationService = iHakeem.Infrastructure.Security.Abstractions.Authentications.IAuthenticationService;

namespace iHakeem.Infrastructure.Security.Core.GetAuthticateToken
{
    /// <inheritdoc />
    internal class GetAuthticateTokenService : IGetAuthenticateToken

    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPatientRepository _patientReporsitory;

        public GetAuthticateTokenService(
            IPatientRepository patientReporsitory,
            IHttpContextAccessor httpContextAccessor)
        {
            _patientReporsitory = patientReporsitory;
            _httpContextAccessor = httpContextAccessor;
        }

        public GetAuthenticateTokenResponseData GetUserFromToken()
        {
            var user = _httpContextAccessor.HttpContext.User;

            var userName = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            var userId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var roleId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            return new GetAuthenticateTokenResponseData()
            {
                UserId = Convert.ToInt64(userId),
                RoleId = Convert.ToInt64(roleId),
                UserName = Convert.ToString(userName)
            };

        }


        public void FillAuditProperties(IAuditEntity auditEntity)
        {
            var token = GetUserFromToken();
            auditEntity.CreatedBy = token.UserId;
            auditEntity.CreatedDate = DateTime.UtcNow;
        }

    }
}
