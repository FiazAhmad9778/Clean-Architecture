using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Delete
{
    public class DeleteHospitalizationInformationRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
