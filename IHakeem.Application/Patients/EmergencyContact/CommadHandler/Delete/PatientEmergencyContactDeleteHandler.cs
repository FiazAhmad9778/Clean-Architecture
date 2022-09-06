using AutoMapper;
using iHakeem.Domain.Patients.PatientSocialInfo.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.PatientEmergencyContacts.CommandHandlers.Delete
{
    public class PatientEmergencyContactDeleteHandler : IRequestHandler<PatientEmergencyContactDeleteRequestDTO, bool>
    {
        private readonly IPatientEmergencyContactRepository _patientEmergencyContactRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientEmergencyContactDeleteHandler(IPatientEmergencyContactRepository patientEmergencyContactRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _patientEmergencyContactRepository = patientEmergencyContactRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PatientEmergencyContactDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _patientEmergencyContactRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
