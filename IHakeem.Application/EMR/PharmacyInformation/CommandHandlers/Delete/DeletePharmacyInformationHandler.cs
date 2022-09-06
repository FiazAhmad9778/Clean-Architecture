using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using CurrentMed = iHakeem.Domain.Models.PharmacyInformation;
using iHakeem.Domain.EMR.PharmacyInformation.IDomainRepository;
using MediatR;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Delete
{
    public class DeletePharmacyInformationHandler : IRequestHandler<DeletePharmacyInformationRequestDTO, bool>
    {
        private readonly IPharmacyInformationRepository _PharmacyInformationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePharmacyInformationHandler(IPharmacyInformationRepository PharmacyInformationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PharmacyInformationRepository = PharmacyInformationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeletePharmacyInformationRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PharmacyInformationRepository.GetSingle(x => x.Id == request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            user.IsDeleted = true;
            _PharmacyInformationRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
