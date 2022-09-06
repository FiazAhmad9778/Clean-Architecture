using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.PatientAllergiesHistory;
using iHakeem.Domain.EMR.PatientAllergiesHistory.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.QueryHandlers.Detail
{
    public class PatientAllergiesHistoryDetailHandler : IRequestHandler<GetPatientAllergiesHistoryRequestDTO, PatientAllergiesHistoryResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPatientAllergiesHistoryRepository _PatientAllergiesHistoryRepository;

        public PatientAllergiesHistoryDetailHandler(IPatientAllergiesHistoryRepository PatientAllergiesHistoryRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _PatientAllergiesHistoryRepository = PatientAllergiesHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PatientAllergiesHistoryResponseDTO> Handle(GetPatientAllergiesHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PatientAllergiesHistoryRepository.GetSingle(request.Id);
            return _mapper.Map<PatientAllergiesHistoryResponseDTO>(user);
        }
    }
}
