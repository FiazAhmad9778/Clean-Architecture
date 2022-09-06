using AutoMapper;
using iHakeem.Application.Doctors.DoctorServices.Contracts;
using iHakeem.Domain.Doctors.DoctorServices.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Services.QueryHandler.List
{
    public class DoctorServiceDetailRequestHandler : IRequestHandler<DoctorServiceListRequestDTO, List<DoctorServiceDTO>>
    {
        private readonly IDoctorServiceRepository _doctorServiceRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorServiceDetailRequestHandler(IDoctorServiceRepository doctorServiceRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorServiceRepository = doctorServiceRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<DoctorServiceDTO>> Handle(DoctorServiceListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DoctorServiceDTO>>(await _doctorServiceRepository.GetAll(x => x.DoctorId == query.DoctorId && x.IsDeleted == false));
        }
    }
}
