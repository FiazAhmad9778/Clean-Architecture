using AutoMapper;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.PatientGaurdians.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.PatientGaurdians.CommandHandlers.Delete
{
    public class PatientGaurdianDeleteHandler : IRequestHandler<PatientGaurdianDeleteRequestDTO, bool>
    {
        private readonly IPatientGaurdianRepository _patientGaurdianRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientGaurdianDeleteHandler(IPatientGaurdianRepository patientGaurdianRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _patientGaurdianRepository = patientGaurdianRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PatientGaurdianDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _patientGaurdianRepository.GetSingle(x => x.Id == request.Id);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
