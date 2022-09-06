using AutoMapper;
using iHakeem.Application.Doctors.AwardsAndRecognition.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.AwardsAndRecognitions.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.AwardsAndRecognitions.QueryHandler.Detail
{
    public class DoctorAwardsAndRecognitionDetailHandler : IRequestHandler<DoctorAwardsAndRecognitionDetailRequestDTO, DoctorAwardsAndRecognitionDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDoctorAwardsAndRecognitionRepository _doctorAwardsAndRecognitionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorAwardsAndRecognitionDetailHandler(IDoctorAwardsAndRecognitionRepository DoctorAwardsAndRecognitionRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorAwardsAndRecognitionRepository = DoctorAwardsAndRecognitionRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DoctorAwardsAndRecognitionDTO> Handle(DoctorAwardsAndRecognitionDetailRequestDTO request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DoctorAwardsAndRecognitionDTO>(await _doctorAwardsAndRecognitionRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false));
        }
    }
}
