using AutoMapper;
using iHakeem.Application.Doctors.References.Contracts;
using iHakeem.Domain.Doctors.References.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.References.QueryHandler.List
{
    public class DoctorReferenceRequestHandler : IRequestHandler<DoctorReferenceListRequestDTO, List<DoctorReferenceDTO>>
    {
        private readonly IDoctorReferenceRepository _doctorReferenceRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorReferenceRequestHandler(IDoctorReferenceRepository doctorReferenceRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorReferenceRepository = doctorReferenceRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<DoctorReferenceDTO>> Handle(DoctorReferenceListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DoctorReferenceDTO>>(await _doctorReferenceRepository.GetAll(x => x.DoctorId == query.DoctorId && x.IsDeleted == false));
        }
    }
}
