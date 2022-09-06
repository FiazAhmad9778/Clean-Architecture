using AutoMapper;
using iHakeem.Domain.Doctors.SocialInfo.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.SocialInfo.CommadHandler.Delete
{
    public class DoctorSocialInfoDeleteHandler : IRequestHandler<DoctorSocialInfoDeleteRequestDTO, bool>
    {
        private readonly IDoctorSocialInformationRepository _doctorSocialInfoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorSocialInfoDeleteHandler(IDoctorSocialInformationRepository doctorSocialInfoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _doctorSocialInfoRepository = doctorSocialInfoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DoctorSocialInfoDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _doctorSocialInfoRepository.GetSingle(x => x.SocialInformationId == request.Id && x.IsDeleted == false);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
