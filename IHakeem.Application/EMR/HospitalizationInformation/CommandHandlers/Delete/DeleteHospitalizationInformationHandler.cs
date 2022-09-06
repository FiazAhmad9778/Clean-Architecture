using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using Hospital = iHakeem.Domain.Models.HospitalizationInformation;
using iHakeem.Domain.EMR.HospitalizationInformation.IDomainRepository;
using MediatR;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Delete
{
    public class DeleteHospitalizationInformationHandler : IRequestHandler<DeleteHospitalizationInformationRequestDTO, bool>
    {
        private readonly IHospitalizationInformationRepository _HospitalizationInformationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteHospitalizationInformationHandler(IHospitalizationInformationRepository HospitalizationInformationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _HospitalizationInformationRepository = HospitalizationInformationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteHospitalizationInformationRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _HospitalizationInformationRepository.GetSingle(x => x.Id == request.Id);
            Hospital user = _mapper.Map<Hospital>(res);
            user.IsDeleted = true;
            _HospitalizationInformationRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
