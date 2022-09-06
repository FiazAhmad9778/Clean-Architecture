using AutoMapper;
using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Application.Patients.SocialInfo.Contracts;
using iHakeem.Domain.Patients.SocialInfo.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.SocialInfo.CommadHandler.Create
{
    public class PatientSocialInfoCreateRequestHandler : IRequestHandler<PatientSocialInfoCreateRequestDTO, PatientSocialInfoDTO>
    {
        private readonly IPatientSocialInformationRepository _patientSocialInformationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientSocialInfoCreateRequestHandler(IPatientSocialInformationRepository patientSocialInformationRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _patientSocialInformationRepository = patientSocialInformationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PatientSocialInfoDTO> Handle(PatientSocialInfoCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var patientSocialInfoDTO = _mapper.Map<Domain.Models.PatientSocialInfo>(request);
            if (patientSocialInfoDTO != null)
            {
                if (patientSocialInfoDTO.SocialInformationId > 0)
                {
                    _patientSocialInformationRepository.Update(patientSocialInfoDTO);
                }
                else
                {
                    await _patientSocialInformationRepository.Add(patientSocialInfoDTO);
                }

            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientSocialInfoDTO>(patientSocialInfoDTO);
        }
    }
}