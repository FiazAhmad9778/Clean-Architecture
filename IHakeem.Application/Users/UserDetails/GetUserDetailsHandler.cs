using AutoMapper;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions.GetAuthenticateToken;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Users.UserDetails
{
    public class GetUserDetailsHandler : IRequestHandler<GetUserDetailRequestDTO, UserDetailResponseDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGetAuthenticateToken _getAuthenticateToken;
        private readonly IMapper _mapper;

        public GetUserDetailsHandler(IUserRepository userRepository, IGetAuthenticateToken getAuthenticateToken, IMapper mapper)
        {
            _userRepository = userRepository;
            _getAuthenticateToken = getAuthenticateToken;
            _mapper = mapper;
        }
        public async Task<UserDetailResponseDTO> Handle(GetUserDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var userToken = _getAuthenticateToken.GetUserFromToken();
            var user = await _userRepository.GetSingle(x => x.Id == userToken.UserId);
            var userDetails = _mapper.Map<UserDetailResponseDTO>(user);
            userDetails.RoleId = userToken.RoleId;
            return userDetails;
        }
    }
}
