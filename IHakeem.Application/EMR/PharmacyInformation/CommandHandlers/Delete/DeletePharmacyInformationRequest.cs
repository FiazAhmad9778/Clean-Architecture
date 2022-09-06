using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Delete
{
    public class DeletePharmacyInformationRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
