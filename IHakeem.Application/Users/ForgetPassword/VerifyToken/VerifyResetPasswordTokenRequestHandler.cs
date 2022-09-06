using iHakeem.Domain.Models;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using iHakeem.Infrastructure.Security.Abstractions.GetAuthenticateToken;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Users.ForgetPassword.VerifyToken
{
    public class VerifyResetPasswordTokenRequestHandler : IRequestHandler<VerifyResetPasswordTokenRequest, bool>
    {
        private readonly IUserManagementService<ApplicationUser> _userManagementService;
        private readonly IGetAuthenticateToken _getAuthenticateToken;

        public VerifyResetPasswordTokenRequestHandler(IUserManagementService<ApplicationUser> userManagementService, IGetAuthenticateToken getAuthenticateToken)
        {
            _userManagementService = userManagementService;
            _getAuthenticateToken = getAuthenticateToken;
        }

        public Task<bool> Handle(VerifyResetPasswordTokenRequest request, CancellationToken cancellationToken)
        {
            var userToken = _getAuthenticateToken.GetUserFromToken();
            return _userManagementService.VerifyResetPassToken(userToken.UserId, request.Token);
        }

    }
}
