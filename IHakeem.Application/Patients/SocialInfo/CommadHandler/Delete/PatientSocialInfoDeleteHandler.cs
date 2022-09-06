using AutoMapper;
using iHakeem.Domain.Patients.SocialInfo.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.SocialInfo.CommadHandler.Delete
{
    public class PatientSocialInfoDeleteHandler : IRequestHandler<PatientSocialInfoDeleteRequestDTO, bool>
    {
        private readonly IPatientSocialInformationRepository _patientSocialInfoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientSocialInfoDeleteHandler(IPatientSocialInformationRepository patientSocialInfoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _patientSocialInfoRepository = patientSocialInfoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PatientSocialInfoDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _patientSocialInfoRepository.GetSingle(x => x.SocialInformationId == request.Id && x.IsDeleted == false);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
