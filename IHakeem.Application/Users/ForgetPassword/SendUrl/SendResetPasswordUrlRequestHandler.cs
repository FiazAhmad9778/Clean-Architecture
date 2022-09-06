using iHakeem.Domain.Models;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Users.ForgetPassword.SendUrl
{
    public class SendResetPasswordUrlRequestHandler : IRequestHandler<SendResetPasswordUrlRequest, bool>
    {
        private readonly IUserManagementService<ApplicationUser> _userManagementService;

        public SendResetPasswordUrlRequestHandler(IUserManagementService<ApplicationUser> userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public Task<bool> Handle(SendResetPasswordUrlRequest request, CancellationToken cancellationToken)
        {
            return _userManagementService.SendForgetPasswordUrl(request.Email, request.Url);
        }
    }
}
