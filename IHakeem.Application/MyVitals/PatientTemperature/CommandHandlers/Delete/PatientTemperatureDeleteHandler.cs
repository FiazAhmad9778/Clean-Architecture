using AutoMapper;
using PatientFamily = iHakeem.Domain.Models.PatientTemperature;
using iHakeem.Domain.MyVitals.PatientTemperature.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.MyVitals.PatientTemperature.CommandHandlers.Delete
{
    public class PatientTemperatureDeleteHandler : IRequestHandler<PatientTemperatureDeleteRequestDTO, bool>
    {
        private readonly IPatientTemperatureRepository _PatientTemperatureRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientTemperatureDeleteHandler(IPatientTemperatureRepository PatientTemperatureRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PatientTemperatureRepository = PatientTemperatureRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PatientTemperatureDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PatientTemperatureRepository.GetSingle(x => x.Id == request.Id);
            var user = _mapper.Map<PatientFamily>(res);
            user.IsDeleted = true;
            _PatientTemperatureRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
