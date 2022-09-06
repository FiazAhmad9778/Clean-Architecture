using AutoMapper;
using PatientFamily = iHakeem.Domain.Models.PatientBloodPressure;
using iHakeem.Domain.MyVitals.PatientBloodPressure.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.MyVitals.PatientBloodPressure.CommandHandlers.Delete
{
    public class PatientBloodPressureDeleteHandler : IRequestHandler<PatientBloodPressureDeleteRequestDTO, bool>
    {
        private readonly IPatientBloodPressureRepository _PatientBloodPressureRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientBloodPressureDeleteHandler(IPatientBloodPressureRepository PatientBloodPressureRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PatientBloodPressureRepository = PatientBloodPressureRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PatientBloodPressureDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PatientBloodPressureRepository.GetSingle(x => x.Id == request.Id);
            var user = _mapper.Map<PatientFamily>(res);
            user.IsDeleted = true;
            _PatientBloodPressureRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
