using AutoMapper;
using iHakeem.Application.Doctors.References.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.References.IDomainRepository;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.References.QueryHandler.Detail
{
    public class DoctorReferenceDetailHandler : IRequestHandler<DoctorReferenceDetailRequestDTO, DoctorReferenceDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDoctorReferenceRepository _doctorReferenceRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorReferenceDetailHandler(IDoctorReferenceRepository doctorReferenceRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorReferenceRepository = doctorReferenceRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DoctorReferenceDTO> Handle(DoctorReferenceDetailRequestDTO request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DoctorReferenceDTO>(await _doctorReferenceRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false));
        }
    }
}
