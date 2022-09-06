using AutoMapper;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CurrentMed = iHakeem.Domain.Models.CurrentMedication;

namespace iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Delete
{
    public class DeleteCurrentMedicationHandler : IRequestHandler<DeleteCurrentMedicationRequestDTO, bool>
    {
        private readonly ICurrentMedicationRepository _currentMedicationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCurrentMedicationHandler(ICurrentMedicationRepository currentMedicationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _currentMedicationRepository = currentMedicationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteCurrentMedicationRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _currentMedicationRepository.GetSingle(x => x.Id == request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            user.IsDeleted = true;
            _currentMedicationRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
