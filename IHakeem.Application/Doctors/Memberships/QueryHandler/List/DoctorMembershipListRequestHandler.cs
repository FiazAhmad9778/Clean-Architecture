using AutoMapper;
using iHakeem.Application.Doctors.Memberships.Contracts;
using iHakeem.Domain.Doctors.Memberships.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Memberships.QueryHandler.List
{
    public class DoctorMembershipRequestHandler : IRequestHandler<DoctorMembershipListRequestDTO, List<DoctorMembershipDTO>>
    {
        private readonly IDoctorMembershipRepository _doctorMembershipRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorMembershipRequestHandler(IDoctorMembershipRepository doctorMembershipRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorMembershipRepository = doctorMembershipRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<DoctorMembershipDTO>> Handle(DoctorMembershipListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DoctorMembershipDTO>>(await _doctorMembershipRepository.GetAll(x => x.DoctorId == query.DoctorId && x.IsDeleted == false));
        }
    }
}
