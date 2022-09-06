using AutoMapper;
using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Domain.Doctors.SocialInfo.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.SocialInfo.CommadHandler.Create
{
    public class DoctorSocialInfoCreateRequestHandler : IRequestHandler<DoctorSocialInfoCreateRequestDTO, DoctorSocialInfoDTO>
    {
        private readonly IDoctorSocialInformationRepository _doctorSocialInformationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorSocialInfoCreateRequestHandler(IDoctorSocialInformationRepository doctorSocialInformationRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _doctorSocialInformationRepository = doctorSocialInformationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorSocialInfoDTO> Handle(DoctorSocialInfoCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var doctorSocialInfoDTO = _mapper.Map<Domain.Models.DoctorSocialInfo>(request);
            if (doctorSocialInfoDTO != null)
            {
                if (doctorSocialInfoDTO.SocialInformationId > 0)
                {
                    _doctorSocialInformationRepository.Update(doctorSocialInfoDTO);
                }
                else
                {
                    await _doctorSocialInformationRepository.Add(doctorSocialInfoDTO);
                }

            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorSocialInfoDTO>(doctorSocialInfoDTO);
        }
    }
}