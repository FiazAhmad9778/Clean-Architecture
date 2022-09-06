using AutoMapper;
using iHakeem.Application.Doctors.Education.Contracts;
using iHakeem.Domain.Doctors.Education;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Education.QueryHandler.List
{
    public class DoctorEducationRequestHandler : IRequestHandler<DoctorEducationListRequestDTO, List<DoctorEducationDTO>>
    {
        private readonly IDoctorEducationRepository _doctorEducationRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorEducationRequestHandler(IDoctorEducationRepository doctorEducationRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorEducationRepository = doctorEducationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<DoctorEducationDTO>> Handle(DoctorEducationListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DoctorEducationDTO>>(await _doctorEducationRepository.GetAll(x => x.DoctorId == query.DoctorId && x.IsDeleted == false));
        }
    }
}
