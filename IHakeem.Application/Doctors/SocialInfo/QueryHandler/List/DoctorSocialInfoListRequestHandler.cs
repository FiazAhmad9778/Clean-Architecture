using AutoMapper;
using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Application.Doctors.SocialInfo.QueryHandler.List;
using iHakeem.Domain.Doctors.SocialInfo.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.DoctorSocialInfo.QueryHandler.List
{
    public class DoctorSocialInfoListRequestHandler : IRequestHandler<DoctorSocialInfoListRequestDTO, List<DoctorSocialInfoDTO>>
    {
        private readonly IDoctorSocialInformationRepository _doctorSocialInformationRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorSocialInfoListRequestHandler(IDoctorSocialInformationRepository doctorSocialInformationRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorSocialInformationRepository = doctorSocialInformationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<DoctorSocialInfoDTO>> Handle(DoctorSocialInfoListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DoctorSocialInfoDTO>>(await _doctorSocialInformationRepository.AllIncluding(x => x.DoctorId == query.DoctorId, x => x.SocialInformation));
        }
    }
}
