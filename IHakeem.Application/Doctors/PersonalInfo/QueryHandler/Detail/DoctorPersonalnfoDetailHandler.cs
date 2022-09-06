using AutoMapper;
using iHakeem.Application.Doctors.PersonalInfo.Contracts;
using iHakeem.Application.Doctors.PersonalInfo.QueryHandler.Detail;
using iHakeem.Domain.Doctors.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.PersonalInfo.QueryHandler.List
{
    public class DoctorPersonalInfoDetailRequest : IRequestHandler<DoctorPersonalInfoDetailRequestDTO, DoctorPersonalInfoResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDoctorRepository _patientRepository;

        public DoctorPersonalInfoDetailRequest(IDoctorRepository DoctorRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _patientRepository = DoctorRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<DoctorPersonalInfoResponseDTO> Handle(DoctorPersonalInfoDetailRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<DoctorPersonalInfoResponseDTO>(await _patientRepository.GetSingle(x => x.Id == query.DoctorId,
                x => x.MaritialStatus
                ));
        }
    }
}
