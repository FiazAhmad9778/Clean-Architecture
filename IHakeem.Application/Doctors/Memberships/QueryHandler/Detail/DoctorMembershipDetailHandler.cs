using AutoMapper;
using iHakeem.Application.Doctors.Memberships.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.Memberships.IDomainRepository;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Memberships.QueryHandler.Detail
{
    public class DoctorMembershipDetailHandler : IRequestHandler<DoctorMembershipDetailRequestDTO, DoctorMembershipDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDoctorMembershipRepository _doctorMembershipRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorMembershipDetailHandler(IDoctorMembershipRepository doctorMembershipRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorMembershipRepository = doctorMembershipRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DoctorMembershipDTO> Handle(DoctorMembershipDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _doctorMembershipRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false);
            return _mapper.Map<DoctorMembershipDTO>(user);
        }
    }
}
