using AutoMapper;
using iHakeem.Application.MyVitals.PulseOximeter.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.MyVitals.PulseOximeter.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.MyVitals.PulseOximeter.QueryHandlers.Detail
{
    public class PulseOximeterDetailHandler : IRequestHandler<GetPulseOximeterRequestDTO, PulseOximeterResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPulseOximeterRepository _PulseOximeterRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PulseOximeterDetailHandler(IPulseOximeterRepository PulseOximeterRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _PulseOximeterRepository = PulseOximeterRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PulseOximeterResponseDTO> Handle(GetPulseOximeterRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PulseOximeterRepository.GetSingle(request.Id);
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            return _mapper.Map<PulseOximeterResponseDTO>(user);
        }
    }
}
