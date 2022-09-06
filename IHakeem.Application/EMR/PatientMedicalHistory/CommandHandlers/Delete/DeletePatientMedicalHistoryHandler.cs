using AutoMapper;
using iHakeem.Domain.EMR.PatientMedicalHistory.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CurrentMed = iHakeem.Domain.Models.PatientMedicalHistory;

namespace iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Delete
{
    public class DeletePatientMedicalHistoryHandler : IRequestHandler<DeletePatientMedicalHistoryRequestDTO, bool>
    {
        private readonly IPatientMedicalHistoryRepository _PatientMedicalHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePatientMedicalHistoryHandler(IPatientMedicalHistoryRepository PatientMedicalHistoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PatientMedicalHistoryRepository = PatientMedicalHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeletePatientMedicalHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PatientMedicalHistoryRepository.GetSingle(x => x.Id == request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            user.IsDeleted = true;
            _PatientMedicalHistoryRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
