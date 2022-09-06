using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.HospitalizationInformation;
using iHakeem.Domain.EMR.HospitalizationInformation.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;

namespace iHakeem.Application.EMR.HospitalizationInformation.QueryHandlers.Detail
{
    public class HospitalizationInformationDetailHandler : IRequestHandler<GetHospitalizationInformationRequestDTO, HospitalizationInformationResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHospitalizationInformationRepository _HospitalizationInformationRepository;

        public HospitalizationInformationDetailHandler(IHospitalizationInformationRepository HospitalizationInformationRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _HospitalizationInformationRepository = HospitalizationInformationRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<HospitalizationInformationResponseDTO> Handle(GetHospitalizationInformationRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _HospitalizationInformationRepository.GetSingle(request.Id);
            return _mapper.Map<HospitalizationInformationResponseDTO>(user);
        }
    }
}
