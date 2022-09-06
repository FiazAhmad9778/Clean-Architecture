using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.PharmacyInformation;
using iHakeem.Domain.EMR.PharmacyInformation.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;

namespace iHakeem.Application.EMR.PharmacyInformation.QueryHandlers.Detail
{
    public class PharmacyInformationDetailHandler : IRequestHandler<GetPharmacyInformationRequestDTO, PharmacyInformationResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPharmacyInformationRepository _PharmacyInformationRepository;

        public PharmacyInformationDetailHandler(IPharmacyInformationRepository PharmacyInformationRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _PharmacyInformationRepository = PharmacyInformationRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PharmacyInformationResponseDTO> Handle(GetPharmacyInformationRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PharmacyInformationRepository.GetSingle(request.Id);
            return _mapper.Map<PharmacyInformationResponseDTO>(user);
        }
    }
}
