using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace iHakeem.SharedKernal
{
    public class CommonMethods
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommonMethods(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long GetClaim(string claimType)
        {
            var token = GetTokenFromRequest();

            var tokenHandler = new JwtSecurityTokenHandler();
            if (token != null)
            {
                var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (securityToken != null)
                {
                    var stringClaimValue = Convert.ToInt64(securityToken.Claims.First(claim => claim.Type == claimType).Value);
                    return stringClaimValue;
                }
            }

            return 0;
        }
        public string GetTokenFromRequest()
        {
            string authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (authHeader == null || !authHeader.StartsWith("Bearer")) return null;
            string token = authHeader.Substring("Bearer ".Length).Trim();
            return token;

        }

        public object GetClaim(object nameIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
