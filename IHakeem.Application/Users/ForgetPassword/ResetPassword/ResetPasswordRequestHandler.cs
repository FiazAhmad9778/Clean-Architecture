using iHakeem.Domain.Models;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using iHakeem.Infrastructure.Security.Abstractions.GetAuthenticateToken;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Users.ForgetPassword.ResetPassword
{
    public class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, bool>
    {
        private readonly IUserManagementService<ApplicationUser> _userManagementService;
        private readonly IGetAuthenticateToken _getAuthenticateToken;

        public ResetPasswordRequestHandler(IUserManagementService<ApplicationUser> userManagementService, IGetAuthenticateToken getAuthenticateToken)
        {
            _userManagementService = userManagementService;
            _getAuthenticateToken = getAuthenticateToken;
        }

        public Task<bool> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var userToken = _getAuthenticateToken.GetUserFromToken();
            return _userManagementService.resetPassword(userToken.UserId, request.Token, request.Password);
        }

    }
}
