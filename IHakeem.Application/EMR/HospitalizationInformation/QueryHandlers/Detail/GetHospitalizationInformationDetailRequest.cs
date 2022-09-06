using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.HospitalizationInformation.QueryHandlers.Detail
{
    public class GetHospitalizationInformationRequestDTO : IRequest<HospitalizationInformationResponseDTO>
    {
        public long Id { get; set; }
    }
}
