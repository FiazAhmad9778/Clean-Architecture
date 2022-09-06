using iHakeem.Domain.Models;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using iHakeem.Infrastructure.Security.Abstractions.GetAuthenticateToken;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Users.ChangePassword
{
    public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequestDTO, Unit>
    {
        private readonly IUserManagementService<ApplicationUser> _userManagementService;
        private readonly IGetAuthenticateToken _getAuthenticateToken;

        public ChangePasswordRequestHandler(IUserManagementService<ApplicationUser> userManagementService, IGetAuthenticateToken getAuthenticateToken)
        {
            _userManagementService = userManagementService;
            _getAuthenticateToken = getAuthenticateToken;
        }
        public async Task<Unit> Handle(ChangePasswordRequestDTO request,
            CancellationToken cancellationToken)
        {
            var user = _getAuthenticateToken.GetUserFromToken();
            await _userManagementService.ChangePassword(user.UserId, request.NewPassword, request.OldPassword);

            return Unit.Value;
        }
    }
}
