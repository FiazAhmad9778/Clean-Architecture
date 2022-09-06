using AutoMapper;
using iHakeem.Application.Doctors.Education.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.Education;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Education.QueryHandler.Detail
{
    public class DoctorEducationDetailHandler : IRequestHandler<DoctorEducationDetailRequestDTO, DoctorEducationDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDoctorEducationRepository _doctorEducationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorEducationDetailHandler(IDoctorEducationRepository doctorEducationRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorEducationRepository = doctorEducationRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DoctorEducationDTO> Handle(DoctorEducationDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _doctorEducationRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false);
            return _mapper.Map<DoctorEducationDTO>(user);
        }
    }
}
