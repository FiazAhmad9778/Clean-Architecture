using AutoMapper;
using iHakeem.Application.EMR.CurrentMedication.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.CurrentMedication.QueryHandlers.Detail
{
    public class CurrentMedicationDetailHandler : IRequestHandler<GetCurrentMedicationDetailRequestDTO, CurrentMedicationResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentMedicationRepository _currentMedicationRepository;

        public CurrentMedicationDetailHandler(ICurrentMedicationRepository currentMedicationRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _currentMedicationRepository = currentMedicationRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CurrentMedicationResponseDTO> Handle(GetCurrentMedicationDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _currentMedicationRepository.GetSingle(request.Id);
            return _mapper.Map<CurrentMedicationResponseDTO>(user);
        }
    }
}
