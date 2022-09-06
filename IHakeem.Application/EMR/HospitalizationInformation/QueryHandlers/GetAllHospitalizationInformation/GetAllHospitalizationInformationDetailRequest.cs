


using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.HospitalizationInformation.QueryHandlers.Detail
{
    public class GetAllHospitalizationInformationDetailRequestDTO : IRequest<List<HospitalizationInformationResponseDTO>>
    {
    }
}
