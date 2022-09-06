using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Infrastructure.Security.Abstractions.Authentications;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Login;
using JetBrains.Annotations;
using MediatR;

namespace iHakeem.Application.Account.Login
{

    internal class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public LoginHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            LoginResponseData result = await _authenticationService.LogInAsync(request);
            return _mapper.Map<LoginResponse>(result);
        }
    }
}
