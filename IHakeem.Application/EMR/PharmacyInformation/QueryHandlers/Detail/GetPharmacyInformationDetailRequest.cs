using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PharmacyInformation.QueryHandlers.Detail
{
    public class GetPharmacyInformationRequestDTO : IRequest<PharmacyInformationResponseDTO>
    {
        public long Id { get; set; }
    }
}
