using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.SurgicalHistory;
using iHakeem.Domain.EMR.SurgicalHistory.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;

namespace iHakeem.Application.EMR.SurgicalHistory.QueryHandlers.Detail
{
    public class PatientGaurdianDetailHandler : IRequestHandler<GetSurgicalHistoryRequestDTO, SurgicalHistoryResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISurgicalHistoryRepository _SurgicalHistoryRepository;

        public PatientGaurdianDetailHandler(ISurgicalHistoryRepository SurgicalHistoryRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _SurgicalHistoryRepository = SurgicalHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<SurgicalHistoryResponseDTO> Handle(GetSurgicalHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _SurgicalHistoryRepository.GetSingle(request.Id);
            return _mapper.Map<SurgicalHistoryResponseDTO>(user);
        }
    }
}
