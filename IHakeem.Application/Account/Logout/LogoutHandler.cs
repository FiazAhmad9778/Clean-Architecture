using System.Threading;
using System.Threading.Tasks;
using iHakeem.Infrastructure.Security.Abstractions.Authentications;
using JetBrains.Annotations;
using MediatR;

namespace iHakeem.Application.Account.Logout
{
    internal class LogoutHandler : IRequestHandler<LogoutRequest>
    {
        private readonly IAuthenticationService _authenticationService;

        public LogoutHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Unit> Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            await _authenticationService.LogOutAsync();
            return Unit.Value;
        }
    }
}
