


using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.PharmacyInformation.QueryHandlers.Detail
{
    public class GetAllPharmacyInformationDetailRequestDTO : IRequest<List<PharmacyInformationResponseDTO>>
    {
    }
}
