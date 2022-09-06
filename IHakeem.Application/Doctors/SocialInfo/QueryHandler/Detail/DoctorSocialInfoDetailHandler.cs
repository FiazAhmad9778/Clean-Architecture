using AutoMapper;
using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.SocialInfo.IDomainRepository;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.SocialInfo.QueryHandler.Detail
{
    public class DoctorSocialInfoDetailHandler : IRequestHandler<DoctorSocialInfoDetailRequestDTO, DoctorSocialInfoDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDoctorSocialInformationRepository _doctorSocialInfoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorSocialInfoDetailHandler(IDoctorSocialInformationRepository doctorSocialInfoRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorSocialInfoRepository = doctorSocialInfoRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DoctorSocialInfoDTO> Handle(DoctorSocialInfoDetailRequestDTO request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DoctorSocialInfoDTO>(await _doctorSocialInfoRepository.GetSingle(x => x.SocialInformationId == request.Id && x.IsDeleted == false, x => x.SocialInformation));
        }
    }
}
