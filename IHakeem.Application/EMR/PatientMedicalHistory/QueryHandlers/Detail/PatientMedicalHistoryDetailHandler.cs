using AutoMapper;
using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PatientMedicalHistory.IDomainRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.PatientMedicalHistory.QueryHandlers.Detail
{
    public class PatientMedicalHistoryDetailHandler : IRequestHandler<GetPatientMedicalHistoryRequestDTO, PatientMedicalHistoryResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPatientMedicalHistoryRepository _PatientMedicalHistoryRepository;

        public PatientMedicalHistoryDetailHandler(IPatientMedicalHistoryRepository PatientMedicalHistoryRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _PatientMedicalHistoryRepository = PatientMedicalHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PatientMedicalHistoryResponseDTO> Handle(GetPatientMedicalHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PatientMedicalHistoryRepository.GetSingle(request.Id);
            return _mapper.Map<PatientMedicalHistoryResponseDTO>(user);
        }
    }
}
